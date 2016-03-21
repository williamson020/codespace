using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    
    public class DynamicElement : VisualElement
    {

        public enum Magnestism { None, Magnetic, Antimagnetic }; // applies only if parent CodeSpace has a magnetic direction set

        public bool AnimatedOnReset { get; set; } //
        public bool SelfAnimated { get; set; } //has a self animation (distinct from movement on path) e.g. spin

        //By default DynamicElement can move around. Override this with _static = false 
        private bool _static = false;

        //The path on which this element travels by default.
        private PathGeometry _defaultpath;

        public DynamicElement()
        {
        }
        public DynamicElement(string key, Codespace parent):base(key,parent)
        {
            MagneticState = Magnestism.None;
        }


        public Magnestism MagneticState { get; set; }


        public override void Reset()
        {
           
        }

        public override Point Position()
        {
            throw new NotImplementedException();
        }

        public override bool Static()
        {
            return _static;
        }

        public override void Layout()
        {
            _defaultpath = GenerateDefaultPath();
            SelfAnimate(SelfAnimated && AnimatedOnReset);
        }

        public override bool SubjectToMagnetism()
        {
            return !_static && (MagneticState != Magnestism.None) && _parent.HasMagneticBorder;
        }

       

        /// <summary>
        /// Default travel path when not interacting with other actors. E.g. if object has momentum it will keep moving in a certain direction until some interaction
        /// </summary>
        /// <returns></returns>
        public override PathGeometry GenerateDefaultPath()
        {
            if (!SubjectToMagnetism())
                return null;

            return Parent.GenerateMagneticPath(this);
            

        }

        public virtual void SelfAnimate(bool startstop)
        {

        }
        
        /// <summary>
        /// Handle interaction with other actors - e.g. change path, color, sound etc
        /// </summary>
        /// <param name="path"></param>
        public virtual void BeginInteract(DynamicElement path)
        {

        }

        public virtual void EndInteract(DynamicElement path)
        {
            //Default behaviour is to regenerate a default path
        }

    }
}
