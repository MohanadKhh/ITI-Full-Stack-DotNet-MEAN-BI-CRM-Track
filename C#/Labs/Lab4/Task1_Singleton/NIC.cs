using System;
using System.Collections.Generic;
using System.Text;


namespace Task1_Singleton
{
    internal class NIC
    {
        public string Manufacture { get; set; }
        public string MacAddres { get; set; }
        public NICType Type { get; set; }
        public static NIC Obj { get; } = new();

        private NIC()
        {
            Manufacture = string.Empty;
            MacAddres = string.Empty;
            Type = NICType.ethernet;
        }


    }
}
