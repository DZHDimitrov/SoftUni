using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {

        public Cocktail(string name,int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;

            this.Ingredients = new List<Ingredient>();
        }

        public IList<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (this.Capacity > this.Ingredients.Count && this.CurrentAlcoholLevel+ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return this.Ingredients.Remove(this.Ingredients.FirstOrDefault(x => x.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return this.Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            sb.AppendLine($"{string.Join(Environment.NewLine, this.Ingredients)}");

            return sb.ToString().TrimEnd();
        }
    }
}
