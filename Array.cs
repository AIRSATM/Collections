using System;
using System.Collections.Generic;
/*Задание 1 - Массивы
Сценарий: У тебя есть фиксированный список «популярных» портов, которые нужно просканировать (например: 21, 22, 80, 443, 3389).
Задание: 
- Создай целочисленный массив из 5 элементов. 
Напиши программу, которая запрашивает у пользователя номер порта и, перебирая массив, выводит сообщение, входит ли этот порт в список стандартных для сканирования.*/

public class Task1
{ 
  static void Main()
  {
    //Тривиальный метод + оптимальный
    int[] ports = {21, 22, 80, 443, 3389};
    foreach (int port in ports) Console.Write(port + " ");
    Console.WriteLine("\n");
    Console.Write("Вводи число: ");
    int num = int.Parse(Console.ReadLine()); //string num = Console.ReadLine();
    bool found = false;
    //if (int.TryParse(num, out int res)){
    for (int i = 0; i < ports.Length; i++)
    {
      if (ports[i] == num)
      {
        found = true;
        break;
      }
    }
    if (found == true) Console.WriteLine("yes");
    else Console.WriteLine("no");
    //} else Console.WriteLine("error");

    //Быстрый способ
    int[] ports1 = {30000, 53, 8080, 3128, 2222};
    foreach (int port1 in ports1) Console.Write(port1 + " ");
    Console.WriteLine("\n");
    Console.Write("Вводи число: ");
    int num1 = int.Parse(Console.ReadLine());
    if (Array.Exists(ports1, element => element == num1)) Console.WriteLine("yes"); 
    else Console.WriteLine("no");
  }
}
