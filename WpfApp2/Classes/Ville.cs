using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    [Table("Ville")]
    public class Ville
    {
       
        public int ID { get; set; }
        
        public string Nom { get; set; }
        
        public double X { get; set; }

        public double Y { get; set; }

        public Ville() { }

        public Ville(string nom, double x, double y)
        {
            Nom = nom;
            X = x;
            Y = y;
        }

        public Ville(int id, string nom, double x, double y)
        {
            ID = id;
            Nom = nom;
            X = x;
            Y = y;
        }

    }
}
