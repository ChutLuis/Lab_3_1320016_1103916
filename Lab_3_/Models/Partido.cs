using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_3_.Models
{
    public class Partido
    {
        public Value valor{get;set;}
        public Partido izquierdo{get;set;}
        public Partido derecho{get;set;}


        public class Value
        {
            public int NoPartido { get; set; }
        public DateTime FechaPartido { get; set; }
        public string Grupo { get; set; }
        public string Pais1 { get; set; }
        public string Pais2 { get; set; }
        public string Estadio { get; set; }
        }

    }
}