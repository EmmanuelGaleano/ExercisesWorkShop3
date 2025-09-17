using System;
using HorseHarvest.Core;

class Program
{
    static void Main()
    {
        // Ask for the fruit locations
        Console.Write("Ingrese ubicación de los frutos: ");
        string fruits = Console.ReadLine();

        // Ask for the initial horse position
        Console.Write("Ingrese posición inicial del caballo: ");
        string horsePos = Console.ReadLine();

        // Ask for the horse moves
        Console.Write("Ingrese los movimientos del caballo: ");
        string moves = Console.ReadLine();

        // Create a new horse game instance
        var game = new HorseGame();

        // Set the fruits on the board
        game.SetFruits(fruits);

        // Set the horse initial position
        game.SetHorsePosition(horsePos);

        // Move the horse and collect fruits
        var collected = game.MoveHorse(moves);

        // Show collected fruits to the user
        Console.WriteLine("Los frutos recogidos son: " + string.Join("", collected));
    }
}
