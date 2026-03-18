using System;
using System.Collections.Generic;

/*
Сценарий: Система распределения заказов для курьера доставки еды.
Задание: Создай очередь из строк (адресов). 
Добавь в очередь три адреса доставки в том порядке, в котором они поступили на сервер. 
Затем напиши цикл while, который будет «выдавать» курьеру по одному адресу (удаляя его из очереди) и выводить на экран сообщение: 
"Заказ доставлен по адресу: [адрес]", пока очередь не опустеет.
*/

public class Task3
{
    static void Main()
    {
        Queue<string> addresses = new Queue<string>();

        addresses.Enqueue("ул. Мира, д. 12");
        addresses.Enqueue("ул. Советская, д. 35");
        addresses.Enqueue("ул. Ленина, д. 36");

        Console.WriteLine("Начать доставку? (enter)");
        Console.ReadLine();

        Console.WriteLine("\nДоставка началась!");

        int count = 0;
        while (addresses.Count > 0)
        {
            var first = addresses.Peek();
            Console.WriteLine($"Адрес доставки: {first}");
            count++;
            var pers1 = addresses.Dequeue();
            Console.WriteLine($"{count}-й заказ доставлен по адресу: {pers1}");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
//Получилось как-то слишком просто
//Могу завернуть в настоящий интерфейс САМОКАТ.PRO скоро!
