﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ENTITY
{
    internal class EKITAPYAZAR
    {
        public int ID { get; set; }
        public string kitapAdi { get; set; }
        public int sayfaSayisi { get; set; }
        public DateTime eklenmeTarihi { get; set; }
        public int yazarID { get; set; }
        public string yazarAdi { get; set; }
        public string yazarSoyadi { get; set; }
    }
}
