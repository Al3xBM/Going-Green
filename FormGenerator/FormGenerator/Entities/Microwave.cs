using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormGenerator.Entities
{
    public class Microwave : BaseProduct
    {
        public string Volume { get; set; }

        public string Power { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        public string Depth { get; set; }
    }
}
