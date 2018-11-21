using System;
using System.Collections.Generic;

namespace ExplorandoMarte.Properties
{
    public class Malha
    {
        public int limiteX
        {
            get;
            private set;
        }

        public int limiteY
        {
            get;
            private set;
        }

        public List<Sonda> sondas = new List<Sonda>();

        public Malha(int limiteX, int limiteY)
        {
            this.limiteX = limiteX;
            this.limiteY = limiteY;
        }

        public void AdicionarSonda(Sonda sonda) {
            foreach (var item in sondas)
            {
                if (!Controle.VerificarSePosicaoVazia(this, sonda.posicaoX, sonda.posicaoY)) {
                    throw new Exception("Posição indisponível.");
                }

                sondas.Add(sonda);
            }
        }
    }
}
