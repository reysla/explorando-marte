using ExplorandoMarte.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    public static class Gerenciador
    {
        public static bool VerficarPosicaoOcupada(this List<Posicao> posicoes)
        {
            //for (int i = 0; i <= malha.LimiteX; i++)
            //{
            //    for (int j = 0; j <= malha.LimiteY; j++)
            //    {
            //        if (malha.Posicoes[i, j])
            //        {
            //            return false;
            //        }

            //    }
            //}

            //foreach (var posicao in posicoes)
            //{
            //    if (posicao.Ocupada)
            //    {
            //        return true;
            //    }
            //}

            //return false;

            return posicoes.Any(posicao => posicao.Sonda == null);
        }

        public static void VerificarSeMovimentoValido(this Sonda sonda)
        {
            if (sonda.posicaoY + 1 > sonda.Malha.LimiteY || sonda.Malha.Posicoes.VerficarPosicaoOcupada())
            {
                throw new Exception("Movimento não pertmitido");
            }
        }

        public static void AtualizarPosicao(this Sonda sonda)
        {
            switch (sonda.frente)
            {
                case Direcao.NORTH:
                    sonda.VerificarSeMovimentoValido();
                    sonda.PosicaoComSonda();
                    sonda.posicaoY++;
                    sonda.PosicaoSemSonda();
                    break;
                case Direcao.SOUTH:
                    sonda.VerificarSeMovimentoValido();
                    sonda.PosicaoComSonda();
                    sonda.posicaoY--;
                    sonda.PosicaoSemSonda();
                    break;
                case Direcao.EAST:
                    sonda.VerificarSeMovimentoValido();
                    sonda.PosicaoComSonda();
                    sonda.posicaoX++;
                    sonda.PosicaoSemSonda();
                    break;
                case Direcao.WEST:
                    sonda.VerificarSeMovimentoValido();
                    sonda.PosicaoComSonda();
                    sonda.posicaoX--;
                    sonda.PosicaoSemSonda();
                    break;
            }
        }

        private static void PosicaoComSonda(this Sonda sonda)
        {
            sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Sonda = null;
        }

        private static void PosicaoSemSonda(this Sonda sonda)
        {
            sonda.Malha.BuscarPosicao(sonda.posicaoX, sonda.posicaoY).Sonda = sonda;
        }
    }
}
