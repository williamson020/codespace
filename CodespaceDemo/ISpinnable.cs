using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodespaceDemo
{

    public enum Rotation { Clockwise, Anticlockwise };

    public interface ISpinnable
    {
        Rotation SpinDirection { get; set; }

        int RevsPerSecond { get; set; }

        void Spin(bool b);
        

    }
}
