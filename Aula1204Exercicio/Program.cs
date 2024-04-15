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
            private int andarAtual {  get; set; }  

            private int totalAndares { get; set; }

            private int totalPessoas { get; set; }

            private int pessoasDentro { get; set; }

            public Elevador(int capacidadeElevador, int totalDeAndares) 
            {              
                this.totalAndares = totalDeAndares;   
                this.totalPessoas = capacidadeElevador; 
                this.pessoasDentro = 0;
                this.andarAtual= 0;
            }

            public void entrar()
            {
                if (this.pessoasDentro < this.totalPessoas)
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
                if (this.andarAtual != this.totalAndares)
                {
                    this.andarAtual++;
                    Console.WriteLine($"Elevador subiu um andar.");
                }
                else
                {
                    Console.WriteLine($"Elevador já está no ultimo andar.");
                }
            }

            public void desce()
            {
                if (this.andarAtual != 0)
                {
                    this.andarAtual--;
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
                Console.WriteLine($"Quantidade de pessoas no elevador: {this.pessoasDentro}; Andar atual: {this.andarAtual}");
                Console.WriteLine($"Capacidade máxima: {this.totalPessoas} pessoas; Andares: {this.totalAndares}");
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
                }
                catch (Exception e)
                {
                    Console.WriteLine("Valor inserido inválido. Insira novamente");
                }
            } while (capacidadeElevador <= 0);


            do
            {
                try
                {
                    Console.Write("Total de andares: ");
                    andares = int.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine("Valor inserido inválido. Insira novamente");
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
                int opt = 0;

                try
                {
                    opt = int.Parse(Console.ReadLine());
                }catch(Exception e){}
                  
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
                        Console.WriteLine("Finalizado");
                        verificar = false; // ou Environment.Exit(0);    -> caso usar while (true)
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Insira novamente");
                        break;
                }
            }
        }
    }
}
