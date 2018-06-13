using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binomial_newton
{
    class Program
    {

        static int Fat(int n) // Método para calcular fatorial de um numero qualquer
        {
            int fat = 1; // Inicialização da variável com 1, que é o último número de uma fatoração qualquer
            if (n == 1) // 1! = 1 
            {
                return 1;
            }

            else // se n for diferente de 1 o método continua a calcular fatoriais de valores diferentes
            {
                for (int i = n; i >= 1; i--) // for para fatorar um número qualquer
                {
                    fat *= i;
                }

                return fat; // retorno do resultado do fatorial de n 
            }
        }


        static double CBinomial(int n, int p) // Método para calcular o Coeficiênte Binomial
        {

            double result; // variável que irá receber o resultado final do coeficiênte 
            result = Fat(n) / (Fat(p) * Fat(n - p)); // Calculo, segundo a fórmula do coeficiênte binomial, foi feita a chamada do método Fat para fatorar n e p.
            return result; // retorno do resultado do coeficiênte binomial 
        }

        static double Desenvolvimento(double a, double b, int n) // Método para calcular o resultado do Binômio
        {
            double resultado = 0; // Acumulador do somatório do binômio
            for (int p = 0; p <= n; p++) // for para o somatório do binômio
            {
                resultado = resultado + (CBinomial(n, p) * (Math.Pow(a, (n - p)) * Math.Pow(b, p))); // formula final para calcular o Binômio
                // onde foi chamado o método CBinomial para calcular o C Binomial em conjunto com o somatório de a,b e n (segundo a fórmula), inicializados no método main
                // pelo usuário para finalmente calcular o resultado de (a+b)^n

            }
            return resultado;
        }

        static void Main(string[] args)
        {
            char opcao = 'S';
            while (opcao == 'S') // While para que o programa seja executado de acordo com a demanda do usuário
            {
                double a, b, result;
                int n;
                Console.WriteLine("BINÔMIO DE NEWTON"); // Inicialização das entradas
                Console.WriteLine("\nFórmula: (a+b)^n ");
                Console.Write("\nUsuário, entre com o valor de A: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Usuário, entre com o valor de B: ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Usuário, entre com o valor de N: ");
                n = int.Parse(Console.ReadLine());
                Console.Clear();
                if (n < 0) // Condicional para que o programa não execute o programa n for menor que 1 (n<1) conforme as regras do binômio
                {
                    Console.WriteLine("O numero de conjuntos (n) não pode ser menor que o numero de subconjuntos (p) a serem calculados no Coeficiente Binomial (n>=p)");
                }
                else // Programa continua executando se n>=0
                {

                    result = Desenvolvimento(a, b, n); // chamada do método para mostrar o resultado final do calculo do binômio
                    Console.WriteLine("O resultado do binômio ({0}+{1})^{2}:{3}", a, b, n, result);
                }
                Console.WriteLine("\nDeseja calcular novos binômios? S para sim e N para não.");
                opcao = char.Parse(Console.ReadLine().ToUpper());
                Console.Clear();

            }
            Console.WriteLine("Digite qualquer tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
