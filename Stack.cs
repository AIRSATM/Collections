using System;
using System.Collections.Generic;

/*
Сценарий: Навигация по директориям в терминале Linux (аналог команды cd и cd ..).

Задание: Создай стек строк. При "переходе" в папку добавляй её имя на вершину стека 
(например: /, затем /home, затем /home/user, затем /home/user/tools). 
Выведи текущую директорию (вершину стека). 
Затем сымитируй ввод команды cd .. дважды — извлеки два верхних элемента и выведи директорию, в которой ты в итоге оказался.
*/

public class Task4
{
    static void Main()
    {
        Stack<string> path = new Stack<string>();
        Console.WriteLine("Введите путь (cd {директория} или cd .. чтобы извлечь два компонента):");
        while (true)
        {
            // var components = path.Reverse().ToArray();
            // var fullpath = string.Join("/", components);
            string currentPath = GetfullPath(path);
            Console.WriteLine(currentPath);
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

            if (input.StartsWith("cd ", StringComparison.CurrentCultureIgnoreCase))
            {
                string arg = input.Substring(3).Trim();
                if (arg == "..")
                {
                    if (path.Count > 0) path.Pop();
                    else Console.WriteLine("Вы уже в корневой папке");
                    Console.WriteLine(currentPath);
                }
                else if (arg.Length > 0) path.Push(arg);
                else Console.WriteLine("Ошибка: нет такого имени");
            }
            else Console.WriteLine("Неизвестная команда");
        }
    }
    static string GetfullPath(Stack<string> st)
    {
        var components = st.Reverse().ToArray();
        return components.Length == 0 ? "/" : "/" + string.Join("/", components);
    }
}
//Это обычная наработка, скоро HashSet и Dictionary
//потом реверс-инжиниринг
