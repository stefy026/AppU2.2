using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2._2
{
    class Program
    {
        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n== CATÁLOGO DE RECURSIVIDAD ==");
                Console.WriteLine("1. Factorial\n2. Fibonacci\n3. Torres de Hanoi\n4. Suma de un arreglo\n5. Búsqueda lineal\n0. Salir");
                opcion = LeerEntero("Opción: ", 0, 5);
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        int n = LeerEntero("Número (0 a 20): ", 0, 20);
                        Console.WriteLine($"{n}! = {Factorial(n)}");
                        break;
                    case 2:
                        int cantidad = LeerEntero("Cantidad de términos (1 a 50): ", 1, 50);
                        Fibonacci(cantidad, 0, 1);
                        Console.WriteLine();
                        break;
                    case 3:
                        int discos = LeerEntero("Número de discos (1 a 10): ", 1, 10);
                        Hanoi(discos, 'A', 'C', 'B');
                        Console.WriteLine($"Total de movimientos: 2^{discos} - 1 = {(1 << discos) - 1}");
                        break;
                    case 4:
                        int[] datos = LeerArreglo();
                        Console.WriteLine($"Suma de los elementos: {Suma(datos, 0)}");
                        break;
                    case 5:
                        int[] lista = LeerArreglo();
                        int buscado = LeerEntero("Valor a buscar: ", -1000, 1000);
                        int posicion = Buscar(lista, buscado, 0);
                        Console.WriteLine(posicion == -1 ? "El valor no se encontró." : $"El valor está en la posición {posicion}.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.Write("\n Presione Enter para volver al menú...");
                    Console.ReadLine();
                }
            } while (opcion != 0);
        }

        // Caso base: n <= 1 devuelve 1. Caso recursivo: n * Factorial(n - 1)
        static long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        // Caso base: cantidad == 0. Caso recursivo: imprime 'actual' y avanza con (siguiente, actual + siguiente)
        static void Fibonacci(int cantidad, long actual, long siguiente)
        {
            if (cantidad == 0) return;
            Console.Write(actual + " ");
            Fibonacci(cantidad - 1, siguiente, actual + siguiente);
        }

        // Caso base: discos == 0. Caso recursivo: mover n-1 al auxiliar, mover el disco n, mover n-1 al destino
        static void Hanoi(int discos, char origen, char destino, char auxiliar)
        {
            if (discos == 0) return;
            Hanoi(discos - 1, origen, auxiliar, destino);
            Console.WriteLine($"Mover disco {discos} de {origen} a {destino}");
            Hanoi(discos - 1, auxiliar, destino, origen);
        }

        // Caso base: indice == longitud. Caso recursivo: arreglo[indice] + Suma(resto)
        static int Suma(int[] arreglo, int indice)
        {
            if (indice == arreglo.Length) return 0;
            return arreglo[indice] + Suma(arreglo, indice + 1);
        }

        // Caso base: indice == longitud (no está) o arreglo[indice] == valor (encontrado). Caso recursivo: buscar en indice + 1
        static int Buscar(int[] arreglo, int valor, int indice)
        {
            if (indice == arreglo.Length) return -1;
            if (arreglo[indice] == valor) return indice;
            return Buscar(arreglo, valor, indice + 1);
        }

        static int[] LeerArreglo()
        {
            int[] arreglo = new int[LeerEntero("Tamaño del arreglo (1 a 10): ", 1, 10)];
            for (int i = 0; i < arreglo.Length; i++)
                arreglo[i] = LeerEntero($"Elemento [{i}]: ", -1000, 1000);
            return arreglo;
        }

        static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < minimo || valor > maximo)
                Console.Write($"Entrada inválida. Escriba un entero entre {minimo} y {maximo}: ");
            return valor;
        }
    }
}