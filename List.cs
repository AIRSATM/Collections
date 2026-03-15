using System;
using System.Collections.Generic;

/*Сценарий: Управление группой боевых единиц.
Задание: 
- Создай List<string>. Добавь туда несколько юнитов (например, "Зилот", "Сталкер", "Адепт"). 
- Выведи весь список. Затем сымитируй потерю юнита — удали "Зилота" из списка. 
- В конце добавь в список "Иммортала" и снова выведи обновленный состав отряда.*/

public class Unit
{
    public string Name {get; set;}
    public int HP {get; set;}
    public Unit (string name, int hp1)
    {
        Name = name;
        HP = hp1;
    }
}

public class Task2
{
    static void Main()
    {
        //тривиальный подход
        var protoss = new List<string>(){"Zealot","Stalker","Adept","Dragun"};
        var hp = new List<int>(){120, 250, 220, 200};

        for (int i = 0; i < protoss.Count; i++) 
            Console.WriteLine(protoss[i] + " " + hp[i] + " HP");

        Console.Write("\nКого уберем из протоссов: ");
        string? input = Console.ReadLine();
        int index = -1;
        for (int i = 0; i < protoss.Count; i++)
        {
            if (protoss[i].ToLower() == input?.ToLower())
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            Console.WriteLine($"Удалили {protoss[index]} {hp[index]}");
            protoss.RemoveAt(index);
            hp.RemoveAt(index);
        }
        else
        {
            Console.WriteLine($"Юнит {input} не найден");
        }

        string? s1 = "";
        while (s1 != "да" && s1 != "нет")
        {
            Console.WriteLine("Юнит Immortal готов к бою, хотите добавить его в армию?");
            s1 = Console.ReadLine();

            if (s1 == "да")
            {
                protoss.Add("Immortal");
                hp.Add(350);
                for (int i = 0; i < protoss.Count; i++) 
                Console.WriteLine(protoss[i] + " " + hp[i] + " HP");
            }
            else if (s1 == "нет")
            {
                for (int i = 0; i < protoss.Count; i++) 
                Console.WriteLine(protoss[i] + " " + hp[i] + " HP");
            }
            else {
                Console.WriteLine("Введите 'да' или 'нет'");
                
            }
        }
        //Более оптимальный подход
        Console.WriteLine("\nАрмия терранов: ");
        var Army = new List<Unit>
        {
            new Unit("Marine", 100),
            new Unit("Medic", 50),
            new Unit("Marauder", 150),
            new Unit("Flamethrower", 150),
            new Unit("Ghost", 95)
        };
        foreach (var unit in Army) 
            Console.WriteLine($"{unit.Name} {unit.HP}");

        Console.Write("\nКого уберем из морпехов: ");
        string? input1 = Console.ReadLine();

        int removed1 = Army.RemoveAll(u => u.Name.ToLower() == input1?.ToLower());
        
        if (removed1 > 0)
            Console.WriteLine($"Юнит {input1} удален");
        else 
            Console.WriteLine($"Юнит {input1} не найден");
        
        string? s2 = "";
        while (s2 != "да" && s2 != "нет")
        {
            Console.WriteLine("Юнит Cruiser готов к бою, хотите добавить его в армию?");
            s2 = Console.ReadLine();

            if (s2 == "да")
            {
                Army.Add(new Unit("Cruiser", 500));
                foreach (var unit in Army)
                    Console.WriteLine($"{unit.Name} {unit.HP} HP");
            }
            else if (s2 == "нет")
            {
                foreach (var unit in Army)
                    Console.WriteLine($"{unit.Name} {unit.HP} HP");
            }
            else {
                Console.WriteLine("Введите 'да' или 'нет'");
            }
        }
    }
}
