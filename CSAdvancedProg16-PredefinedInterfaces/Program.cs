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
            /*Person p1 = new Person() {Name = "Efe" , Age = 23 };
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
            }*/

            #endregion

            
            #region IComparable
            //Pretty much doing the same thingie IComparer does but we are not creating an additional class containing our comparison method.
            /*Person2 person3 = new Person2() {Age = 20, Name="Efe" };
            Person2 person4 = new Person2() { Age = 25, Name = "Cato" };
            switch(person3.CompareTo(person4)) {
                case 1:
                    Console.WriteLine("Higher");
                    break;
                case 0:
                    Console.WriteLine("Equal");
                    break;
                case -1:
                    Console.WriteLine("Lower");
                    break;
            }*/

            #endregion
        }

    }

    #region IComparer
    class Person { internal string Name { get; set; } internal int Age { get; set; } }
    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person? a, Person? b)
        {
            return a.Age.CompareTo(b.Age);
        }
    }

    #endregion


    #region IComparable
    class Person2 : IComparable<Person2> 
    {
        internal string Name { get; set; }
        internal int Age { get; set; }
        public int CompareTo(Person2 a) { return this.Age.CompareTo(a.Age); }
    }
    #endregion
}
