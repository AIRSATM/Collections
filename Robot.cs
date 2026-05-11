using System;
using System.Collections.Generic;

interface Rmove {void Move (int dx, int dy);}
interface Rposition {int X {get;} int Y {get;}}
interface IRobot : Rmove, Rposition {}

class Robot : IRobot
{
    public int X {get; private set;}
    public int Y {get; private set;}

    public void Move (int dx, int dy)
    {
        X += dx;
        Y += dy;
        Console.WriteLine($"Робот на ({X},{Y})");
        DrawMap();
    }
    private void DrawMap()
    {
        // Y идёт сверху вниз, поэтому строки рисуем от +5 до -5
        for (int row = Center; row >= -Center; row--)
        {
            for (int col = -Center; col <= Center; col++)
            {
                // Смещение робота относительно центра карты
                int robotCol = X % Center;
                int robotRow = Y % Center;

                if (col == robotCol && row == robotRow)
                    Console.Write(" R ");   // позиция робота
                else if (col == 0 && row == 0)
                    Console.Write(" + ");   // точка начала координат
                else if (col == 0)
                    Console.Write(" | ");   // вертикальная ось Y
                else if (row == 0)
                    Console.Write("---");   // горизонтальная ось X
                else
                    Console.Write(" . ");   // пустая клетка
            }
            Console.WriteLine($"  {row}"); // подпись строки (Y)
        }

        // Подписи столбцов (X)
        for (int col = -Center; col <= Center; col++)
            Console.Write($"{col,3}");
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        IRobot robot = new Robot();
        while (true)
        {
            Console.Write("\nВведи dx dy (или 'выход'): ");
            string input = Console.ReadLine();

            if (input == "выход") break;

            string[] parts = input.Split(' ');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int dx) ||
                !int.TryParse(parts[1], out int dy))
            {
                Console.WriteLine("Неверный формат! Пример: 3 -2");
                continue;
            }

            robot.Move(dx, dy);
            Console.WriteLine($"Позиция: ({robot.X}, {robot.Y})");
        }
    }
}
