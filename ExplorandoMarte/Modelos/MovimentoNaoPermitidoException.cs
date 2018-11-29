using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    class MovimentoNaoPermitidoException : Exception
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }

        public MovimentoNaoPermitidoException() { }

        public MovimentoNaoPermitidoException(int posicaoX, int posicaoY) : this($"Movimento para a posição {posicaoX} e {posicaoY} não é permitido.")
        {
            this.CoordenadaX = posicaoX;
            this.CoordenadaY = posicaoY;
        }

        public MovimentoNaoPermitidoException(string mensagem) : base(mensagem) { }
    }
}
