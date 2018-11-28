using ExplorandoMarte.Modelos;
using System;
namespace ExplorandoMarte.Properties
{
    public class Sonda
    {
        public int posicaoX
        {
            get;
            set;
        }

        public int posicaoY
        {
            get;
            set;
        }

        public Malha Malha { get; }

        public Direcao frente;

        public Sonda(Malha malha, int posicaoInicialX, int posiciaoInicialY, char frenteInicial)
        {
            this.Malha = malha;

            if (posicaoInicialX > malha.LimiteX || posiciaoInicialY > malha.LimiteY) 
            {
                throw new ArgumentOutOfRangeException("Posição inválida.");
            }

            if (this.Malha.Posicoes.VerficarPosicaoOcupada() == true)
            {
                throw new PosicaoIndisponivelException(posicaoInicialX, posiciaoInicialY);
            }

            //this.posicaoX = posicaoInicialX;
            //this.posicaoY = posiciaoInicialY;

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

            //malha.Posicoes[posicaoInicialX, posiciaoInicialY] = true;

            malha.BuscarPosicao(posicaoInicialX, posiciaoInicialY).Sonda = this;
        }
    }
}
