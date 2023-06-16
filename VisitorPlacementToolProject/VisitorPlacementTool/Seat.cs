using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Seat
    {
        private string Section;
        private int Row;
        private int Number;
        private string Code;
        private bool isTaken;

        private Visitor visitor;

        public Seat(string section, int row, int number)
        {
            Section = section;
            Row = row;
            Number = number;
            Code = $"{section}{row}-{number}";
        }

        public string GetCode()
        {
            return Code;
        }
        public int getRow()
        {
            return Row;
        }

        public void SetVisitor(Visitor setVisitor)
        {
            visitor = setVisitor;
            isTaken = true;
        }

        public Visitor getVisitor()
        {
            return visitor;
        }

        public bool getIsTaken()
        {
            return isTaken;
        }
    }
}
