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
    }
}
class Program
{
    static void Main()
    {
        IRobot robot = new Robot();
        int x,y;
        Console.WriteLine("Напишите координаты передвижения робота (например - 4 5):");
        x = int.Parse(Console.ReadLine());
        y = int.Parse(Console.ReadLine());
        robot.Move(x,y);
        Console.WriteLine($"Позиция: ({robot.X}, {robot.Y})");
    }
}
