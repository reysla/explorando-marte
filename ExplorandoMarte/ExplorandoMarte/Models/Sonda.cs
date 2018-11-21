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

        public Direcao frente;

        public Sonda(Malha malha, int posicaoInicialX, int posiciaoInicialY, char frenteInicial)
        {
            if (posicaoInicialX <= malha.limiteX && posicaoInicialX >= 0 && posiciaoInicialY <= malha.limiteY && posiciaoInicialY >= 0) 
            {
                this.posicaoX = posicaoInicialX;
                this.posicaoY = posiciaoInicialY;

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
                else
                {
                    throw new ArgumentException("Coordenadas fora dos limites da malha.");
                }

                malha.AdicionarSonda(this);
            }
        }
    }
}
