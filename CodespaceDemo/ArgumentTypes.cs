using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    internal abstract class ArgumentType
    {
        private Type _argype;
        private object _defaultValue;
        public string Name { get; set; }


        protected ArgumentType(Type t, string name, object defaultvalue = null)
        {
            _argype = t;
            Name = name;
            _defaultValue = defaultvalue;
        }


        internal Type ArgType { get { return _argype; } }

        /*
        public override string ToString()
        {
            return _value.ToString();
        }
        */
    }



    internal class StringArgumentType : ArgumentType
    {
        internal StringArgumentType(string name)
            : base(typeof(String), name, null)
        {
        }

    }


    internal class MethodCallArgumentType : ArgumentType
    {
        internal MethodCallArgumentType(MethodType m)
            : base(typeof(MethodType), m.PublicName, null)
        {
        }

    }

    internal class ElementArgumentType : ArgumentType
    {

        internal ElementArgumentType(string name):
            base(typeof(CodespaceElement), name, null)
        {
        }

        /*
        internal CodespaceElement ToElement 
        {
            get { return _value as CodespaceElement; }
        }*/
    }

    #region ScalarTypes
    internal abstract class ScalarArgumentType : ArgumentType
    {
        protected ScalarArgumentType(Type t, string name, int defaultvalue = 0): base (t,name,defaultvalue)
        {

        }


    }

    internal class EnumArgumentType<T> : ScalarArgumentType
    {
        internal EnumArgumentType(string name)
            : base(typeof(T), name, 0)
        {

        }

        /*
        internal T ToEnum()
        {
            return (T) Enum.Parse(typeof(T), _value.ToString(), true);
        }*/
    }


    internal class IntArgumentType : ScalarArgumentType
    {
        internal IntArgumentType(string name, int defaultvalue = 0)
            : base(typeof(Int32),name, defaultvalue)
        {

        }

        /*
        internal int ToInt32()
        {
            return (int)_value;
        }
        */

        /*
        internal static int Unpack(ArgumentType argument)
        {
            var ia = argument as IntArgument;
            if (ia == null)
               throw new ArgumentException("Int32 argument expected");

            return ia.ToInt32();
        }*/

    }

    internal class DoubleArgumentType : ScalarArgumentType
    {
        internal DoubleArgumentType(string name, int defaultvalue = 0)
            : base(typeof(Double), name, defaultvalue)
        {

        }

        /*
        internal double ToDouble()
        {
            return (double)_value;
        }*/
    }

    internal class BoolArgumentType : ScalarArgumentType
    {
        internal BoolArgumentType(string name, bool defaultvalue = false)
            : base(typeof(Boolean), name, defaultvalue?1:0)
        {

        }


        /*
        internal bool ToBool()
        {
            return IsTrue;
        }
        */


        /*
        internal bool IsTrue
        {
            get { return 1 == (int)_value; }
        }
         */
 
        /*
        internal bool IsFalse
        {
            get { return 0 == (int)_value; }
        }*/

        /*
        internal virtual string ToString()
        {
            return IsTrue ? "true" : "false";
        }*/


    }
    #endregion

}
