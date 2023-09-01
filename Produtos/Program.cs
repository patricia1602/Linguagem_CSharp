using System;
using System.IO;
using System.Collections.Generic;

namespace EstoqueLoja {
    class Program {

     private const string EstoqueLoja = "estoque.txt";  

     static void Main(){
        while(true){
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Novo: ");
            Console.WriteLine("2. Listar Produtos: ");
            Console.WriteLine("3. Remover Produtos: ");
            Console.WriteLine("4. Entrada de Estoque: ");
            Console.WriteLine("5. Saída de Estoque: ");
            Console.WriteLine("0. Sair: ");
            Console.WriteLine("Escolha uma opção: ");

            switch(Console.ReadLine()){
                case "1": Novo();
                break;
                case "2": ListarProdutos();
                break;
                case "3": RemoverProduto();
                break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!");
                break;

            
            }
        }        
     }

         static void ListarProdutos(){
            if (!File.Exists(EstoqueLoja)){
                Console.WriteLine("Ainda não há produtos adicionados.");
                return;
            }
            List<string> produtos = new List<string>(File.ReadAllLines(EstoqueLoja));
            Console.WriteLine("\nProdutos: ");
            for (int i = 0; i < produtos.Count; i++){
                Console.WriteLine($"{i + 1}. {produtos[i]}");
            }
            Console.WriteLine();      
      }

        static void Novo(){
            Console.Write("Digite o nome do produto: ");
            string produto = Console.ReadLine();
            File.AppendAllText(EstoqueLoja, produto + Environment.NewLine);
        }

         static void RemoverProduto(){
            Console.Write("Digite o número do produto que deseja remover: ");

            if(int.TryParse(Console.ReadLine(),out int numeroProduto)){
             List<string> produtos = new List<string>(File.ReadAllLines(EstoqueLoja));

                if(numeroProduto >= 1 && numeroProduto <= produtos.Count){
                    produtos.RemoveAt(numeroProduto);
                    File.WriteAllLines(EstoqueLoja,produtos);
                    Console.WriteLine("Produto removido com sucesso.");

                }else{
                   Console.WriteLine("Número de produto inválido."); 
                }
                }
              }
            }
        }
    