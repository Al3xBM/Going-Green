using System;

namespace FormGenerator.Entities
{
    public class Fridge : BaseProduct
    {
        public float Height { get; set; }

        public float Width { get; set; }

        public float Depth { get; set; }

        public float Volume { get; set; }

        public int Doors { get; set; }

        public Boolean HasFreezer { get; set; }
    }
}
