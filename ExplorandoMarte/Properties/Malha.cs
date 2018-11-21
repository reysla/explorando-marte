using System;
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

        public Malha(int limiteX, int limiteY)
        {
            this.limiteX = limiteX;
            this.limiteY = limiteY;
        }
    }
}
