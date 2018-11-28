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
            var malha = new Malha(5, 7);

            var sonda = new Sonda(malha, 3, 6, 'N');
            Console.WriteLine("Sonda criada com sucesso.");

            var sonda2 = new Sonda(malha, 2, 4, 'S');
            Console.WriteLine("Sonda criada com sucesso.");

            var sonda3 = new Sonda(malha, 3, 6, 'E');

            Console.ReadLine();
        }
    }
}
