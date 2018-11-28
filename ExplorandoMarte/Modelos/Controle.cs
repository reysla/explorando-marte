using ExplorandoMarte.Modelos;
using System;
using System.Collections.Generic;

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
                        break;
                    case 'L':
                        GirarEsquerda(sonda);
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
                    if (sonda.posicaoY + 1 > sonda.Malha.LimiteY || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = false;
                    sonda.posicaoY++;
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = true;
                    break;
                case Direcao.SOUTH:
                    if (sonda.posicaoY - 1 < 0 || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = false;
                    sonda.posicaoY--;
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = true;
                    break;
                case Direcao.EAST:
                    if (sonda.posicaoX + 1 <= sonda.Malha.LimiteX || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = false;
                    sonda.posicaoX++;
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = true;
                    break;
                case Direcao.WEST:
                    if (sonda.posicaoX - 1 > 0 || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
                    {
                        Console.WriteLine("Movimento não permitido");
                        break;
                    }
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = false;
                    sonda.posicaoX--;
                    sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Ocupada = true;
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

        public static void GirarEsquerda(this Sonda sonda) {
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
    }
}
