using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    internal class ExecutionBlock
    {
        internal CodeBlock          _codeblock;
        internal int                _instructionPtr = 0;
        private VirtualMachine      _vm;


        

        internal ExecutionBlock(VirtualMachine vm, CodeBlock cb)
        {
            _codeblock = cb;
            _vm = vm;
        }

        internal void Execute()
        {
            var f = _codeblock.GetEnumerator();
            while (f.MoveNext())
            {
                var ins = f.Current;

                switch(ins.OperationType)
                {
                    case Instruction.OpType.OpMethodCall:
                        Invoke(ins.Operand as MethodType);
                        break;

                    case Instruction.OpType.OpPop:

                        //not implemented
                        break;

                    case Instruction.OpType.OpPush:
                        _vm.PushStack(ins.Operand);
                        break;
                }
            }
  
        }

        private void Invoke(MethodType method)
        {
         
            //expected order arg0, arg1, ... , argn, RECEIVER

            object[] operands = new object[method.ArgCount];
            
            int x=0;

            //Pop x arguments from stack...
            while (x < method.ArgCount )
            {
                operands[x++] = _vm.PopStack();
            }

            CodespaceElement receiver = _vm.PopStack() as CodespaceElement;
            if (receiver == null)
                throw new ArgumentException("MISSING CodespaceElement reciever for method call");

            method.Delegate(receiver, operands);

   

        }
    }

    internal class VirtualMachine
    {

        private Codespace _codespace;

        private ExecutionBlock _current;

        private Stack<object> _stack = new Stack<object>();


        internal VirtualMachine(Codespace cs)
        {
            _codespace = cs;

        }


        

        internal void Execute()
        {
            _current = new ExecutionBlock(this, _codespace.TheProgram.Main);

            _current.Execute();
        }

        private void Run()
        {
            _current.Execute();
 
        }

        
        internal object PopStack()
        {
            if (_stack.Count == 0)
                throw new Exception("STACK UNDERFLOW");

            return _stack.Pop();
        }

        internal void PushStack(object obj)
        {
            _stack.Push(obj);
        }



    }
}
