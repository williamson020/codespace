using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    /// <summary>
    /// Singleton pattern here
    /// </summary>
    /// 

    class TransitionMananger
    {
        private static TransitionMananger _instance;

        private Module _module;

        public static TransitionMananger Factory(Module m)
        {
            _instance = new TransitionMananger(m);
            return Instance();
        }

        public static TransitionMananger Instance()
        {
            return _instance;
        }

        private TransitionMananger(Module m)
        {
            _module = m;
        }


        
    }
}
