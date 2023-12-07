using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPAddressSorterLibrary
{
    /// <summary>
    /// Класс для сортировки IP - адрессов по своим классам.
    /// </summary>
    public class IPAddressSorter
    {
        /// <summary>
        /// Метод для сортировки IP - адрессов по своим классам.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> SortIPAddressesByClass(string inputText)
        {
            // Паттерн для поиска IP-адресов
            string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

            // Создание регулярного выражения
            Regex regex = new Regex(pattern);

            // Поиск всех совпадений в строке
            MatchCollection matches = regex.Matches(inputText);

            // Создание словаря для классов IP-адресов
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

            return ipAddressesByClass;
        }
    }
}
