using System;
using System.Collections.Generic;
using System.Linq;


namespace App
{
    public class Inventory
    {

  
        public int Amount { get; set; }

        


        //////////////////////////////////

        public Inventory()
        {
            this.Amount = 0;
        }

        private Dictionary<string, int> inventory = new Dictionary<string, int>();

        private static Inventory instance;


        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }

        public int AddOrCreateItem(string name, int amount)
        {
            if (inventory.ContainsKey(name))
            {
                inventory[name] = inventory[name] + amount;
            }
            else
            {
                inventory.Add(name, amount);
            }

            return inventory[name];
        }

        public int SubstractItem(string name, int amount)
        {
            if (inventory.ContainsKey(name))
            {
                inventory[name] = inventory[name] - amount;
                if (inventory[name] < 0)
                {
                    inventory[name] = 0;
                }
            }

            return inventory[name];
        }

        public int GetItemAmount(string name) { return inventory.ContainsKey(name) ? inventory[name] : 0; }

        public int CountInventory()
        {
            return inventory.Count;
        }

        internal void intiateFromBundle(Bundle bundle)
        {
            Console.WriteLine($"We are going to go through the {bundle.Name} Bundle Inventory");
            foreach (KeyValuePair<FinalProduct, int> product in bundle.GetFinalProducts())
            {
                if (this.GetItemAmount(product.Key.ProductName) > 0)
                {
                    Console.WriteLine($"The Inventory already has {this.GetItemAmount(product.Key.ProductName)} of {product.Key.ProductName}");
                    bool addMore = ConsoleUtils.GetBooleanValue($"Do you want to add more {product.Key.ProductName} to the Inventory (Y/N)");
                    if (addMore)
                    {
                        int amount = ConsoleUtils.GetPositiveNumberInput($"What is the amount {product.Key.ProductName} added in the inventory");
                        this.AddOrCreateItem(product.Key.ProductName, amount);
                    }
                }
                else
                {
                    int amount = ConsoleUtils.GetPositiveNumberInput($"What is the amount available in the inventory for {product.Key.ProductName}");
                    this.AddOrCreateItem(product.Key.ProductName, amount);
                }
            }

            foreach (KeyValuePair<Bundle, int> bundleLocal in bundle.GetBundles())
            {
                this.intiateFromBundle(bundleLocal.Key);
            }
        }

        public int CalculateAmountOfBundles(Bundle bundle)
        {
            // TO AVOID THE PROBLEM OF USING ALL THE INVENTORY SPARE PARTS FOR EITHER CONSTRUCTING A BUNDLE OR A PRODUCT IN THE 
            // CASE WHERE A BUNLE AND A PRODUCT SHARE THE SAME PARTS, WE WILL SIMULATE THE CONSTRUCTION OF ONE BUNDLE AT A TIME

            int amount = 0;
            bool canBuild = true;
            while (canBuild)
            {
                canBuild = this.CanBuildBundle(bundle);
                if (canBuild)
                {
                    amount++;
                }
            }
            return amount;
        }

        private bool CanBuildBundle(Bundle bundle)
        {
            bool canBuild = true;
            bool productsBuilt = false;

            //We will check if we have enough parts to build the bundle's products first
            foreach (KeyValuePair<FinalProduct, int> product in bundle.GetFinalProducts())
            {
                if (this.GetItemAmount(product.Key.ProductName) < product.Value)
                {
                    canBuild = false;
                    break;
                }
            }

            if (canBuild)
            {
                foreach (KeyValuePair<FinalProduct, int> product in bundle.GetFinalProducts())
                {
                    this.SubstractItem(product.Key.ProductName, product.Value);
                }

                productsBuilt = true;

                foreach (KeyValuePair<Bundle, int> bundleLocal in bundle.GetBundles())
                {
                    for (int i = 0; i < bundleLocal.Value; i++)
                    {
                        canBuild = this.CanBuildBundle(bundleLocal.Key);
                        if (!canBuild)
                        {
                            break;
                        }
                    }
                }
            }

            if (!canBuild)
            {
                if (productsBuilt)
                {
                    foreach (KeyValuePair<FinalProduct, int> product in bundle.GetFinalProducts())
                    {
                        this.AddOrCreateItem(product.Key.ProductName, product.Value);
                    }
                }
            }

            return canBuild;
        }
    }
}
    
