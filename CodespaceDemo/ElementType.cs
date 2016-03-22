using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    public class ElementTypeBase
    {

        protected string _classname;
        protected Dictionary<string, MethodType> _methods = new Dictionary<string, MethodType>();

        internal ElementTypeBase(string classname)
        {
            _classname = classname;

        }
        //todo:

        //provide interface to generic PUBLIC INTERFACE properties of elements - COLOR / PATH / SELF ANIMATION/ 

      
    }


    /// <summary>
    /// Meta class for programming Codespace Elements. Packages the user visible API
    /// </summary>
    public class ElementType : ElementTypeBase
    {

        internal ElementType(string classname): base(classname)
        {
        }

        internal void AddMethod(string name, MethodType.Callback del,  ArgumentType a=null, ArgumentType b=null, ArgumentType c=null, ArgumentType d=null)
        {

            if (LookupMethod(name)!=null)
                throw new ArgumentException("Method names must be unique");

            MethodType m = new MethodType(name, del, this);

            if (a != null)
                m.Args.Add(a);

            if (b != null)
                m.Args.Add(b);

            if (c != null)
                m.Args.Add(c);

            if (d != null)
                m.Args.Add(d);


            _methods.Add(name, m);


        }


        internal MethodType LookupMethod(string key)
        {
            MethodType target;

            if (_methods.TryGetValue(key, out target))
                return target;

            return null;
        }
    }
}
