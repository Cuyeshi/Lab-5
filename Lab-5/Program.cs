using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите текст: ");
            // Пример строки с IP-адресами
            StringBuilder inputText = new StringBuilder(); // Тестовый текст с IP-адресами 192.168.0.1, 10.0.0.1, 172.16.0.1, 8.8.8.8, 192.168.1.1
            inputText = Console.ReadLine();

            // Паттерн для поиска IP-адресов
            string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

            // Создание регулярного выражения
            Regex regex = new Regex(pattern);

            // Поиск всех совпадений в строке
            MatchCollection matches = regex.Matches(inputText.ToString());

            // Словарь для хранения IP-адресов по классам
            Dictionary<string, List<string>> ipAddressesByClass = new Dictionary<string, List<string>>();

            foreach (Match match in matches)
            {
                string ipAddress = match.Value;

                // Определение класса IP-адреса
                string[] octets = ipAddress.Split('.');
                int firstOctet = int.Parse(octets[0]);

                string ipClass = "";
                if (firstOctet >= 1 && firstOctet <= 126)
                {
                    ipClass = "A";
                }
                else if (firstOctet >= 128 && firstOctet <= 191)
                {
                    ipClass = "B";
                }
                else if (firstOctet >= 192 && firstOctet <= 223)
                {
                    ipClass = "C";
                }
                else if (firstOctet >= 224 && firstOctet <= 239)
                {
                    ipClass = "D";
                }
                else if (firstOctet >= 240 && firstOctet <= 255)
                {
                    ipClass = "E";
                }

                // Добавление IP-адреса в соответствующий класс
                if (!ipAddressesByClass.ContainsKey(ipClass))
                {
                    ipAddressesByClass[ipClass] = new List<string>();
                }
                ipAddressesByClass[ipClass].Add(ipAddress);
            }

            // Вывод IP-адресов по классам
            foreach (var kvp in ipAddressesByClass)
            {
                Console.WriteLine($"IP-адреса класса {kvp.Key}:");
                foreach (var ipAddress in kvp.Value)
                {
                    Console.WriteLine(ipAddress);
                }
                Console.WriteLine();
            }
        }
    }
}
