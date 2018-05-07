using System;

namespace P2M_Operations_Entities
{
    public  class Currency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double PointValue_Rate  { get; set; }
        public double USDRate { get; set; }
        public string ISO { get; set; }
    }
}
