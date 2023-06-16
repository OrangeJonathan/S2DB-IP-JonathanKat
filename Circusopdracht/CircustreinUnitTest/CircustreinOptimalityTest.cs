using Microsoft.VisualStudio.TestPlatform.TestHost;
using Circusopdracht;

namespace CircustreinUnitTest
{
    [TestClass]
    public class CircustreinOptimalityTest
    {
        //NewAnimal(Size.small, Diet.carnivore, animals);
        //NewAnimal(Size.medium, Diet.carnivore, animals);
        //NewAnimal(Size.large, Diet.carnivore, animals);
        //NewAnimal(Size.small, Diet.herbivore, animals);
        //NewAnimal(Size.medium, Diet.herbivore, animals);
        //NewAnimal(Size.large, Diet.herbivore, animals);



        [TestMethod]
        public void TestScenario1()
        {
            // Arrange
            var expectedResult = 2;
            
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));

            // Act
            train.DistributeAnimalsToWagons(animals);

            // Assert
            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario2()
        {
            // Arrange
            var expectedResult = 2;
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));


            // Act
            train.DistributeAnimalsToWagons(animals);

            // Assert
            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario3()
        {
            // Arrange
            var expectedResult = 4;
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.carnivore));
            animals.Add(new Animal(Size.large, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));


            // Act
            train.DistributeAnimalsToWagons(animals);

            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario4()
        {
            // Arrange
            var expectedResult = 5;

            // Act
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.carnivore));
            animals.Add(new Animal(Size.large, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            NewAnimal(Size.large, Diet.herbivore, animals);

            train.DistributeAnimalsToWagons(animals);

            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario5()
        {
            // Arrange
            var expectedResult = 2;

            // Act
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));

            train.DistributeAnimalsToWagons(animals);

            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario6()
        {
            // Arrange
            var expectedResult = 3;

            // Act
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));

            train.DistributeAnimalsToWagons(animals);

            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        [TestMethod]
        public void TestScenario7()
        {
            // Arrange
            var expectedResult = 13;

            // Act
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.small, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.carnivore));
            animals.Add(new Animal(Size.large, Diet.carnivore));
            animals.Add(new Animal(Size.large, Diet.carnivore));
            animals.Add(new Animal(Size.large, Diet.carnivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.medium, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));
            animals.Add(new Animal(Size.large, Diet.herbivore));

            train.DistributeAnimalsToWagons(animals);

            Assert.AreEqual(expectedResult, train.GetAmountOfWagons());
            Assert.IsTrue(train.IsTrainFilledCorrectly(train));
        }

        void NewAnimal(Size size, Diet food, List<Animal> animals)
        {
            Animal animal = new Animal(size, food);
            animals.Add(animal);
        }


    }
}