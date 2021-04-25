using System;

namespace FormGenerator.Entities
{
    public class Television : BaseProduct
    {
        public float Diagonal { get; set; }

        public string Resolution { get; set; }
    
        public Boolean IsSmart { get; set; }
    }
}
