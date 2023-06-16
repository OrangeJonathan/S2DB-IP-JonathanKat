using VisitorPlacementTool;

List<Visitor> visitors = new List<Visitor>();
List<Group> groups = new List<Group>();
DateOnly dateOfEvent;
//PromptCreateEvent();
//PromptRegisterVisitor();

Group group1 = new Group(1);
Group group2 = new Group(2);
Group group3 = new Group(3);
Group group4 = new Group(4);
Group group5 = new Group(5);
group2.AddVisitor(new Visitor("Stijn van den Hurk", new DateOnly(2004, 8, 5), new DateOnly(2023, 6, 7), group2));
group2.AddVisitor(new Visitor("Joost Raemakers", new DateOnly(2002, 9, 2), new DateOnly(2023, 6, 6), group2));
group2.AddVisitor(new Visitor("Jonathan Kat", new DateOnly(2005, 5, 18), new DateOnly(2023, 5, 18), group2));
group2.AddVisitor(new Visitor("Billy Hofland", new DateOnly(2004, 7, 14), new DateOnly(2023, 5, 30), group2));
group1.AddVisitor(new Visitor("John Doe", new DateOnly(2014, 8, 15), new DateOnly(2023, 6, 2), group1));
group1.AddVisitor(new Visitor("Jane Smith", new DateOnly(2016, 3, 10), new DateOnly(2023, 6, 2), group1));
group1.AddVisitor(new Visitor("Alice Johnson", new DateOnly(1987, 11, 25), new DateOnly(2023, 6, 3), group1));
group3.AddVisitor(new Visitor("Rowan van der Weel", new DateOnly(2004, 7, 13), new DateOnly(2023, 6, 2), group3));
group3.AddVisitor(new Visitor("Josje Sneijders", new DateOnly(2003, 8, 15), new DateOnly(2023, 6, 2), group3));
group4.AddVisitor(new Visitor("Liam Smulders", new DateOnly(2012, 1, 14), new DateOnly(2023, 5, 18), group4));
group4.AddVisitor(new Visitor("Bas van Beem", new DateOnly(2017, 5, 7), new DateOnly(2023, 5, 18), group4));
group4.AddVisitor(new Visitor("Floor Bruers", new DateOnly(2016, 4, 19), new DateOnly(2023, 5, 18), group4));
group4.AddVisitor(new Visitor("Hendrik Somers", new DateOnly(2003, 9, 12), new DateOnly(2023, 5, 18), group4));
group5.AddVisitor(new Visitor("Abraham", new DateOnly(1973, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Sarah", new DateOnly(1973, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Kain", new DateOnly(2000, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Adam", new DateOnly(1980, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Eva", new DateOnly(1998, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Judas", new DateOnly(0001, 12, 24), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Jezus", new DateOnly(0001, 12, 24), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Abel", new DateOnly(1956, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Noah", new DateOnly(1957, 9, 12), new DateOnly(2023, 5, 18), group5));
group5.AddVisitor(new Visitor("Mozes", new DateOnly(2000, 9, 12), new DateOnly(2023, 5, 18), group5));


groups.Add(group1);
groups.Add(group2);
groups.Add(group3);
groups.Add(group4);
groups.Add(group5);

void PromptCreateEvent()
{
    Console.WriteLine("What is the date of the Event?");
    Console.WriteLine("Year?");
    int year = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Month? (number)");
    int month = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Day (number)");
    int day = Convert.ToInt32(Console.ReadLine());
    DateOnly eventDate = new DateOnly(year, month, day);
    dateOfEvent = eventDate;
}

// dit is puur als de visitors echt handmatig handmatig worden toegevoegd.
void PromptRegisterVisitor()
{
    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    Console.WriteLine("What is your birthdate?");
    Console.WriteLine("Year?");
    int year = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Month? (number)");
    int month = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Day (number)");
    int day = Convert.ToInt32(Console.ReadLine());
    DateOnly eventDate = new DateOnly(year, month, day);
    Console.WriteLine("Have you been to one of our events before? (true/false)");
    bool hasBeenBefore = Convert.ToBoolean(Console.ReadLine());
}



PromptCreateEvent();
Parkour parkour = new Parkour(groups, dateOfEvent);
parkour.ExecuteSorting();
