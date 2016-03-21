using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    

    public class StaticElement : VisualElement
    {
        public StaticElement()
        {

        }

        public StaticElement(string key, Codespace parent)
            : base(key, parent)
        {
        }

        public override bool Static()
        {
            return true; //always
        }

        public override void Layout()
        {


        }

        public override Point Position()
        {
            throw new NotImplementedException();
        }
    }
}
