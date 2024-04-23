using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLogger.Domain.Entities
{
    public class Logger
    {
        public string NomeAplicacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOperacao { get; set; }
        public string Usuario { get; set; }
    }
}
