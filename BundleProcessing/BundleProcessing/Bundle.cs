using System;
using System.Numerics;


namespace App
{

    // This class represents a Bundle and its structure
    public class Bundle
    {

        
        public string Name { get; set; }

        public int PieceNumber { get; set; }
         


        private Dictionary<FinalProduct,int> _FinalProducts { get; set; }

        private Dictionary<Bundle,int> _bundles { get; set; }

        public Bundle()
        {
            this._FinalProducts = new Dictionary<FinalProduct,int>();
            this._bundles = new Dictionary<Bundle,int>();
        }

        // Add a Final Product to the Bundle
        public void addFinalProduct(FinalProduct FinalProduct,int amountNeeded)
        {
            this._FinalProducts.Add(FinalProduct, amountNeeded);
        }


        // Add a Bundle to the Bundle
        public void addBundle(Bundle bundle,int amountNeeded)
        {
            this._bundles.Add(bundle,amountNeeded);
        }


        // Generate the Bundle Tree from the Console Input
        public void generateBundleTreeFromConsoleInput()
        {
            this.Name = ConsoleUtils.GetNonEmptyStringInput("\nWhat is the Bundle name you want to build");
            this.PieceNumber = ConsoleUtils.GetPositiveNumberInput($"\nHow many pieces is the Bundle '{this.Name}' composed of");

            // Loop through the Pieces needed to build the Bundle
            Console.WriteLine($"We are going now to go through each {PieceNumber} Pieces needed to build the {Name}");
            for (int i = 0; i < this.PieceNumber; i++)
            {
                ConsoleUtils.displaySeparator();
                Console.WriteLine($"\nPiece Number {i + 1}");
                bool isFinal = ConsoleUtils.GetBooleanValue($"\nIs the Product Piece a final Final Product (Y/N) (If the Product is Bundle, answer with N)");


                // It means the FinalProduct is final and not a bundle
                if (isFinal)
                {
                    string itemName = ConsoleUtils.GetNonEmptyStringInput("\nWhat is the name of this Final Product");
                    int neededParts = ConsoleUtils.GetNonNegativeNumberInput($"\nHow Many of {itemName} are needed to construct the {this.Name} ? ");

                    FinalProduct FinalProduct = new FinalProduct(itemName);
                    this.addFinalProduct(FinalProduct,neededParts);
                }
                else
                {   
                    
                    Bundle bundle = new Bundle();
                    int amount = ConsoleUtils.GetNonNegativeNumberInput($"\nHow many of this Bundle are needed to construct the {this.Name} ? ");
                    bundle.generateBundleTreeFromConsoleInput();
                    this.addBundle(bundle,amount);

                }
            }

        }

        internal Dictionary<Bundle, int> GetBundles()
        {
            return this._bundles;
        }

        internal Dictionary<FinalProduct, int> GetFinalProducts()
        {
            return this._FinalProducts;
        }
    }

  
}