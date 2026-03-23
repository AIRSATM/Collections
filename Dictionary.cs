using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

/*
Сценарий: OSINT-инструмент профилирования.
    
Задание: Создай словарь, где ключом будет выступать никнейм (`string`), а значением — платформа (`string`), где этот никнейм был обнаружен. 
Заполни словарь 3-4 парами (например, "Shadow99" -> "Telegram", "Neo" -> "GitHub"). 
Напиши код, который проверяет: если заданный никнейм есть в базе (словаре), программа выводит платформу. 
Если нет — выводит "Следов не найдено".
*/

public class Task6
{
    static void Main()
    {
        Dictionary<string,string> search = new Dictionary<string, string>()
        {
            {"Shadow99","Telegram"},
            {"Neo","Github"},
            {"69donat","Telegram"},
            {"MasturBeast","Youtube"},
            {"Hacker1337","Discord"}
        };
        Console.Write("Введите никнейм пользователя: ");
        string? user = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(user))
        {
            Console.WriteLine("Никнейм не введен");
            return;
        }

        if (search.TryGetValue(user, out string platform))
        {
            Console.WriteLine($"Платформа: {platform}");
        }
        else
        {
            Console.WriteLine("следов не найдено");
        }
    }
}
