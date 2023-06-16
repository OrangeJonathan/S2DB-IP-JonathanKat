using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Section
    {
        private string letter;
        private int numberOfRows;
        private int numberOfColumns;
        
        private List<Row> Rows;

        public Section(string Letter, int numberOfRows, int numberOfColumns)
        {
            letter = Letter;
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
        }

        public void GenerateSection()
        {
            int columnAmount = numberOfColumns;
            int RowAmount = numberOfRows;

            if (RowAmount < 1 || RowAmount > 3)
            {
                throw new Exception("Invalid Row Amount");

            }if (columnAmount < 3 || columnAmount > 10)
            {
                throw new Exception("Invalid column Amount");
            }

            Rows = new List<Row>();
            for (int i = 1; i <= RowAmount; i++)
            {
                Rows.Add(new Row(letter, i, columnAmount));
            }
        }

        public List<Row> GetRows()
        {
            return Rows;
        }

        public void PrintSection()
        {
            foreach (Row row in Rows)
            {
                foreach (Seat seat in row.getSeats())
                {
                    if (seat.getVisitor() != null)
                    {
                        Console.Write(@"(" + seat.GetCode() + " " + seat.getVisitor().GetName() + " " + seat.getVisitor().GetAge() + " G"+seat.getVisitor().GetGroup().GetID() + ")");
                        Console.Write(@" ");
                    }
                    else
                    {
                        Console.Write("(" + seat.GetCode() + " Empty" + ")");
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
        }

        private int GenerateRandomColumnAmount()
        {
            Random random = new Random();
            int Column = random.Next(3, 11);
            return Column;
        }
        private int GenerateRandomRowAmount()
        {
            Random random = new Random();
            int rowLenght = random.Next(1, 4);
            return rowLenght;
        }

    }
}
