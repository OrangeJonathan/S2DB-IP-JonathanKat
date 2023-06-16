 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Circusopdracht
{
    // Enumerator of Size
    public enum Size
    {
        small = 1,
        medium = 3,
        large = 5
    }
    // Enumerator of Diet
    public enum Diet
    {
        herbivore,
        carnivore,
    }

    public class Animal
    {
        private Size size;
        private Diet diet;
        
        public Size getSize()
        {
            return size;
        }

        public Diet getDiet()
        {
            return diet;
        }

        public Animal(Size animalSize, Diet animalFood)
        {
            this.size = animalSize;
            this.diet = animalFood;
        }

        public bool CanAddAnimal(Animal animal1, Animal animal2)
        {
            bool canAdd = false;

            if ((animal1.getDiet() == Diet.carnivore) && (animal2.getDiet() == Diet.carnivore))
            {
                canAdd = false;

            }
            else
            {
                canAdd = true;
            }

            return canAdd;
        }
    }
}
