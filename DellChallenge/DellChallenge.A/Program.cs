using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            // Constructor chaining identifies the base parameterless constructor, hence A.() then B.()
            // A.Age is then printed by setting the Age Parameter in class B constructor
            // The order is:
            // A.A()
            // B.B()
            // A.Age

            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()//the same as: "public B() : base()", where base() is called first
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
