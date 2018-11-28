﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    public class Posicao
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }
        public bool Ocupada { get; set; }

        public Posicao(int coordenadaX, int coordenadaY)
        {
            this.CoordenadaX = coordenadaX;
            this.CoordenadaY = coordenadaY;
            Ocupada = false;
        }
    }
}