using System;
using System.Collections.Generic;
using System.Net;

/*
Сценарий: Очистка сетевых логов. 
На сервер была совершена DDoS-атака, и в логах осталось много повторяющихся IP-адресов.

Задание: Создай обычный массив строк с IP-адресами, где некоторые адреса повторяются несколько раз. 
Программно перенеси все данные из массива в HashSet<string>. 
Выведи на экран исходное количество логов (размер массива) и итоговое количество уникальных IP-адресов (размер множества), которые реально участвовали в атаке.
*/

public class Task5
{
    static void Main()
    {
        string[] addresses =
        {
            "192.1.1.0", "192.168.0.3",
            "193.144.1.1", "185.185.1.0",
            "92.76.0.76", "185.185.1.0",
            "192.1.1.0", "185.185.1.0",
            "192.1.1.0", "192.168.0.3",
            "255.255.255.255"
        };
        HashSet<string> ip = new HashSet<string>(addresses);
        foreach(var item in ip)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Количество логов: {addresses.Length}");
        Console.WriteLine($"Количестов уникальных IP-адресов: {ip.Count}");

        //продвинутый способ со случайными ip-адресами

        Console.Write("Введи сколько IP-адресов посмотрим: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Неправильный ввод");
            return;
        }
        HashSet<IPAddress> ipset = new HashSet<IPAddress>();
        Random rnd = new Random();

        for (int i=0; i < count; i++)
        {
            byte[] data = new byte[4];
            rnd.NextBytes(data);
            IPAddress ip1 = new IPAddress(data);
            ipset.Add(ip1);
        }

        Console.WriteLine($"Количество логов найденных при последней атаке: {ipset.Count}");
        Console.WriteLine("Список логов: ");
        foreach(var ips in ipset) Console.WriteLine(ips);
    }
}
