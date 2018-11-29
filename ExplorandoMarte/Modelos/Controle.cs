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
                        sonda.Malha.ImprimirPosicoes();
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
            int novaCoordenadaY;
            int novaCoordenadaX;
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    novaCoordenadaY = sonda.PosicaoY + 1;
                    if (novaCoordenadaY <= sonda.Malha.LimiteY && sonda.VerficarPosicaoVazia(sonda.PosicaoX, novaCoordenadaY))
                    {
                        Console.WriteLine("Movimento permitido. " + sonda);
                    }
                    break;
                case Direcao.SOUTH:
                    novaCoordenadaY = sonda.PosicaoY - 1;
                    if (novaCoordenadaY >= 0 && sonda.VerficarPosicaoVazia(sonda.PosicaoX, novaCoordenadaY))
                    {
                        Console.WriteLine("Movimento permitido. " + sonda);
                    }
                    break;
                case Direcao.EAST:
                    novaCoordenadaX = sonda.PosicaoX + 1;
                    if (novaCoordenadaX <= sonda.Malha.LimiteX && sonda.VerficarPosicaoVazia(novaCoordenadaX, sonda.PosicaoY))
                    {
                        Console.WriteLine("Movimento permitido. " + sonda);
                    }
                    break;
                case Direcao.WEST:
                    novaCoordenadaX = sonda.PosicaoX - 1;
                    if (novaCoordenadaX >= 0 && sonda.VerficarPosicaoVazia(novaCoordenadaX, sonda.PosicaoY))
                    {
                        Console.WriteLine("Movimento permitido. " + sonda);
                    }
                    break;
            }
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

        public static bool VerficarPosicaoVazia(this Sonda sonda, int coordenadaX, int coordenadaY)
        {
            var posicao = sonda.Malha.BuscarPosicao(coordenadaX, coordenadaY);

            if (posicao == null)
            {
                throw new PosicaoInvalidaException("Coordenadas inválidas.");
            }

            if (posicao.Sonda != null)
            {
                return false;
            }

            return true;
            //return posicoes.Any(posicao => posicao.Sonda != null);
        }
    }
}
