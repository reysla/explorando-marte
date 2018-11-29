using ExplorandoMarte.Properties;
using ExplorandoMarte.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Modelos
{
    public static class Menu
    {
        public static void ImprimirMenu()
        {
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1. Criar malha.");
            Console.WriteLine("2. Colocar nova sonda.");
            Console.WriteLine("3. Mover sonda.");
        }

        public static Malha CriarMalha()
        {
            Console.WriteLine("Digite os limites X e Y da malha, separados por espaço. EX: 10 10");
            string comando = Console.ReadLine();

            char[] coordenadas = comando.Remove(' ').ToCharArray();
            return new Malha(coordenadas[0], coordenadas[1]);
        }

        public static void ColocarSonda(this Malha malha)
        {
            bool keepLooping = false;
            char[] comandos = new char[3];

            while (keepLooping)
            {
                Console.WriteLine("Digite as coordenadas X e Y e a direção da sonda (N, S, E, W).");
                string comando = Console.ReadLine();
                comandos = comando.Remove(' ').ToCharArray();
            
                if (!int.TryParse(comandos[0].ToString(), out int coordenadaX) && !int.TryParse(comandos[1].ToString(), out int coordenadaY))
                {
                    Console.WriteLine("Digite um valor natural positivo para as coordenadas X e Y. EX: 7 9");
                    keepLooping = true;
                    continue;
                }

                if (!comandos[2].Equals('N') && !comandos[2].Equals('S') && !comandos[2].Equals('E') && !comandos[2].Equals('W'))
                {
                    Console.WriteLine("Direção incorreta. Defina N para Norte, S para Sul, E para Leste ou W para Oeste.");
                    keepLooping = true;
                }
            }

            Sonda sonda = new Sonda(malha, comandos[0], comandos[1], comandos[2]);
        }
    }
}
