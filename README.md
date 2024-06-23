# Qoblex Technical Test Answer !

Hi ! I am Issiakhem Ramzi from Algeria, I'm currently taking part of your recruitment process regarding Qoblex.
I will summarize the answer given in this README File.

# Step 1: The "Bundle Processing" Application 
Just a basic name to describe the Console Application developped in C# following the .NET Runtime Environnement, used to calculate how much of A bundle we can build with a predifined structure and Inventory.

The principe is simple; we have a *Bundle* that consists of *FinalProducts* and *Bundles*.
We gather the structure of any *Bundle* using User Interaction within the console.
Each time we need to gather the structure of a *Bundle* the same method "*generateBundleTreeFromConsoleInput*" is called followed with a logic to merge the trees.
This helps to maintain a certain coherence and reusabilty in the code 
 
## The Project's Structure
- *Program Class*: responsible of the integration of all the console backbone and logic.
- *Bundle*: responsible of the Bundle's Tree Generation and Management.
- *Inventory*: responsible of the Inventory Management ( Add,Substract... ) and the calculation of the maximum amount of Bundle capable to construct.
- *ConsoleUtils*: Utilities to help and organize the Interaction with the user using the console.
- *Product*: The Final Product Class
- *EFCORE*: All The classes structure following the UML Structure Proposed   

# Step 2: UML Diagram
- A Bundle can have 0 or Many Bundles and each one with a certain amount needed to construct it.
- A Bundle can have 0 or Many FinalProducts and each one with a certain amount needed to construct it.
- Each Final Product is part of the Inventory and each Inventory Unit has only one Final Product

# Step 3: EF CORE
You can find all the Structure in the *EFCORE.cs" File.
The DB used is SQLite to make the testing process easier.

To Execute the Migration:

    Add Migration Init

To Update the Database:

    Update-Database


 
