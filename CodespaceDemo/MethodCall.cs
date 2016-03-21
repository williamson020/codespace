using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    delegate void fn();

    class MethodCall
    {

        public string PublicName { get; set; }

        public fn _theFunc;

        public List<Object> _args = new List<object>();




    }
}
