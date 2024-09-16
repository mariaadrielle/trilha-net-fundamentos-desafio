using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim(); 
            // Remove espaços em branco

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode estar vazia.");
                return;
            }

            // Verifica se a placa já está na lista de veículos
            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Essa placa já está cadastrada. Não é permitido adicionar a mesma placa duas vezes.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi adicionado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim(); 
            // Remove espaços em branco

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode estar vazia.");
                return;
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (!int.TryParse(Console.ReadLine(), out int horas))
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                    return;
                }

                // Realiza o cálculo: "precoInicial + precoPorHora * horas"
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove a placa da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Exibindo os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
