using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodespaceDemo
{
    internal class Instruction
    {

        internal enum OpType {  OpPush, OpPop, OpMethodCall }

        private object _operand;

        private OpType _optype;


        internal Instruction(OpType operation, object operand)
        {
            _optype = operation;
            _operand = operand;
        
        }


        #region Properties

        internal OpType OperationType { get { return _optype; } }

        internal object Operand { get { return _operand ; } }

        #endregion
        
        #region Statics
        internal static Instruction Push(object operand)
        {
            return new Instruction(OpType.OpPush, operand);
        }

        internal static Instruction MethodCall(MethodType operand)
        {
            return new Instruction(OpType.OpMethodCall, operand);
        }
        #endregion


    }
}
