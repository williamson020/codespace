using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodespaceDemo
{

    /// <summary>
    /// Loaded module - a collection of linked or related Codespaces
    /// </summary>
    public class Module : IEnumerable
    {

        private Dictionary<string, Codespace> _spaces = new Dictionary<string, Codespace>();


        public Module()
        {

        }


        public Codespace Lookup()
        {
            throw new NotImplementedException();
        }


        public IEnumerator GetEnumerator()
        {
            return _spaces.GetEnumerator();
        }
    }
}
