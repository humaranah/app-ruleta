using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRuleta.Models
{
    [Serializable]
    public class Premio
    {
        public bool EsPremio { get; set; }
        public string Valor { get; set; }

        public Premio()
        {
            EsPremio = false;
            Valor = "";
        }

        public Premio(string valor, bool esPremio)
        {
            Valor = valor;
            EsPremio = esPremio;
        }
    }
}
