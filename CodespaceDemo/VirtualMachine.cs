using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{
    public class VirtualMachine
    {

        private Codespace _codespace;

        public VirtualMachine(Codespace cs)
        {
            _codespace = cs;

        }

        public void Execute()
        {
            Load(_codespace.TheProgram);
            Run();
        }

        private void Run()
        {
            
        }

        private void Load(Program program)
        {
            
        }



    }
}
