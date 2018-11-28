using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    class PosicaoIndisponivelException : Exception
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }

        public PosicaoIndisponivelException() { }

        public PosicaoIndisponivelException(int posicaoX, int posicaoY) : this($"Posição com coordenadas {posicaoX} e {posicaoY} está ocupada.")
        {
            this.CoordenadaX = posicaoX;
            this.CoordenadaY = posicaoY;
        }

        public PosicaoIndisponivelException(string mensagem) : base(mensagem) { }
    }
}
