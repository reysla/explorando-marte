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
            Console.WriteLine("Malha criada.");
            malha.ImprimirPosicoes();



            var sonda1 = new Sonda(malha, 1, 2, 'N');
            Console.WriteLine("Sonda1 criada.");
            

            malha.ImprimirPosicoes();

            sonda1.LerComandos("LMLMLMLMM");
            //Console.WriteLine("Movimentos feitos com sucesso.");

            //var sonda2 = new Sonda(malha, 3, 3, 'E');
            //sonda2.LerComandos("MMRMMRMRRM");

            //Console.WriteLine(sonda1);
            //Console.WriteLine(sonda2);

            Console.ReadLine();
        }
    }
}
