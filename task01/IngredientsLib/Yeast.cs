using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLib
{
    /// <summary>
    /// Class describing properties of a yeast.
    /// </summary>
    public class Yeast : Ingredient
    {
        /// <summary>
        /// Inits a yeast.
        /// </summary>
        /// <param name="calorie">Calories of yeast</param>
        /// <param name="cost">Cost of yeast</param>
        /// <param name="value">Value of yeast</param>
        public Yeast(double calorie, double cost, double value)
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
