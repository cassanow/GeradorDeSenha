using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true; 
            while (loop) 
            {
                Console.WriteLine("Digite o tamanho da senha: ");
                int tamanhoSenha = Convert.ToInt32(Console.ReadLine());   
                if (tamanhoSenha < 1)
                {
                    Console.WriteLine("O tamanho da senha deve ser maior que 0.");
                    continue;
                }else if (tamanhoSenha < 5)
                {
                    Console.WriteLine("O tamanho da senha deve ser maior que 4.");
                    continue;   
                }

                Console.WriteLine("Deseja incluir letras maiúsculas?: (Y/N) ");
                bool incluirLetrasMaiusculas = Console.ReadLine().Trim().ToUpper()   == "Y";
                if (incluirLetrasMaiusculas == false)
                {
                    Console.WriteLine("A senha deve conter letras maiúsculas.");
                    continue;
                }   

                Console.WriteLine("Deseja incluir letras minúsculas?: (Y/N) ");
                bool incluirLetrasMinusculas = Console.ReadLine().Trim().ToUpper() == "Y";
                if (incluirLetrasMinusculas == false)
                {
                    Console.WriteLine("A senha deve conter letras minúsculas.");
                    continue;
                }   

                Console.WriteLine("Deseja incluir números?: (Y/N) ");
                bool incluirNumeros = Console.ReadLine().Trim().ToUpper() == "Y"; 
                if (incluirNumeros == false)
                {
                    Console.WriteLine("A senha deve conter números.");
                    continue;
                }       

                Console.WriteLine("Deseja incluir caracteres especiais?: (Y/N) ");
                bool incluirCaracteresEspeciais = Console.ReadLine().Trim().ToUpper() == "Y";

                string senha = GerarSenha(tamanhoSenha, incluirLetrasMaiusculas, incluirLetrasMinusculas, incluirNumeros, incluirCaracteresEspeciais);
                Console.WriteLine("Senha gerada: " + senha);

                Console.WriteLine("Deseja gerar outra senha? (Y/N)");
                loop = Console.ReadLine().Trim().ToUpper() == "Y"; 
            }
        }

        static string GerarSenha(int tamanhoSenha, bool incluirLetrasMaiusculas, bool incluirLetrasMinusculas, bool incluirNumeros, bool incluirCaracteresEspeciais)
        {
            string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
            string numeros = "0123456789";
            string caracteresEspeciais = "!@#$%¨&*()_+{}:>?<";


            string caracteres = "";

            if (incluirLetrasMaiusculas)
            {
                caracteres += letrasMaiusculas;
            }

            if (incluirLetrasMinusculas)
            {
                caracteres += letrasMinusculas;
            }

            if (incluirNumeros)
            {
                caracteres += numeros;
            }

            if (incluirCaracteresEspeciais)
            {

                caracteres += caracteresEspeciais;
            }


            byte[] bytes = new byte[tamanhoSenha];
            RandomNumberGenerator.Create().GetBytes(bytes); 


            StringBuilder senha = new StringBuilder(tamanhoSenha);

            foreach (byte b in bytes)
            {
                senha.Append(caracteres[b % caracteres.Length]);
            }

            return senha.ToString();
        }
    }
}
