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

        internal Posicao BuscarPosicao(Posicao posicao)
        {
            foreach (var item in this.Posicoes)
            {
                if (item.CoordenadaX == posicao.CoordenadaX && item.CoordenadaY == posicao.CoordenadaY)
                {
                    return posicao;
                }
            }
            throw new Exception("Posição inválida.");
        }

        internal Posicao BuscarPosicao(Sonda sonda)
        {
            var posicao = new Posicao(sonda.PosicaoX, sonda.PosicaoY);

            return BuscarPosicao(posicao);
        }

        //internal Posicao BuscarPosicao(int[] coordenada)
        //{
        //    return this.dicionarioPosicoes[coordenada];
        //}

        public void ImprimirPosicoes()
        {
            foreach (var item in Posicoes)
            {
                Console.Write(item.CoordenadaX + " " + item.CoordenadaY);
                if (item.Sonda == null)
                {
                    Console.WriteLine(" Não possui sonda");
                }
                else
                {
                    Console.WriteLine(" " + item.Sonda);
                }
            }

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
        }
    }
}
