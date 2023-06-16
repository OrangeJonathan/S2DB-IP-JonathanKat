using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Group
    {
        private List<Visitor> visitors = new List<Visitor>();
        private int ID;

        public Group(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }
        public bool HasChildInGroup()
        {
            foreach (var visitor in visitors)
            {
                if (visitor.GetAge() <= 12)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddVisitor(Visitor visitor)
        {
            visitors.Add(visitor);
        }

        public void RemoveVisitor(Visitor visitor)
        {
            visitors.Remove(visitor);
        }

        public List<Visitor> GetVisitors()
        {
            return visitors;
        
        
        }

        public int GetChildAmount()
        {
            int childAmount = 0;
            foreach (var visitor in visitors)
            {
                if (visitor.GetAge() <= 12)
                {
                    childAmount++;
                }
            }
            return childAmount;

        }


    }
}
