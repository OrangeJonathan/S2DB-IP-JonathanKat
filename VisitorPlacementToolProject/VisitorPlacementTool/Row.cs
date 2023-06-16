using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Row
    {
        private string Section;
        private int Number;
        private List<Seat> Seats;

        

        public Row(string section, int number, int length)
        {
            Section = section;
            Number = number;
            Seats = new List<Seat>();
            for (int i = 1; i <= length; i++)
            {
                Seats.Add(new Seat(section, number, i));
            }

            
        }

        public int GetRowNumber()
        {
            return Number;
        }

        public List<Seat> getSeats()
        {
            return Seats;
        }

    }
}
