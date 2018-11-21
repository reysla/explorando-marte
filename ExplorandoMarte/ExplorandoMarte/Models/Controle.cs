using System;
using System.Collections.Generic;

namespace ExplorandoMarte.Properties
{
    public class Controle
    {
        void LerComandos(Malha malha, Sonda sonda, string comandos)
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
                        Mover(malha, sonda);
                        break;
                    default:
                        throw new ArgumentException("Comando não suportado.", nameof(comandos));
                }
            }
        }

        public void Mover(Malha malha, Sonda sonda)
        {
            if (malha.sondas.Contains(sonda) && VerificarSePosicaoVazia(malha, sonda.posicaoX, sonda.posicaoY)) 
            {

                switch (sonda.frente)
                {
                    case Direcao.NORTH:
                        sonda.posicaoY++;
                        break;
                    case Direcao.SOUTH:
                        sonda.posicaoY--;
                        break;
                    case Direcao.EAST:
                        sonda.posicaoX++;
                        break;
                    case Direcao.WEST:
                        sonda.posicaoX--;
                        break;
                }
            }

            }

        public void GirarDireita(Sonda sonda)
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

        public void GirarEsquerda(Sonda sonda) {
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

        public static bool VerificarSePosicaoVazia(Malha malha, int coordenadaX, int coordenadaY) 
        {
            if (malha.sondas != null && coordenadaX <= malha.limiteX && coordenadaX >= 0 && coordenadaY <= malha.limiteY && coordenadaY >= 0) 
            {
                foreach (var sonda in malha.sondas)
                {
                    if (sonda.posicaoX == coordenadaX && sonda.posicaoY == coordenadaY) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
