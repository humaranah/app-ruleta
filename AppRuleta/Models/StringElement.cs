using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRuleta.Models
{
    [Serializable]
    public class StringElement
    {
        public string Value { get; set; }

        public StringElement()
        {
            Value = "";
        }

        public StringElement(string value)
        {
            Value = value;
        }
    }
}
