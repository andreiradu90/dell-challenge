using System;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            (new List<Species>
            {
                new Human(),
                new Bird(),
                new Fish()
            }).ForEach(c => c.GetSpecies());

            (new List<ITerrestrialSpecies> //similar for other species
            {
                new Human() // other ITerrestrialSpecies species could be added which have a different implementation of Eat(), Drink(), Swim()
            }).ForEach(c =>
            {
                c.Eat();
                c.Drink();
                c.Swim();
            });
        }
    }

    //It's best that interfaces are segregated
    public interface ITerrestrialSpecies
    {
        void Eat();
        void Drink();
        void Swim();
    }
    public interface IAquaticSpecies
    {
        void Eat();
        void Swim();
    }
    public interface IAerialSpecies
    {
        void Eat();
        void Drink();
        void Fly();
    }
    public abstract class Species
    {
        // We can keep this as a default implementation
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species, ITerrestrialSpecies
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am a human!");
        }
        public void Drink()
        {
            Console.WriteLine($"A human can drink!");
        }

        public void Eat()
        {
            Console.WriteLine($"A human can eat!");
        }

        public void Swim()
        {
            Console.WriteLine($"A human can usually swim!");
        }
    }

    public class Bird : Species, IAerialSpecies
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am a bird!");
        }

        public void Drink()
        {
            Console.WriteLine($"A bird can drink!");
        }

        public void Eat()
        {
            Console.WriteLine($"A bird can eat!");
        }

        public void Fly()
        {
            Console.WriteLine($"A bird can fly!");
        }
    }

    public class Fish : Species, IAquaticSpecies
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am a fish!");
        }

        public void Eat()
        {
            Console.WriteLine($"A fish can eat!");
        }

        public void Swim()
        {
            Console.WriteLine($"A fish can swim!");
        }
    }
}

