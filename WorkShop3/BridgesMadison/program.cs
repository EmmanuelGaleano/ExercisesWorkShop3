using System;
using BridgesMadison.Core;

class Program
{
    static void Main()
    {
        // Create a single instance of the validator
        var validator = new BridgeValidator();
        string option;

        // Repeat until the user chooses to exit
        do
        {
            // Ask for the bridge string
            Console.Write("Ingrese el puente: ");
            string input = Console.ReadLine();

            // Validate the bridge
            bool valid = validator.Validate(input);

            // Show the result in Spanish
            Console.WriteLine(valid ? "VALIDO" : "INVALIDO");

            // Ask if the user wants to validate another bridge
            Console.Write("¿Desea validar otro puente? (s/n): ");
            option = Console.ReadLine()?.Trim().ToLower();
            Console.WriteLine();

        } while (option == "s"); // Loop while the user types "s"    

        Console.WriteLine("Programa finalizado.");
    }
}
