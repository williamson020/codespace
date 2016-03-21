using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    /*
    public class RotatingActor : DynamicElement, ISpinnable
    {
        private Rotation _roation = Rotation.Clockwise;
        private int _revs = 0;
        private bool _spinning = false;

        public Rotation SpinDirection
        {
            get
            {
                return _roation;
            }
            set
            {
                _roation = value;
            }
        }

        public int RevsPerSecond
        {
            get
            {
                return _revs;
            }
            set
            {
                _revs = value;
            }
        }


        
        public override void SelfAnimate(bool startstop)
        {
            StartSpin();
        }

        public void Spin(bool b)
        {
            if (!_spinning && b)
                StartSpin();
            else
                if (_spinning && !b)
                    StopSpin();
        }

        private void StopSpin()
        {
            //call base base to stop animation associated with this Actor
            _spinning = false;
        }

        private void StartSpin()
        {
            //call base base to start animation associated with this Actor
            _spinning = true;

        }

        public override PathGeometry GenerateDefaultPath() 
        {
            if (!_spinning)
                return null;

            return base.GenerateDefaultPath();
        }

                
            

    }
     */
}
