using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Visitor
    {
        private string id;
        private string name;
        private DateOnly birthDate;
        private int age;
        private DateOnly dateSignedUp;
        private bool isAdult;
        private Group group;
        public bool isAssignedSeat { get; private set; }
        public Seat assignedSeat { get; private set; }
        public Visitor(string Name, DateOnly Birthdate, DateOnly DateSignedUp, Group group)
        {
            name = Name;
            birthDate = Birthdate;
            dateSignedUp = DateSignedUp;
            

            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }

            this.group = group;
        }

        public void setAssignedSeat(Seat seat)
        {
            assignedSeat = seat;
            isAssignedSeat = true;
        }
        public Group GetGroup()
        {
            return group;
        }

        

        public void CalculateAge(DateOnly DateOfEvent)
        {
            age = DateOfEvent.Year - birthDate.Year;
            if (age >= 12)
            {
                isAdult = true;
            }
            else
            {
                isAdult = false;
            }
        }

        public bool GetIsAdult()
        {
            return isAdult;
        }

        public int GetAge()
        {
            return age;
        }

        public string GetName()
        {
            return name;
        }

    }
}
