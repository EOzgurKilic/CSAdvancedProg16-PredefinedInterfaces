using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

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
            //Used to get notified via an event as a property is changed in any aspect.
            Person4 person41 = new(); //Be careful about object initializer here because the setter of the properties are..
                                      //.. called here which means that our event is to be triggered and before adding such a method below to the event, it causes errors.
                                      //You better create the instance not triggering any properties and then modify them after adding the method(delegate) below
            /*person41.PropertyChanged += (sender, e) => { Console.WriteLine($"{e.PropertyName} is changed with {(sender as Person4)?.Age}."); };
             person41.Age = 26;
             person41.Age = 27;
             person41.Age = 28;
             person41.Age = 29;*/

            #endregion


            #region IEquatable
            //We will use this one to compare two instances in equality aspect.
            //With a method you might be familiar to, "Equals()"
            //When used with especially collections, it has favourable performance efficiency.
            //We should not forget about the usage availability of records rather than implementing this interface to the classes, ..
            //.. these abilities the relevant interface provides to the implementing classes are available in default in records. However, even a single..
            //.. property is not the same with the other object in records, you will get a negative in comparisons whereas you can specify which members of..
            //.. the class will be checked with IEquatable interface, within the body of the Equals mehtod.
            /*Person5 person51 = new(){Name = "John Doe", Age = 25};
            Person5 person52 = new(){Name = "Doe John", Age = 24};
            Person5 person53 = new(){Name = "Doe John", Age = 24};
            var equality = person51.Equals(person52);
            Console.WriteLine(equality);
            equality = person52.Equals(person53);
            Console.WriteLine(equality);*/
            #endregion


            #region IEnumerable
            //IEnumarable is the infterface allowing classes to utilize from foreach.
            //More compherensive info about enumerators is in the next tutorial.
            /*Storage storage1 = new Storage();
            foreach (string storage in storage1)
                Console.WriteLine(storage);*/
            #endregion


            #region IDisposable
            //We are using this one to control and track memory allocation in .Net
            //Used with the destructor (Reminder Definition: Method we define in a class if we wanna trigger the garbage collector manually at a specific point
            //to obliterate the relevant instance of that class which is performed at a random time in default.)
            using MyDataBase myDataBase1 = new MyDataBase(); //using keyword in this context calls Dispose method automatically for the marked instance right after..
            //.. the scopes where the relevant object is defined is finished.
            //There is another use way of using keyword which allows you to determine those scopes specifically too;
            using (MyDataBase myDataBase2 = new MyDataBase()) 
            {
                //After the execution of this area is finished, Dispose Method is called.
            }
            //myDataBase1.Dispose(); //Of course you can do this manually too.
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
    }
    #endregion
    
    
    #region INotifyPropertyChanged
    class Person4 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //PropertyChangedEventHandler is a predeclared delegate we can utilize from..
        //.. creating this event. It will be notifying us about the property changes.
        private string _name; //Should not forget about declaring the variables as private since we will be forming full properties for them.
        private int _age;
        internal string Name {
            get {return _name; }
            set
            {
                    _name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
        internal int Age { 
            get {return _age; }
            set
            {
                    _age = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Age)));
            }
        }
    }
    #endregion
    
    
    #region IEquatable

    class Person5 :IEquatable<Person5>
    {
        internal string Name { get; set; }
        internal int Age { get; set; }

        public bool Equals(Person5 other)
        {
            if(other == null)
                return false;
            return this.Name == other.Name && this.Age == other.Age;
        }
    }

    #endregion


    #region IEnumerable
    class Storage : IEnumerable 
    {
        List<string> list1 = new List<string>() {"Efe", "Ozgur", "Kilic" };
        public IEnumerator GetEnumerator() //A lil info, you can form this method without the implemented interface.
                                           //The interface only makes it obligatory to declare it within the class.
        {
            return list1.GetEnumerator();
        }
    }
    #endregion


    #region IDisposable
    class MyDataBase:IDisposable 
    {
        SqlConnection connection;
        SqlCommand command;

        public void Dispose() 
        {
            connection = null;
            command = null;
        }
    }
    #endregion
}
