using System.Collections.Generic;

namespace NOVOROV.Models
{
    public class LogProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<LogAttribute> LogAttributes { get; set; }
    }
}
