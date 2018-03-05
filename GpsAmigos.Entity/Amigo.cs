using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsAmigos.Entity
{
    public class Amigo
    {
        public int id { get; private  set; }
        public string nome {get; private set;}


        public Coordenada coordenada;

        public Amigo() { }

        public Amigo (int id,string nome,double x,double y)
        {
            this.id = id;
            this.nome = nome;
            this.coordenada = new Coordenada(x, y);
            
        }

        public override string ToString()
        {
            return string.Concat(this.id," - ",this.nome.ToString()); 
        }       
    }
}
