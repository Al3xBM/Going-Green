﻿using System;

namespace FormGenerator.Entities
{
    public class BaseProduct
    {
        public Guid ID { get; set; }

        public string Brand { get; set; }

        public string Series { get; set; }

        public string Consumption { get; set; }

        public string EnergyClass { get; set; }

        public string Colour { get; set; }

        public float Weight { get; set; }

    }
}
