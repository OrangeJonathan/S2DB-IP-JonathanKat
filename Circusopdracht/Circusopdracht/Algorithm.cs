using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circusopdracht
{
    internal class Algorithm
    {
        private List<Wagon> wagonList = new();
        private List<Animal> carnivoreList = new();
        private List<Animal> herbivoreList = new();
        private List<Animal> smallHerbivoreList = new();
        private List<Animal> mediumHerbivoreList = new();
        private List<Animal> largeHerbivoreList = new();

        public void SplitCarnivoreHerbivore(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {

                if (animal.Food == Diet.carnivore)
                {
                    carnivoreList.Add(animal);

                }

                if (animal.Food == Diet.herbivore)
                {
                    herbivoreList.Add(animal);
                }
            }
        }
        public void SplitHerbivores()
        {
            foreach (Animal animal in herbivoreList)
            {

                if (animal.Size == SizeType.small)
                {
                    smallHerbivoreList.Add(animal);

                }

                if (animal.Size == SizeType.medium)
                {
                    mediumHerbivoreList.Add(animal);
                }

                if (animal.Size == SizeType.large)
                {
                    largeHerbivoreList.Add(animal);
                }
            }
        }

        public void SortCarnivoreList()
        {
            Animal temp;

            for (int i = 0; i < carnivoreList.Count; i++)
            {
                for (int j = 0; j < carnivoreList.Count - 1; j++)
                {
                    if (((int)carnivoreList[j].Size) > ((int)carnivoreList[j + 1].Size))
                    {
                        temp = carnivoreList[j + 1];
                        carnivoreList[j + 1] = carnivoreList[j];
                        carnivoreList[j] = temp;
                    }
                }
            }

            carnivoreList.Reverse();
        }

        public void WagonCarnivore()
        {
            foreach (Animal animal in carnivoreList)
            {
                if (animal.Size == SizeType.large)
                {
                    Wagon largeCarnivoreWagon = new Wagon(animal);
                    wagonList.Add(largeCarnivoreWagon);
                }
                else
                {
                    Wagon wagon = new Wagon(animal);
                    wagonList.Add(wagon);
                }
            }
        }

        public void WagonHerbivore()
        {
            foreach (Wagon wagon in wagonList)
            {
                List<Animal> animalList = wagon.GetAnimalList();

                foreach (Animal animal in animalList.ToList())
                {

                    if ((animal.Size == SizeType.large) && (animal.Food == Diet.carnivore))
                    {
                        continue;
                    }

                    if((animal.Size == SizeType.medium) && (animal.Food == Diet.carnivore))
                    {
                        while (largeHerbivoreList.Count != 0)
                        {
                            while (wagon.Capacity >= (int)largeHerbivoreList[0].Size)
                            {
                                wagon.AddAnimal(largeHerbivoreList[0]);
                                largeHerbivoreList.RemoveAt(0);
                                if (largeHerbivoreList.Count == 0 || (wagon.Capacity < (int)SizeType.large))
                                {
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    if ((animal.Size == SizeType.small) && (animal.Food == Diet.carnivore))
                    {
                        
                        if (mediumHerbivoreList.Count != 0)
                        {
                            while(wagon.Capacity >= (int)mediumHerbivoreList[0].Size)
                            {
                                wagon.AddAnimal(mediumHerbivoreList[0]);
                                mediumHerbivoreList.RemoveAt(0);

                                if (mediumHerbivoreList.Count == 0 || (wagon.Capacity < (int)SizeType.medium))
                                {
                                    break;
                                }
                            }
                        }

                        if (largeHerbivoreList.Count != 0)
                        {
                            while (wagon.Capacity >= (int)largeHerbivoreList[0].Size)
                            {
                                wagon.AddAnimal(largeHerbivoreList[0]);
                                largeHerbivoreList.RemoveAt(0);

                                if (largeHerbivoreList.Count == 0 || (wagon.Capacity < (int)SizeType.small))
                                {
                                    break;
                                }
                                break;
                            }
                        }   
                    }
                }
            }

            while (largeHerbivoreList.Count != 0 || mediumHerbivoreList.Count != 0 || smallHerbivoreList.Count != 0)
            {
                Wagon wagon = new Wagon();
                wagonList.Add(wagon);

                if (largeHerbivoreList.Count != 0)
                {
                    while (wagon.Capacity >= (int)SizeType.large)
                    {
                        wagon.AddAnimal(largeHerbivoreList[0]);
                        largeHerbivoreList.RemoveAt(0);

                        if ((largeHerbivoreList.Count == 0) || (wagon.Capacity < (int)SizeType.large))
                        {
                            break;
                        }

                    }
                }

                if (mediumHerbivoreList.Count != 0)
                {
                    while (wagon.Capacity >= (int)SizeType.medium)
                    {
                        wagon.AddAnimal(mediumHerbivoreList[0]);
                        mediumHerbivoreList.RemoveAt(0);

                        if (mediumHerbivoreList.Count == 0 || (wagon.Capacity < (int)SizeType.medium))
                        {
                            break;
                        }

                    }
                }

                if (smallHerbivoreList.Count != 0)
                {
                    while (wagon.Capacity >= (int)SizeType.small)
                    {
                        wagon.AddAnimal(smallHerbivoreList[0]);
                        smallHerbivoreList.RemoveAt(0);

                        if (smallHerbivoreList.Count == 0 || (wagon.Capacity < (int)SizeType.small))
                        {
                            break;
                        }
                    }
                }
            }
        }


        

    }
}
