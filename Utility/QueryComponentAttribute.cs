using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade {

    /// <summary>
    /// Indicates that the decorated element can be part of a search query, and defines what name should be used as a key or value.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    sealed class QueryComponentAttribute : Attribute {

        ///<summary>
        ///The name of the key or value, depending on context
        ///</summary>
        public string Name { get; }

        /// <summary>
        /// Whether the key or value should be ignored during parsing, eg. when the value is just a placeholder
        /// </summary>
        public bool Ignore { get; }

        public QueryComponentAttribute(string name, bool ignore = false) {
            Name = name;
            Ignore = ignore;
        }
    }
}
