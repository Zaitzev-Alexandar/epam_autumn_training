using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLib.Ingredients
{
    /// <summary>
    /// Class describing properties of a flour.
    /// </summary>
    public class Flour : Ingredient
    {
        /// <summary>
        /// Inits a flour.
        /// </summary>
        /// <param name="calorie">Calories of ingredient</param>
        /// <param name="cost">Cost of ingredient</param>
        /// <param name="value">Value of ingredient</param>
        public Flour(double calorie, double cost, double value)
        {
            Calorie = calorie;
            Cost = cost;
            Value = value;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " + base.ToString();
        }
    }
}
