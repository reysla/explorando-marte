using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExplorandoMarte.Modelos
{
    class PosicaoInvalidaException : Exception
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }

        public PosicaoInvalidaException() { }

        public PosicaoInvalidaException(int posicaoX, int posicaoY) : this($"Posição com coordenadas {posicaoX} e {posicaoY} não existe.")
        {
            this.CoordenadaX = posicaoX;
            this.CoordenadaY = posicaoY;
        }

        public PosicaoInvalidaException(string mensagem) : base(mensagem) { }
    }
}