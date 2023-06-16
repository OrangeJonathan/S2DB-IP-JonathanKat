using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circusopdracht
{
    public class Wagon // OO principes: encapsulation
    {
        // capacity is 10 by default
        private int capacity = 10;
        public int getCapacity()
        {
            return capacity;
        }

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        private readonly List<Animal> animalList = new();

        public List<Animal> GetAnimalList()
        {
            return animalList;
        }

        // Empty Constructor looks weird, but it's used in train.cs
        public Wagon()
        {
        }

        public Wagon(Animal animal)
        {
            AddAnimalToWagon(animal);
        }

        
        public void AddAnimalToWagon(Animal animal)
        {
            bool canAdd = CanAnimalBeAddedToWagon(animal);

            if(canAdd)
            {
                animalList.Add(animal);
                capacity -= Convert.ToInt32(animal.getSize());
            }
            
        }

        public bool CanAnimalBeAddedToWagon(Animal animal)
        {
            bool canAdd = true;

            if ((animalList.Count != 0))
            {
                if (((int)animal.getSize()) <= capacity)
                {
                    canAdd = true;
                    foreach (Animal listAnimal in animalList)
                    {
                        canAdd = animal.CanAddAnimal(animal, listAnimal);
                    }
                }
                else
                {
                    canAdd = false;
                }
            }

            return canAdd;
        }

        
        // ability to write all the animals in the list of the Wagon
        public void WriteAnimalList()
        {
            
            foreach (Animal animal in animalList)
            {
                Console.WriteLine(animal.getSize() + " " + animal.getDiet());
            }
            
            Console.WriteLine("Capacity: " + capacity);
            Console.WriteLine(" ");
        }
    }
}
