using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodespaceDemo
{
    interface ICodespaceElement
    {
        string Key { get; set; }
        Codespace Parent { get; }
        void Layout();

    }

    public abstract class CodespaceElement : ICodespaceElement
    {
        
        private string _key;
        
        protected Codespace _parent;

        public CodespaceElement()
        {
            
        }

        public CodespaceElement(string key, Codespace parent)
            : base()
        {
            
            Debug.Assert(!String.IsNullOrEmpty(key));

            Key = key;
            _parent = parent;
        }


        public abstract int Width();

        public abstract int Height();


        #region basic properties
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }


        public Codespace Parent
        {
            get { return _parent; }
        }

        public abstract void Layout();
       
       

       

        #endregion
    }
}