using ExplorandoMarte.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplorandoMarte.Properties
{
    public static class Controle
    {
        public static void LerComandos(this Malha malha, Sonda sonda, string comandos)
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
                        malha.ImprimirPosicoes();
                        break;
                    case 'M':
                        malha.Mover(sonda);
                        break;
                    default:
                        throw new ArgumentException("Comando não suportado.", nameof(comandos));
                }
            }
        }

        public static void Mover(this Malha malha, Sonda sonda)
        {
            Posicao novaPosicao;
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    novaPosicao = new Posicao(sonda.PosicaoY + 1, sonda.PosicaoX);
                    if (!malha.VerificarSePosicaoValida(novaPosicao))
                    {
                        throw new MovimentoNaoPermitidoException("Movimento inválido.");
                    }
                    Console.WriteLine("Movimento permitido. Posicao atual: " + sonda);
                    malha.AtualizarPosicoes(sonda, novaPosicao);
                    Console.WriteLine("Nova posição: " + sonda);
                    break;
                case Direcao.SOUTH:
                    novaPosicao = new Posicao(sonda.PosicaoY - 1, sonda.PosicaoX);
                    if (malha.VerificarSePosicaoValida(novaPosicao))
                    {
                        throw new MovimentoNaoPermitidoException("Movimento inválido.");
                    }
                    Console.WriteLine("Movimento permitido. Posicao atual: " + sonda);
                    malha.AtualizarPosicoes(sonda, novaPosicao);
                    Console.WriteLine("Nova posição: " + sonda);
                    break;
                case Direcao.EAST:
                    novaPosicao = new Posicao(sonda.PosicaoY, sonda.PosicaoX + 1);
                    if (malha.VerificarSePosicaoValida(novaPosicao))
                    {
                        throw new MovimentoNaoPermitidoException("Movimento inválido.");
                    }
                    Console.WriteLine("Movimento permitido. Posicao atual: " + sonda);
                    malha.AtualizarPosicoes(sonda, novaPosicao);
                    Console.WriteLine("Nova posição: " + sonda);
                    break;
                case Direcao.WEST:
                    novaPosicao = new Posicao(sonda.PosicaoY, sonda.PosicaoX - 1);
                    if (malha.VerificarSePosicaoValida(novaPosicao))
                    {
                        throw new MovimentoNaoPermitidoException("Movimento inválido.");
                    }
                    Console.WriteLine("Movimento permitido. Posicao atual: " + sonda);
                    malha.AtualizarPosicoes(sonda, novaPosicao);
                    Console.WriteLine("Nova posição: " + sonda);
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

        public static bool VerficarPosicaoVazia(this Malha malha, Posicao posicao)
        {
            var p = malha.BuscarPosicao(posicao);

            if (p == null)
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

        internal static void AtualizarPosicoes(this Malha malha, Sonda sonda, Posicao novaPosicao)
        {
            malha.BuscarPosicao(sonda).Sonda = null;
            novaPosicao.Sonda = sonda;
            sonda.PosicaoX = novaPosicao.CoordenadaX;
            sonda.PosicaoY = novaPosicao.CoordenadaY;
        }

        public static bool VerificarSePosicaoValida(this Malha malha, Posicao posicao)
        {
            foreach (var item in malha.Posicoes)
            {
                if (item.CoordenadaX != posicao.CoordenadaX || item.CoordenadaY != posicao.CoordenadaY || malha.VerficarPosicaoVazia(posicao))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
