using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
			if (age < MinAge || age > MaxAge) throw new ArgumentException("Age should be between 0 and 15.");

            this.name = name;
            this.age = age;
        }

		public string Name => name;
		public int Age => age;

        public double ProductPerDay => this.CalculateProductPerDay();

        private double CalculateProductPerDay()
        {
            if (this.Age <= 3) return 1.50;
            if (this.Age <= 7) return 2.00;
            if (this.Age <= 11) return 1.00;

            return 0.75;
        }
    }
}
