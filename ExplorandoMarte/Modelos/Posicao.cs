using ExplorandoMarte.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    public class Posicao
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }
        public Sonda Sonda { get; set; }

        public Posicao(int coordenadaX, int coordenadaY)
        {
            this.CoordenadaX = coordenadaX;
            this.CoordenadaY = coordenadaY;
            Sonda = null;
        }

        public override string ToString()
        {
            return "X: " + CoordenadaX + " Y: " + CoordenadaY + " Sonda: " + Sonda;
        }

        //public override bool Equals(object obj)
        //{
        //    Posicao posicao = obj as Posicao;
        //    if (this.CoordenadaX != posicao.CoordenadaX || this.CoordenadaY != posicao.CoordenadaY)
        //    {
        //        throw new PosicaoInvalidaException("Posição não existe na malha atual.");
        //    }

        //    return true;
        //}
    }
}
