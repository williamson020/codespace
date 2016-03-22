using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

   
    public class MethodType
    {

        #region Properties
        private ElementType _class;
        internal List<ArgumentType> Args = new List<ArgumentType>();

        private string _publicName;

        internal delegate void Callback(CodespaceElement element, object[] args);
        
        /// <summary>
        ///This callback invoked on runtime invocation
        /// </summary>
        private Callback _del;


        
        public string PublicName { get { return _publicName; }  }
        public int ArgCount {  get  { return Args.Count; } }
        #endregion

        internal MethodType(string publicName, Callback del, ElementType eb)
        {
            _class = eb;
            _publicName = publicName;
            _del = del;
        }

        internal Callback Delegate { get { return _del; } }
             


    }
}
