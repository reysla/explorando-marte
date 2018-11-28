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

            return posicoes.Any(p => p.Ocupada);
        }
    }
}
