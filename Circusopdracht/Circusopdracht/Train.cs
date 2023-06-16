using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circusopdracht
{
    public class Train
    {

        private readonly List<Wagon> wagonList = new();
        private readonly List<Animal> carnivoreList = new();
        private readonly List<Animal> smallHerbivoreList = new();
        private readonly List<Animal> mediumHerbivoreList = new();
        private readonly List<Animal> largeHerbivoreList = new();

        public void DistributeAnimalsToWagons(List<Animal> animals)
        {
            SplitAndSortCarnivoreHerbivore(animals);
            CreateWagonForEachCarnivore();
            PutHerbivoresIntoTheWagons();
        }

        public void PrintWagons()
        {
            int i = 1;

            // for every wagon in the list of wagons
            foreach (Wagon wagon in wagonList)
            {
                // print
                Console.WriteLine("Wagon " + i);
                Console.WriteLine("------------");

                wagon.WriteAnimalList();
                i++;
            }
        }

        public void SplitAndSortCarnivoreHerbivore(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                if (animal.getDiet() == Diet.carnivore)
                {
                    carnivoreList.Add(animal);
                }

                if (animal.getDiet() == Diet.herbivore)
                {
                    switch (animal.getSize())
                    {
                        case Size.small:
                            smallHerbivoreList.Add(animal);
                            break;
                        case Size.medium:
                            mediumHerbivoreList.Add(animal);
                            break;
                        case Size.large:
                            largeHerbivoreList.Add(animal);
                            break;
                        default:
                            Console.Beep();
                            Console.WriteLine("An animal was made without a size and could not be sorted");
                            break;
                    }
                }
            }
            // If the splitting of the animal types is done, sort the carnivore list
            SortCarnivoreListBySize();
        }

        public void SortCarnivoreListBySize()
        {
            // this is insertion sort
            for (int i = 0; i < carnivoreList.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (((int)carnivoreList[j - 1].getSize()) > ((int)carnivoreList[j].getSize()))
                    {
                        Animal temp = carnivoreList[j - 1];
                        carnivoreList[j - 1] = carnivoreList[j];
                        carnivoreList[j] = temp;
                    }
                }
            }
            carnivoreList.Reverse();
        }

        public void CreateWagonForEachCarnivore()
        {
            foreach (Animal animal in carnivoreList)
            {
                Wagon wagon = new Wagon(animal);
                wagonList.Add(wagon);
            }
        }
        public void PutHerbivoresIntoTheWagons()
        {

            foreach (Wagon wagon in wagonList)
            {

                List<Animal> animalList = wagon.GetAnimalList();


                foreach (Animal animal in animalList.ToList())
                {

                    if ((animal.getSize() == Size.large) && (animal.getDiet() == Diet.carnivore))
                    {
                        break;
                    }

                    if ((animal.getSize() == Size.medium) && (animal.getDiet() == Diet.carnivore))
                    {
                        AddLargeHerbivoreToWagon(wagon);
                    }

                    if ((animal.getSize() == Size.small) && (animal.getDiet() == Diet.carnivore))
                    {
                        if (mediumHerbivoreList.Count >= 3)
                        {
                            AddMediumHerbivoreToWagon(wagon);
                        }
                        AddLargeHerbivoreToWagon(wagon);
                        AddMediumHerbivoreToWagon(wagon);
                    }
                }
            }

            // Whilst the herbivore lists aren't empty
            while (largeHerbivoreList.Count != 0 || mediumHerbivoreList.Count != 0 || smallHerbivoreList.Count != 0)
            {
                Wagon wagon = new Wagon();
                wagonList.Add(wagon);

                foreach (Animal animal in largeHerbivoreList.ToList())
                {
                    AddLargeHerbivoreToWagon(wagon);
                }

                foreach (Animal animal in mediumHerbivoreList.ToList())
                {
                    AddMediumHerbivoreToWagon(wagon);
                }

                foreach (Animal animal in smallHerbivoreList.ToList())
                {
                    AddSmallHerbivoreToWagon(wagon);
                }
            }

        }

        // These functions are used to add the different Herbivores to the Wagon
        public void AddLargeHerbivoreToWagon(Wagon wagon)
        {
            while ((largeHerbivoreList.Count > 0) && (wagon.CanAnimalBeAddedToWagon(largeHerbivoreList[0])))
            {
                wagon.AddAnimalToWagon(largeHerbivoreList[0]);
                largeHerbivoreList.RemoveAt(0);

            }

        }

        public void AddMediumHerbivoreToWagon(Wagon wagon)
        {
            while ((mediumHerbivoreList.Count > 0) && (wagon.CanAnimalBeAddedToWagon(mediumHerbivoreList[0])))
            {

                wagon.AddAnimalToWagon(mediumHerbivoreList[0]);
                mediumHerbivoreList.RemoveAt(0);

            }
        }

        public void AddSmallHerbivoreToWagon(Wagon wagon)
        {
            while ((smallHerbivoreList.Count > 0) && wagon.CanAnimalBeAddedToWagon(smallHerbivoreList[0]))
            {
                wagon.AddAnimalToWagon(smallHerbivoreList[0]);
                smallHerbivoreList.RemoveAt(0);
            }
        }

        public bool IsTrainFilledCorrectly(Train train)
        {
            bool isFilledCorrectly = false;

            foreach (Wagon wagon in train.wagonList)
            {
                int animalCount = 0;
                int trueCapacity = 0;
                int carnivoreCount = 0;
                int currentCarnivoreSize = 0;
                foreach (Animal animal in wagon.GetAnimalList())
                {
                    animalCount++;
                    trueCapacity += ((int)animal.getSize());
                    if (animal.getDiet() == Diet.carnivore)
                    {
                        carnivoreCount++;
                        if (carnivoreCount >= 2)
                        {
                            isFilledCorrectly = false;
                            break;
                        }
                        currentCarnivoreSize = ((int)animal.getSize());
                    }
                    if ((animal.getDiet() == Diet.herbivore) && (((int)animal.getSize()) < currentCarnivoreSize))
                    {
                        isFilledCorrectly = false;
                        break;
                    }
                    if (animalCount == wagon.GetAnimalList().Count)
                    {
                        isFilledCorrectly = true;
                    }

                }
            }

            return isFilledCorrectly;
        }

        public int GetAmountOfWagons()
        {
            int wagonCount = wagonList.Count();
            return wagonCount;
        }

    }
}

