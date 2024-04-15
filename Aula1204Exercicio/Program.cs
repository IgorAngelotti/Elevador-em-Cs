using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Aula1204Exercicio
{
    internal class Program
    {
        public class Elevador
        {
            private int terreo {  get; set; }  

            private int totalAndares { get; set; }

            private int capacidade { get; set; }

            private int pessoasDentro { get; set; }

            public Elevador(int capacidadeElevador, int totalDeAndares) 
            {              
                this.totalAndares = totalDeAndares;   
                this.capacidade = capacidadeElevador; 
                this.pessoasDentro = 0;
                this.terreo = 0;
            }

            public void entrar()
            {
                if (this.pessoasDentro < this.capacidade)
                {
                    this.pessoasDentro++;
                    Console.WriteLine($"Pessoa adicionada.");
                }
                else
                {
                    Console.WriteLine("Ninguém pode entrar! Elevador na capacidade máxima.");
                }
            }

            public void sair()
            {
                if (this.pessoasDentro != 0)
                {
                    this.pessoasDentro--;
                    Console.WriteLine($"Pessoa removida.");
                }
                else
                {
                    Console.WriteLine("Elevador vazio. Ninguem foi removido.");
                }
            }

            public void sobe()
            {
                if (this.terreo != this.totalAndares)
                {
                    this.terreo++;
                    Console.WriteLine($"Elevador subiu um andar.");
                }
                else
                {
                    Console.WriteLine($"Elevador já está no ultimo andar.");
                }
            }

            public void desce()
            {
                if (this.terreo != 0)
                {
                    this.terreo--;
                    Console.WriteLine($"Elevador desceu um andar.");
                    // ou Console.ReadKey() para caso usar o do while e o clear apagar essa mensagem (clear antes do "opt")
                }
                else
                {
                    Console.WriteLine($"Elevador já está no térreo.");
                }
            }

            public void atualizaSituacao()
            {
                Console.WriteLine("Situação do elevador: ");
                Console.WriteLine($"Quantidade de pessoas no elevador: {this.pessoasDentro}; Andar atual: {this.terreo}");
            }

            public void finalizar()
            {
                Console.WriteLine("Finalizando");
            }

        }
        
        static void Main(string[] args)
        {
            int capacidadeElevador = 0;
            int andares = 0;
 
            do
            {
                try
                {
                    Console.Write("Capacidade do elevador: ");
                    capacidadeElevador = int.Parse(Console.ReadLine());
                }catch (Exception e)
                {
                    Console.WriteLine("Valor inserido inválido. Favor inserir apenas números inteiros e positivos.");
                }
            }while (capacidadeElevador <= 0);

            do
            {
                try
                {
                    Console.Write("Total de andares: ");
                    andares = int.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine("Valor inserido inválido. Favor inserir apenas números inteiros e positivos.");
                }
            }while (andares <= 0);

            Elevador elevador = new Elevador(capacidadeElevador, andares);
            bool verificar = true;

            Console.Clear();

            while (verificar)
            {
                Console.WriteLine();    
                elevador.atualizaSituacao();
                Console.WriteLine();
                Console.WriteLine("\tSelecione uma opção: \n1. Acrescentar pessoa elevador\n2. Remover pessoa do elevador\n3. Subir andar\n4. Descer andar\n5. Finalizar");
                int opt = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opt) {
                    case 1: 
                        elevador.entrar();
                        break;

                    case 2:
                        elevador.sair();
                        break;

                    case 3:
                        elevador.sobe();
                        break;

                    case 4:
                        elevador.desce();   
                        break;

                    case 5:
                        Console.WriteLine("Finalizando");
                        verificar = false; // ou Environment.Exit(0);    -> caso usar while (true)
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
