using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class FoodInventory : IList<Food>
    {
        private IList<Food> _food;

        public int TotalCalories => _food.Sum(x => x.Calories);

        public FoodInventory()
        {
            _food = new List<Food>();
        }

        public void Load(IEnumerable<Food> foods)
        {
            foreach(Food food in foods)
            {
                this.Add(food);
            }
        }

        public void Load(IEnumerable<int> calories)
        {
            foreach (int foodCaloriesValue in calories)
            {
                this.Add(new Food()
                {
                    Calories = foodCaloriesValue
                });
            }
        }

        #region IList<Food> Implementation
        public Food this[int index] { get => _food[index]; set => _food[index] = value; }

        public int Count => _food.Count;

        public bool IsReadOnly => _food.IsReadOnly;

        public void Add(Food item)
        {
            _food.Add(item);
        }

        public void Clear()
        {
            _food.Clear();
        }

        public bool Contains(Food item)
        {
            return _food.Contains(item);
        }

        public void CopyTo(Food[] array, int arrayIndex)
        {
            _food.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Food> GetEnumerator()
        {
            return _food.GetEnumerator();
        }

        public int IndexOf(Food item)
        {
            return _food.IndexOf(item);
        }

        public void Insert(int index, Food item)
        {
            _food.Insert(index, item);
        }

        public bool Remove(Food item)
        {
            return _food.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _food.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_food).GetEnumerator();
        }
        #endregion
    }
}
