using ExplorandoMarte.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplorandoMarte.Properties
{
    public static class Controle
    {
        public static void LerComandos(this Sonda sonda, string comandos)
        {
            comandos = comandos.ToUpper();
            foreach (var item in comandos)
            {
                switch (item)
                {
                    case 'R':
                        GirarDireita(sonda);
                        Console.WriteLine("Girou pra direita.");
                        break;
                    case 'L':
                        GirarEsquerda(sonda);
                        Console.WriteLine("Girou pra esquerda.");
                        break;
                    case 'M':
                        Mover(sonda);
                        break;
                    default:
                        throw new ArgumentException("Comando não suportado.", nameof(comandos));
                }
            }
        }

        public static void Mover(this Sonda sonda)
        {
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    if (sonda.PosicaoY + 1 >= sonda.Malha.LimiteY || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    Console.WriteLine("Movimento feito.");
                    sonda.PosicaoSemSonda();
                    sonda.PosicaoY++;
                    sonda.PosicaoComSonda();
                    break;
                case Direcao.SOUTH:
                    if (sonda.PosicaoY - 1 < 0 || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    Console.WriteLine("Movimento feito.");
                    sonda.PosicaoSemSonda();
                    sonda.PosicaoY--;
                    sonda.PosicaoComSonda();
                    break;
                case Direcao.EAST:
                    if (sonda.PosicaoX + 1 >= sonda.Malha.LimiteX || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    Console.WriteLine("Movimento feito.");
                    sonda.PosicaoSemSonda();
                    sonda.PosicaoX++;
                    sonda.PosicaoComSonda();
                    break;
                case Direcao.WEST:
                    if (sonda.PosicaoX - 1 < 0 || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    Console.WriteLine("Movimento feito.");
                    sonda.PosicaoSemSonda();
                    sonda.PosicaoX--;
                    sonda.PosicaoComSonda();
                    break;
            }
        }

        private static void PosicaoComSonda(this Sonda sonda)
        {
            sonda.Malha.BuscarPosicao(sonda.PosicaoX, sonda.PosicaoY).Sonda = null;
        }

        private static void PosicaoSemSonda(this Sonda sonda)
        {
            sonda.Malha.BuscarPosicao(sonda.PosicaoX, sonda.PosicaoY).Sonda = sonda;
        }

        public static void GirarDireita(this Sonda sonda)
        {
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    sonda.frente = Direcao.EAST;
                    break;
                case Direcao.EAST:
                    sonda.frente = Direcao.SOUTH;
                    break;
                case Direcao.SOUTH:
                    sonda.frente = Direcao.WEST;
                    break;
                case Direcao.WEST:
                    sonda.frente = Direcao.NORTH;
                    break;
            }
        }

        public static void GirarEsquerda(this Sonda sonda)
        {
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    sonda.frente = Direcao.WEST;
                    break;
                case Direcao.EAST:
                    sonda.frente = Direcao.NORTH;
                    break;
                case Direcao.SOUTH:
                    sonda.frente = Direcao.EAST;
                    break;
                case Direcao.WEST:
                    sonda.frente = Direcao.SOUTH;
                    break;
            }
        }

        public static bool VerficarPosicaoOcupada(this List<Posicao> posicoes)
        {
            return posicoes.Any(posicao => posicao.Sonda != null);
        }
    }
}
