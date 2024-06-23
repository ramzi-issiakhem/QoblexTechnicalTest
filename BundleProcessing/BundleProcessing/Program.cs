using Microsoft.EntityFrameworkCore;
using System;



namespace App
{


    




    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bundle Process Application, to calculate the exact number of Bundles you can create according to its structure");
            
            Inventory inventory = Inventory.GetInstance();
            
            // Generate the Bundle Tree from the Console Input
            Bundle bundle = new();
            bundle.generateBundleTreeFromConsoleInput();
            
            // Populate the Inventory using the Final Products
            ConsoleUtils.displaySeparator();
            Console.WriteLine($"We are going through the inventory of each products in the {bundle.Name}");
            inventory.intiateFromBundle(bundle);
            
            // Calculate how much Bundles can be created
            int amount = inventory.CalculateAmountOfBundles(bundle);
            ConsoleUtils.displaySeparator();
            ConsoleUtils.displaySeparator();
            Console.WriteLine($"You can create {amount} of {bundle.Name} Bundles with the current Inventory you have");
            ConsoleUtils.displaySeparator();
            ConsoleUtils.displaySeparator();

        }
    }

}