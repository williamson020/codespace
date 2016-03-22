using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    public abstract class VisualElement : CodespaceElement
    {

        protected int _width = 0;
        protected int _height = 0;
        protected Point _layoutpos;


        public VisualElement()
        {
           
        }

        public VisualElement(string key,Codespace parent): base (key,parent)
        {

        }

        public virtual void Reset()
        {
        }

        public virtual PathGeometry GenerateDefaultPath()
        {
            return null;
        }

        public abstract bool Static();
        
        public override int Height()
        {
            return _height;
        }

        public override int Width()
        {
            return _width;
        }

        public abstract Point Position();

        public Point LayoutPos
        {
            get
            {
                return _layoutpos;
            }
            set
            {
                _layoutpos = value;
            }
        }
        public Point MidPoint
        {
            get
            {
                Point p = Position();
                p.Offset(Width() / 2, Height() / 2);
                return p;
            }
        }

        public virtual bool SubjectToMagnetism()
        {
            return false;
               
            
        }


    }
}
