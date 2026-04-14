using System;
using System.Collections.Generic;
using System.IO.Compression;

/*Задача 2: «Адаптивная аутентификация» (Абстрактные классы + События)
Сценарий: Разрабатывается система контроля доступа. Способы входа бывают разные (пин-код, отпечаток пальца), но у всех есть общая черта — лимит попыток входа. Если кто-то ошибается 3 раза, система должна аппаратно заблокироваться через механизм событий.

Что нужно сделать:

Создай абстрактный класс Authenticator.

Добавь в него защищенное поле int failedAttempts = 0.

Объяви делегат SecurityBreachHandler и событие event SecurityBreachHandler OnLocked.

Создай обычный метод void RegisterFailure(), который увеличивает счетчик. Если счетчик достигает 3, метод вызывает событие OnLocked.

Объяви абстрактный метод bool TryLogin(string credentials).

Создай класс-наследник PinAuthenticator. В нем реализуй TryLogin: если пин-код равен "1234", возвращаем true. Иначе вызываем унаследованный метод RegisterFailure() и возвращаем false.

Создай класс SecurityConsole (наблюдатель). В нем метод void Alarm(), который будет реагировать на взлом.

Критерии успешного выполнения:

[ ] Избежано дублирование кода: логика подсчета ошибок и вызова события реализована только один раз в базовом абстрактном классе, а не в наследниках.

[ ] Событие OnLocked проверяется на null перед вызовом.

[ ] В Main объект SecurityConsole успешно подписан на событие объекта PinAuthenticator (через +=).*/

namespace TaskAbstract
{
    public delegate void SecurityBreachHandler();
    public abstract class Authenticator
    {
        protected int failedAttempts = 0;
        public event SecurityBreachHandler OnLocked;

        protected void RegisterFailure()
        {
            failedAttempts++;
            if (failedAttempts == 3)
            {
                OnLocked?.Invoke();
            }
        }

        public abstract bool TryLogin(string credentials);
    }
    public class PinAuthenticator : Authenticator
    {
        public override bool TryLogin(string credentials)
        {
            if (credentials == "1234")
            {
                return true;
            }
            else
            {
                RegisterFailure();
                return false;
            }
        }
    }
    public class SecurityConsole
    {
        public void Alarm()
        {
            Console.WriteLine("Система заблокирована");
        }
    }
    public class TaskName
    {
        public static void Main()
        {
            PinAuthenticator pin = new PinAuthenticator();
            SecurityConsole console = new SecurityConsole();
            pin.OnLocked += console.Alarm;
            int count = 0;
            string s;
            Console.WriteLine("Введите пин-код: ");
            while (count < 10)
            {
                count++;
                s = Console.ReadLine();
                bool round = pin.TryLogin(s);
                if (round == true)
                {
                    Console.WriteLine($"Попытка {count}:");
                    Console.WriteLine("Success");
                    break;
                }
                else
                {
                    Console.WriteLine($"Попытка {count}:");
                    Console.WriteLine("Wrong");
                }
            }
            Console.WriteLine($"Было использовано {count} попыток!");
        }
    }
}