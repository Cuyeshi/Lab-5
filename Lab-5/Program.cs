using System;
using System.Collections.Generic;
using System.Threading;
using IPAddressSorterLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст: ");
        // Пример строки с IP-адресами
        string inputText = Console.ReadLine(); // "Текст с IP-адресами 192.168.0.1, 10.0.0.1, 172.16.0.1, 8.8.8.8, 192.168.1.1";

        // Использование библиотеки классов для рассортировки IP-адресов
        Dictionary<string, List<string>> ipAddressesByClass = IPAddressSorter.SortIPAddressesByClass(inputText);

        // Вывод IP-адресов по классам
        foreach (var zxc in ipAddressesByClass)
        {
            Console.WriteLine($"\nIP-адреса класса {zxc.Key}:");
            foreach (var ipAddress in zxc.Value)
            {
                Console.WriteLine(ipAddress);
            }
            Console.WriteLine();
        }

        Console.ReadKey();
        Console.WriteLine("\nЗавершение программы...");
        Thread.Sleep(2000);
    }
}