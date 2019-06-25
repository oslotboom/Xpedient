using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DataProvider : IDataProvider
    {

        public object GetList(ListParameters parameters)
        {
            Random random = new Random();

            List<Decimal> items = new List<Decimal>();

            for (int j = 0; j < parameters.Count; j++)
            {
                decimal randomNumber = Convert.ToDecimal(random.NextDouble());
                decimal scaledNumber = parameters.Minimum + randomNumber * (parameters.Maximum - parameters.Minimum);

                items.Add(Convert.ToDecimal(Math.Round(scaledNumber, 2)));
            }

            var returnObject = new
            {
                original = items,
                ordered = GetOrderedList(items)
            };

            return returnObject;

        }

        public List<Decimal> GetOrderedList(List<Decimal> inList)
        {

            if (inList.Count == 1)
                //return Newtonsoft.Json.JsonConvert.SerializeObject(inList);
                return inList;

            //Use an insertion sort to order the list
            List<Decimal> sortedList = new List<Decimal>();

            sortedList.Add(inList[0]);
            for (int k = 1; k < inList.Count; k++)
            {
                int n = 0;
                while (n < sortedList.Count && inList[k] < sortedList[n])
                {
                    n++;
                }
                sortedList.Insert(n, inList[k]);

            }

            //Select in the desired order
            List<Decimal> returnList = new List<Decimal>();

            returnList.Add(sortedList[0]);

            for (int i = 1; i < sortedList.Count; i++)
            {
                if (i % 2 == 0)
                    returnList.Add(sortedList[i]);
                else
                    returnList.Insert(0, sortedList[i]);

            }

            return returnList;

        }


    }
}
