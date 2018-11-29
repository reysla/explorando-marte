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

        public Malha Malha { get; }

        public Direcao frente;

        public Sonda(Malha malha, int posicaoInicialX, int posiciaoInicialY, char frenteInicial)
        {
            this.Malha = malha;

            if (posicaoInicialX > malha.LimiteX || posiciaoInicialY > malha.LimiteY) 
            {
                throw new ArgumentOutOfRangeException("Posição inválida.");
            }

            //if (this.Malha.Posicoes.VerficarPosicaoOcupada() == true)
            //{
            //    throw new PosicaoIndisponivelException(posicaoInicialX, posiciaoInicialY);
            //}

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

            malha.BuscarPosicao(posicaoInicialX, posiciaoInicialY).Sonda = this;
        }

        public override string ToString()
        {
            return $"{this.PosicaoX} {this.PosicaoY} {this.frente}";
        }
    }
}
