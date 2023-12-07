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

            // Пример строки с IP-адресами
            StringBuilder inputText = new StringBuilder("Тестовый текст с IP-адресами 192.168.0.1, 10.0.0.1, 172.16.0.1, 8.8.8.8, 192.168.1.1");

            // Паттерн для поиска IP-адресов
            string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

            // Создание регулярного выражения
            Regex regex = new Regex(pattern);

            // Поиск всех совпадений в строке
            MatchCollection matches = regex.Matches(inputText.ToString());

            // Создание массивов для классов IP-адресов
            List<string>[] ipAddressArrays = new List<string>[5];
            for (int i = 0; i < 5; i++)
            {
                ipAddressArrays[i] = new List<string>();
            }

            foreach (Match match in matches)
            {
                string ipAddress = match.Value;

                // Определение класса IP-адреса
                string[] octets = ipAddress.Split('.');
                int firstOctet = int.Parse(octets[0]);

                int ipClass = -1;
                if (firstOctet >= 1 && firstOctet <= 126)
                {
                    ipClass = 0; // Класс A
                }
                else if (firstOctet >= 128 && firstOctet <= 191)
                {
                    ipClass = 1; // Класс B
                }
                else if (firstOctet >= 192 && firstOctet <= 223)
                {
                    ipClass = 2; // Класс C
                }
                else if (firstOctet >= 224 && firstOctet <= 239)
                {
                    ipClass = 3; // Класс D
                }
                else if (firstOctet >= 240 && firstOctet <= 255)
                {
                    ipClass = 4; // Класс E
                }

                // Добавление IP-адреса в соответствующий массив класса
                if (ipClass != -1)
                {
                    ipAddressArrays[ipClass].Add(ipAddress);
                }
            }

            // Вывод IP-адресов по классам
            for (int i = 0; i < 5; i++)
            {
                string ipClass = "";
                switch (i)
                {
                    case 0:
                        ipClass = "A";
                        break;
                    case 1:
                        ipClass = "B";
                        break;
                    case 2:
                        ipClass = "C";
                        break;
                    case 3:
                        ipClass = "D";
                        break;
                    case 4:
                        ipClass = "E";
                        break;
                }

                Console.WriteLine($"IP-адреса класса {ipClass}:");
                foreach (var ipAddress in ipAddressArrays[i])
                {
                    Console.WriteLine(ipAddress);
                }
                Console.WriteLine();


            }
        Console.ReadKey();
        }
    }
}
