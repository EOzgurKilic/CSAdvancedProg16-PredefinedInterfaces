namespace CSAdvancedProg16_PredefinedInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Special Interfaces (.net architecture provides)

            #region IComparer
            //Used to compare objects.
            //It has normal and generic(type safety) versions.
            //Commonly used while ordering collections.
            Person p1 = new Person() {Name = "Efe" , Age = 23 };
            Person p2 = new Person() {Name = "Özgür" , Age = 32 };
            Person p3 = new Person() {Name = "Kılıç" , Age = 31 };
            Person p4 = new Person() {Name = "Sabrina" , Age = 25 };
            Person p5 = new Person() {Name = "Carpenter" , Age = 85 };
            List<Person> PList = new List<Person>() { p1, p2, p3, p4, p5 };
            PList.Sort(new AgeComparer());
            Action<Person> PersonDelegate = new Action<Person>(Printer);
            PList.ForEach(PersonDelegate);
            void Printer(Person a)
            { 
                Console.WriteLine(a.Name); 
            }
            
            #endregion
        }

    }

    #region IComparer
    class Person { internal string Name { get; set; } internal int Age { get; set; } }
    class AgeComparer : IComparer<Person> { 
        public int Compare(Person? a, Person? b) 
        {
            return a.Age.CompareTo(b.Age);
        } 
    }

    #endregion
}
