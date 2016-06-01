using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRuleta.Models
{
    [Serializable]
    public class Config
    {
        public List<StringElement> Campos { get; set; }
        public List<StringElement> Premios { get; set; }
        public int Intentos { get; set; }
        public string ImagenInicio { get; set; }
        public string FondoFormulario { get; set; }
        public string FondoRuleta { get; set; }
    }
}
