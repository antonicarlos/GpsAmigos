using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsAmigos.Entity
{
    public class Coordenada
    {
        public double x { get; set; }

        public double y { get; set; }

        public double distancia { get; set; }

        public Coordenada(double x,double y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Coordenada)
            {
                Coordenada Coord = (Coordenada)obj;
                if((this.x == Coord.x) && (this.y == Coord.y))
                {
                    return true;
                };
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public double CalcularDistancia(Coordenada p2)
        {
            return Math.Sqrt((Math.Pow((p2.x - this.x), 2)) + (Math.Pow((p2.y - this.y), 2)));
        }

        public override string ToString()
        {
            return string.Concat(" Local(", x, ",", y, ")");
        }         

        public string PrintDistancia()
        {
            return string.Concat(this.ToString()," -- Distancia de : ", this.distancia);
        }
    }
}
