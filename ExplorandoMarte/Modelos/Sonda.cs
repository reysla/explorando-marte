using ExplorandoMarte.Modelos;
using System;
namespace ExplorandoMarte.Properties
{
    public class Sonda
    {
        public int PosicaoX
        {
            get;
            set;
        }

        public int PosicaoY
        {
            get;
            set;
        }

        public Direcao frente;

        public Sonda(Malha malha, int posicaoInicialX, int posiciaoInicialY, char frenteInicial)
        {
            var posicao = new Posicao(posicaoInicialX, posiciaoInicialY);

            if (malha.BuscarPosicao(posicao) == null) 
            {
                throw new PosicaoInvalidaException("Posição inválida.");
            }

            if (malha.VerficarPosicaoVazia(posicao) == false)
            {
                throw new PosicaoIndisponivelException(posicaoInicialX, posiciaoInicialY);
            }

            this.PosicaoX = posicaoInicialX;
            this.PosicaoY = posiciaoInicialY;

            if (frenteInicial == 'N') 
            {
                this.frente = Direcao.NORTH;
            } 
            else if (frenteInicial == 'S') 
            {
                this.frente = Direcao.SOUTH;
            } 
            else if (frenteInicial == 'E') 
            {
                this.frente = Direcao.EAST;
            } 
            else if (frenteInicial == 'W') 
            {
                this.frente = Direcao.WEST;
            }

            malha.BuscarPosicao(posicao).Sonda = this;
        }

        public override string ToString()
        {
            return $"{this.PosicaoX} {this.PosicaoY} {this.frente.ToString().Substring(0, 1)}";
        }
    }
}
