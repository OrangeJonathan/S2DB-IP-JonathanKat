using Circusopdracht;


List<Animal> animals = new List<Animal>();
Train train = new Train();

bool isFilledCorrectly;
List<Circusopdracht.Size> sizeTypeList = new List<Circusopdracht.Size> { Circusopdracht.Size.small, Circusopdracht.Size.medium, Circusopdracht.Size.large };
List<Diet> dietList = new List<Diet> { Diet.carnivore, Diet.herbivore};

/* Choose how you want the animals to be entered into the algorithm
   by Uncommenting the function you want to use */

//PromptCreateAnimal();
//CreateRandomAnimals();
CreateHardCodeAnimals();

// execute the algorithm functions
train.DistributeAnimalsToWagons(animals);
isFilledCorrectly = train.IsTrainFilledCorrectly(train);
train.PrintWagons();
Console.WriteLine(isFilledCorrectly);



// if error = not used, then it's not used at the top of the file, probably because another option is enabled, this is normal
void PromptCreateAnimal()
{
    string sizePrompt = "";
    string dietPrompt = "";
    Console.WriteLine("Enter a Size:");
    Console.WriteLine("small");
    Console.WriteLine("medium");
    Console.WriteLine("large");
    Console.WriteLine(" ");
    sizePrompt = Console.ReadLine();
    Circusopdracht.Size size = (Circusopdracht.Size)Enum.Parse(typeof(Circusopdracht.Size), sizePrompt);
    Console.Clear();
    Console.WriteLine("Enter a Diet:");
    Console.WriteLine("herbivore");
    Console.WriteLine("carnivore");
    Console.WriteLine(" ");
    dietPrompt = Console.ReadLine();
    Diet food = (Diet)Enum.Parse(typeof(Diet), dietPrompt);
    Console.Clear();


    NewAnimal(size, food);


    Console.WriteLine("Create new Animal?");
    Console.WriteLine("yes");
    Console.WriteLine("no");
    Console.WriteLine(" ");
    if (Console.ReadLine() == "yes")
    {
        Console.Clear();
        PromptCreateAnimal();
        
    }
}

// if error = not used, then it's not used at the top of the file, probably because another option is enabled, this is normal
void CreateRandomAnimals()
{
    // change the number behind i < __ to the amount of Animals you want to generate

    for (int i = 0; i < 100; i++)
    {
        Random random = new Random();
        int indexS = random.Next(3);
        Circusopdracht.Size sizeR = sizeTypeList[indexS];
        int indexD = random.Next(2);
        Diet dietR = dietList[indexD];

        NewAnimal(sizeR, dietR);
    }
    
}

// if error = not used, then it's not used at the top of the file, probably because another option is enabled, this is normal
void CreateHardCodeAnimals()
{
    // just copy the ones you want to add and comment the ones you dont.
    NewAnimal(Size.small, Diet.carnivore);
    NewAnimal(Size.small, Diet.carnivore);
    NewAnimal(Size.small, Diet.carnivore);
    NewAnimal(Size.medium, Diet.herbivore);
    NewAnimal(Size.medium, Diet.herbivore);
    NewAnimal(Size.large, Diet.herbivore);
    NewAnimal(Size.large, Diet.herbivore);
    NewAnimal(Size.large, Diet.herbivore);
}


void NewAnimal(Size size, Diet food)
{

    Animal animal = new Animal(size, food);
    animals.Add(animal);

}



