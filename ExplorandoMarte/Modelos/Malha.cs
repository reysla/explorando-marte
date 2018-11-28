using ExplorandoMarte.Modelos;
using System;
using System.Collections.Generic;

namespace ExplorandoMarte.Properties
{
    public class Malha
    {
        public int LimiteX
        {
            get;
            private set;
        }

        public int LimiteY
        {
            get;
            private set;
        }

        public List<Posicao> Posicoes { get; }

        //public IDictionary<int[], Posicao> dicionarioPosicoes = new Dictionary<int[], Posicao>();

        //public bool[,] Posicoes { get; set; }

        public Malha(int limiteX, int limiteY)
        {
            this.LimiteX = limiteX;
            this.LimiteY = limiteY;

            //for (int i = 0; i < (LimiteX * LimiteY); i++)
            //{
            //    Posicoes = 
            //}

            this.Posicoes = new List<Posicao>();
            Posicao posicao;

            for (int i = 0; i <= LimiteX; i++)
            {
                for (int j = 0; j <= LimiteY; j++)
                {
                    posicao = new Posicao(i, j);
                    this.Posicoes.Add(posicao);
                }
            }
            //Posicoes = new bool[LimiteX + 1, LimiteY + 1];

            //for (int i = 0; i <= LimiteX; i++)
            //{
            //    for (int j = 0; j <= LimiteY; j++)
            //    {
            //        Posicoes[i, j] = false;
            //    }
            //}
        }

        internal Posicao BuscarPosicao(int coordenadaX, int coordenadaY)
        {
            foreach (var posicao in this.Posicoes)
            {
                if (posicao.CoordenadaX == coordenadaX && posicao.CoordenadaY == coordenadaY)
                {
                    return posicao;
                }
            }
            throw new Exception("Posição inválida.");
        }

        //internal Posicao BuscarPosicao(int[] coordenada)
        //{
        //    return this.dicionarioPosicoes[coordenada];
        //}

        public void ImprimirPosicoes()
        {
            foreach (var item in Posicoes)
            {
                Console.WriteLine(item.CoordenadaX + " " + item.CoordenadaY);
            }
        }
    }
}
