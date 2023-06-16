using System.Text.RegularExpressions;
using VisitorPlacementTool;
using Xunit;
using Group = VisitorPlacementTool.Group;

namespace VisitorPlacementTest
{
    public class VisitorPlacementTest
    {
        [Fact]
        public void GenerateSection_CreateSection()
        {
            // Arrange
            int rows = 3;
            int cols = 6;
            Section section = new Section("A", rows, cols);
            // Act
            section.GenerateSection();

            // Assert
            Assert.Equal(rows, section.GetRows().Count());
            Assert.Equal(cols, section.GetRows().SelectMany(r => r.getSeats()).Count() / rows);
        }

        [Fact]
        public void GenerateSection_TooManyRows_DoesNotCreate()
        {
            // Arrange
            int rows = 5;
            int cols = 5;
            Section section = new Section("A", rows, cols);

            // Act & Assert
            Assert.Throws<Exception>(() => section.GenerateSection());
        }

        [Fact]
        public void GenerateSection_TooLittleRows_DoesNotCreate()
        {
            // Arrange
            int rows = 0;
            int cols = 5;
            Section section = new Section("A", rows, cols);

            // Act & Assert
            Assert.Throws<Exception>(() => section.GenerateSection());
        }

        [Fact]
        public void GenerateSection_TooManyCols_DoesNotCreate()
        {
            // Arrange
            int rows = 2;
            int cols = 15;
            Section section = new Section("A", rows, cols);

            // Act & Assert
            Assert.Throws<Exception>(() => section.GenerateSection());
        }
        
        [Fact]
        public void GenerateSection_TooLittleCols_DoesNotCreate()
        {
            // Arrange
            int rows = 2;
            int cols = 2;
            Section section = new Section("A", rows, cols);

            // Act & Assert
            Assert.Throws<Exception>(() => section.GenerateSection());
        }

        [Fact]
        public void AddGroupsToSeats_KidsInFrontRow_SortingSuccess()
        {
            // Arrange
            Group group1 = new Group(1);
            group1.AddVisitor(new Visitor("John Doe", new DateOnly(2014, 8, 15), new DateOnly(2023, 6, 2), group1));
            group1.AddVisitor(new Visitor("Jane Smith", new DateOnly(2016, 3, 10), new DateOnly(2023, 6, 2), group1));
            group1.AddVisitor(new Visitor("Alice Johnson", new DateOnly(1987, 11, 25), new DateOnly(2023, 6, 3), group1));
            List<Group> groups = new List<Group>();
            groups.Add(group1);
            DateOnly dateOfEvent = new DateOnly(2023, 5, 5);
            Parkour parkour = new Parkour(groups, dateOfEvent);

            // Act
            parkour.ExecuteSorting();
            // Assert
            Assert.True(group1.GetVisitors().Where(v => v.assignedSeat.getRow() == 1).Count() == 3);
        }

        [Fact]
        public void DetermineAge_AgeShouldBeCorrect()
        {
            // Arrange
            int yearOfBirth = 2000;
            Group group1 = new Group(1);
            Visitor vister = new Visitor("John Doe", new DateOnly(yearOfBirth, 8, 15), new DateOnly(2023, 6, 2), group1);
            group1.AddVisitor(vister);
            List<Group> groups = new List<Group>();
            groups.Add(group1);
            DateOnly dateOfEvent = new DateOnly(2023, 5, 5);
            int age = dateOfEvent.Year - yearOfBirth;
            Parkour parkour = new Parkour(groups, dateOfEvent);

            // Act
            parkour.ExecuteSorting();

            // Assert
            Assert.Equal(age, vister.GetAge());
        }
    }
}