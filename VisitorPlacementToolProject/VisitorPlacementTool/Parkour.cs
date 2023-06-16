using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Parkour
    {
        List<Group> groups;
        DateOnly dateOfEvent;
        int maxSeats = 28;
        int visitorAmount = 0;
        List<Group> groupsWithAdults = new List<Group>();
        List<Group> groupsWithKids = new List<Group>();

        List<Section> sections = new List<Section>();
        public Parkour(List<Group> Groups, DateOnly DateOfEvent)
        {
            groups = Groups;
            dateOfEvent = DateOfEvent;
        }

        public void ExecuteSorting()
        {
            visitorAmount = GetVisitorAmount();
            CreateSections();
            DetermineAge();
            SpitGroupsWithKids(groups);

            AssignSeatsToVisitors();
            foreach (var section in sections)
            {
                section.PrintSection();
            }
        }

        private void CreateSections()
        {
            Section sectionA = new Section("A", 3, 3);
            sections.Add(sectionA);
            Section sectionB = new Section("B", 2, 3);
            sections.Add(sectionB);
            Section sectionC = new Section("C", 3, 4);
            sections.Add(sectionC);
            Section sectionD = new Section("D", 1, 5);
            sections.Add(sectionD);

            foreach (var section in sections)
            {
                section.GenerateSection();
            }

        }

        private void DetermineAge()
        {
            foreach (var group in groups)
            {
                foreach (var visitor in group.GetVisitors())
                {
                    visitor.CalculateAge(dateOfEvent);
                }
            }
        }

        private void SpitGroupsWithKids(List<Group> groups)
        {
            foreach (var group in groups)
            {
                if (group.HasChildInGroup())
                {
                    groupsWithKids.Add(group);
                }
                else
                {
                    groupsWithAdults.Add(group);
                }
            }

        }


        private void AssignSeatsToVisitors()
        {
            foreach (var group in groupsWithKids)
            {
                foreach (var section in sections)
                {
                    Row firstRow = null;
                    foreach (var row in section.GetRows())
                    {
                        if (row.GetRowNumber() == 1)
                        {
                            firstRow = row;
                            break;
                        }
                    }
                    if (firstRow == null)
                    {
                        continue;
                    }
                    int numberOfEmptySeats = GetNumberOfSeatsEmptyInRow(firstRow);
                    if (numberOfEmptySeats >= (group.GetChildAmount() + 1) && (maxSeats - GetVisitorAmount()) >= group.GetVisitors().Count())
                    {
                        foreach (var seat in firstRow.getSeats())
                        {
                            foreach (var visitor in group.GetVisitors())
                            {
                                if (!seat.getIsTaken() && !visitor.isAssignedSeat)
                                {
                                    seat.SetVisitor(visitor);
                                    visitor.setAssignedSeat(seat);
                                }
                            }
                            
                        }
                        
                    }
                }

                
            }
            foreach (var group in groupsWithAdults)
            {
                if ((maxSeats - GetVisitorAmount()) >= group.GetVisitors().Count)
                {
                    foreach (var visitor in group.GetVisitors())
                    {
                        var seat = FindSeatForVisitor(visitor);
                        if (seat != null)
                        {
                            seat.SetVisitor(visitor);
                            visitor.setAssignedSeat(seat);
                            visitorAmount++;
                        }

                    }
                }
                else
                {
                    break;
                }
            }
        }

        private int GetNumberOfSeatsEmptyInRow(Row row)
        {
            int numberNotTaken = 0;

            foreach (var seat in row.getSeats())
            {
                if (!seat.getIsTaken())
                {
                    numberNotTaken++;
                }
            }
            return numberNotTaken;
        }

        
        private Seat FindSeatForVisitor(Visitor visitor)
        {
            if(visitor.GetIsAdult())
            {
                Seat firstAvailableSeat = null;

                foreach (Section section in sections)
                {
                    foreach (Row row in section.GetRows())
                    {
                        foreach (Seat seat in row.getSeats())
                        {
                            if (seat.getVisitor() == null)
                            {
                                firstAvailableSeat = seat;
                                break;
                            }
                        }

                        if (firstAvailableSeat != null)
                        {
                            break;
                        }
                    }

                    if (firstAvailableSeat != null)
                    {
                        break;
                    }
                }
                return firstAvailableSeat;
            }
            else
            {
                return null;
            }
        }

        public int GetVisitorAmount()
        {
            return visitorAmount;
        }
    }
}