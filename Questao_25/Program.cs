using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao_25
{
    class Program
    {

        static bool divisivelPor19(int menorNumero, int contador)
        {
            bool divisivel = true;

            if (menorNumero > 100000)
            {
                char[] charArray;
                int valorSomado = 0;
                for (int i = 0; i < menorNumero.ToString().ToCharArray().Length - 1; i++)
                {
                    if (valorSomado == 0)
                        charArray = menorNumero.ToString().ToCharArray();
                    else
                        charArray = valorSomado.ToString().ToCharArray();

                    int ultimoNumero = Convert.ToInt32(charArray[charArray.Length - 1].ToString());
                    string valorCompleto = string.Empty;
                    
                    for (int j = 0; j < charArray.Length - 1; j++)
                        valorCompleto += charArray[j].ToString();

                    valorSomado = Convert.ToInt32(valorCompleto) + (ultimoNumero * 2);
                }

                divisivel = (valorSomado % contador) == 0;
            }
            else
                divisivel = (menorNumero % contador) == 0;

            return divisivel;
        }

        static void Main(string[] args)
        {
            //    Questão 25 - Faça o algoritmo(repositório no github ou azure devops, em c#):

            //    2520 é o menor número que pode ser dividido por cada um dos números de 1 a 10 sem
            //    qualquer resto.Qual é o menor número positivo que é divisível por todos os números de 1
            //    a 20 ?

            bool numeroEncontrado = false;
            int menorNumero = 0;

            //loop até encontrar o menor número.
            while (!numeroEncontrado)
            {
                numeroEncontrado = false;
                menorNumero++;

                // loop de 1 a 20 realizando as divisões.
                for (int i = 2; i <= 20; i++)
                {
                    // Para aumentar a performance, foi utilizado um critério de divisão por 19 para números grandes.
                    if (i == 19)
                        numeroEncontrado = divisivelPor19(menorNumero, i);
                    else
                        numeroEncontrado = (menorNumero % i) == 0;

                    // Para evitar calculos desnecessários, quebra o loop e parte para outra.
                    if (!numeroEncontrado)
                        break;
                }
            }

            // Exibição dos resultados.
            for (int i = 1; i <= 20; i++)
                Console.WriteLine($"{menorNumero} / {i} = {menorNumero / i}");

            Console.WriteLine($"Menor número positivo encontrado por todos os números de 1 a 20: {menorNumero}");
            Console.ReadKey();
        }
    }
}
