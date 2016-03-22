using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    internal class CodeBlock : IEnumerable<Instruction>
    {
        private List<Instruction> _code = new List<Instruction>();
        
        internal void Insert(Instruction i)
        {
            _code.Add(i);
        }



        public int InstructionCount
        {
            get { return _code.Count; }
        }

        public IEnumerator<Instruction> GetEnumerator()
        {
            return _code.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _code.GetEnumerator(); 
        }
    }



    internal class Program
    {
        private CodeBlock _main;
        private CodeBlock _ptr;

        internal Program()
        {
            //instantiate a default codeblock
            _main = new CodeBlock();
            _ptr = _main;
        }

        #region Properties

        internal CodeBlock Main
        {
            get
            {
                return _main;
            }
        }

        #endregion


        #region CodeBuilders
        internal void Insert(Instruction i)
        {
            _ptr.Insert(i);
        }

        internal void Push(CodespaceElement el)
        {
            Insert(Instruction.Push(el));
        }
        

        internal void Push(int x)
        {
            Insert(Instruction.Push(x));
        }

        internal void Push(string s)
        {

            Insert(Instruction.Push(s));
        }

        internal void Push(double d)
        {
            Insert(Instruction.Push(d));
        }

        internal void Push(bool b)
        {
            Insert(Instruction.Push(b));
        }

        internal void Invoke(MethodType m)
        {
            Insert(Instruction.MethodCall(m));
        }
        #endregion



    }
}
