using System;
using System.Numerics;


namespace App
{

    // This class represents the Final Product that is used to build the Bundle
    public class FinalProduct()
    {


        public string ProductName { get; set; }


        public FinalProduct(string productName) : this()

        {
            this.ProductName = productName;
        }
    }
}