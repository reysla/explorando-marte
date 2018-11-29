using System;
using System.Collections.Generic;
using ExplorandoMarte.Modelos;
using ExplorandoMarte.Properties;

namespace ExplorandoMarte
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var malha = new Malha(5, 5);

            var sonda1 = new Sonda(malha, 1, 2, 'N');
            
            malha.LerComandos(sonda1, "LMLMLMLMM");

            var sonda2 = new Sonda(malha, 3, 3, 'E');
            malha.LerComandos(sonda2, "MMRMMRMRRM");

            Console.WriteLine(sonda1);
            Console.WriteLine(sonda2);

            Console.ReadLine();
        }
    }
}
