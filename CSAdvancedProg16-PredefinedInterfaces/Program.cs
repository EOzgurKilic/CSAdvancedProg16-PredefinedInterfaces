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
            
            
            #region ICloneable
            //Noting that Prototype design pattern is recommended for cloning action rather than ICloneable Implementation as Its claimed that this interface..
            //.. causes problems.
            /*Person3 humanBeing1 = new Person3(){Age = 25, Name = "John Doe", Human = new Person2(){Age = 25, Name = "John Doe"}};
            Person3 humanBeing2 = (Person3)humanBeing1.Clone();
            humanBeing2.Age = 15; //Since Age was a value type, this change won't affect humanBeing1's same member
            humanBeing2.Human.Name = "Efe"; //humanBeing1's Human member's Name parameter will change onto "Efe" as well.
            Console.WriteLine(humanBeing1.Human.Name);*/

            #endregion
            
            
            #region INotifyPropertyChanged
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
    
    
    #region ICloneable
    class Person3 : ICloneable
    {
        internal string Name { get; set; }
        internal int Age { get; set; }
        internal Person2 Human { get; set; }

        public Object Clone()
        {
            //return this.MemberwiseClone(); //This is the common way returning the clone of the relevant instance.
            //It performs a shallow copy, which is to perform deep copy of the primitive & value type members of the relevant class and..
            //reference (shallow) the reference type members
            //So Name and Age won't be affected but Human will be for the cloned instance just as they get changed over the clone instance.
            
            //Instead the method above, you can manually do the same thingie it does;
            return new Person3() {Name = this.Name, Age = this.Age, Human = this.Human }; //Evenn this way, as you may estimate, Human of the cloned object..
            //will be logically affected if the same member of the clone object gets changed in any aspect.
        }
        
        #region INotifyPropertyChanged
        #endregion
    }
    #endregion
}
