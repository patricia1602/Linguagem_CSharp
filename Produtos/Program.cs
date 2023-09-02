using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EstoqueLoja {

     class Produto{
            string Nome{get; set;}
            int QuantidadeEmEstoque{get; set;}

            Produto(string nome, int quantidadeInicial){
                Nome = nome;
                QuantidadeEmEstoque = quantidadeInicial;

            }
        }
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
                case "1":   
                    Novo();
                break;
                case "2": 
                    ListarProdutos();
                break;
                case "3":
                     RemoverProduto();
                break;
                case "4":
                     EntradaDeEstoque();
                break;
                case "5": 
                   SaidaDeEstoque();
                break;     
                case "0":
                     return;
                default: 
                    Console.WriteLine("Opção inválida!");
                break;
        
            }
        }        
     }

        private static void SaidaDeEstoque(){
            List<string> produtos = new List<string>();

            if (produtos.Count == 0){
        Console.WriteLine("Ainda não há produtos adicionados.");
        return;
    }

    ListarProdutos();

    Console.Write("Digite o número do produto para saída de estoque: ");
    
    if(int.TryParse(Console.ReadLine(), out int numeroProduto)){
        if(numeroProduto >= 1 && numeroProduto <= produtos.Count){
            Console.Write("Digite a quantidade da saída: ");
            
             if(int.TryParse(Console.ReadLine(), out int quantidadeEntrada)){
                if (quantidadeEntrada > 0){
                    string[] produtoInfo = produtos[numeroProduto - 1].Split(':');
                    string nomeProduto = produtoInfo[0];
                    int quantidadeAtual = int.Parse(produtoInfo[1]);
                    quantidadeAtual += quantidadeEntrada;                  
                
                    produtos[numeroProduto - 1] = $"{nomeProduto}:{quantidadeAtual}";
                    File.WriteAllLines(EstoqueLoja, produtos);
                    Console.WriteLine($"Saida de estoque de {quantidadeEntrada} unidades para {nomeProduto} realizada com sucesso.");
                }else{
                    Console.WriteLine("A quantidade de saida deve ser maior que zero.");
                }
            }
           
        }else{
           Console.WriteLine("Quantidade de saida inválida.");
            }
    }else{
        Console.WriteLine("Número de produto inválido.");
        }    
 }

        private static void EntradaDeEstoque(){
             List<string> produtos = new List<string>(File.ReadAllLines(EstoqueLoja));
    
    if (produtos.Count == 0){
        Console.WriteLine("Ainda não há produtos adicionados.");
        return;
    }

    ListarProdutos();

    Console.Write("Digite o número do produto para entrada de estoque: ");
    
    if(int.TryParse(Console.ReadLine(), out int numeroProduto)){
        if(numeroProduto >= 1 && numeroProduto <= produtos.Count){
            Console.Write("Digite a quantidade de entrada: ");
            
             if(int.TryParse(Console.ReadLine(), out int quantidadeEntrada)){
                if (quantidadeEntrada > 0){
                    string[] produtoInfo = produtos[numeroProduto - 1].Split(':');
                    string nomeProduto = produtoInfo[0];
                    int quantidadeAtual = int.Parse(produtoInfo[1]);
                    quantidadeAtual += quantidadeEntrada;                  
                
                    produtos[numeroProduto - 1] = $"{nomeProduto}:{quantidadeAtual}";
                    File.WriteAllLines(EstoqueLoja, produtos);
                    Console.WriteLine($"Entrada de estoque de {quantidadeEntrada} unidades para {nomeProduto} realizada com sucesso.");
                }else{
                    Console.WriteLine("A quantidade de entrada deve ser maior que zero.");
                }
            }
           
        }else{
           Console.WriteLine("Quantidade de entrada inválida.");
            }
    }else{
        Console.WriteLine("Número de produto inválido.");
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
    