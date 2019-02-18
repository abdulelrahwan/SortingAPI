using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;


public class Data
{
    public string SortingMethod { get; set; }
    public string[] ValuesArray { get; set; }
    public string DataType { get; set; }
    public Data(string sortingMethod, string[] valuesArray, string dataType)
    {
        SortingMethod = sortingMethod;
        ValuesArray = valuesArray;
        DataType = dataType;
    }
    // Other properties, methods, events...
}
namespace SortingAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods:"*")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        public static int[] Exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
            return data;
        }

        public Array IntArrayBubbleSort(int[] data)
        {
            int i, j;
            int N = data.Length;
            var Returnlist = new List<int[]>();

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        data = Exchange(data, i, i + 1);
                        int[] tempData = new int[N];

                        for (int k = 0; k < N; k++)
                        {
                            Console.WriteLine(data[k]);
                            tempData[k] = data[k];
                            
                        }

                        Returnlist = Returnlist.Append(tempData).ToList();

                        //Console.WriteLine(data);
                        //Returnlist.Add(data);
                    }
                }
            }
            var ReturnArray = Returnlist.ToArray();
            return ReturnArray;
        }

        public Array IntArrayInsertionSort(int[] data)
        {
            int i, j;
            int N = data.Length;
            var Returnlist = new List<int[]>();

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && data[i] < data[i - 1]; i--)
                {
                    data = Exchange(data, i, i - 1);
                    int[] tempData = new int[N];
                    for (int k = 0; k < N; k++)
                    {
                        Console.WriteLine(data[k]);
                        tempData[k] = data[k];

                    }
                    Returnlist = Returnlist.Append(tempData).ToList();


                }

            }
            var ReturnArray = Returnlist.ToArray();
            return ReturnArray;
        }

        public static int IntArrayMin(int[] data, int start)
        {
            int minPos = start;
            for (int pos = start + 1; pos < data.Length; pos++)
                if (data[pos] < data[minPos])
                    minPos = pos;
            return minPos;
        }

        public Array IntArraySelectionSort(int[] data)
        {
            int i;
            int N = data.Length;
            var Returnlist = new List<int[]>();


            for (i = 0; i < N - 1; i++)
            {
                int k = IntArrayMin(data, i);
                if (i != k)
                    data = Exchange(data, i, k);
                int[] tempData = new int[N];
                for (int l = 0; l < N; l++)
                {
                    Console.WriteLine(data[l]);
                    tempData[l] = data[l];

                }
                Returnlist = Returnlist.Append(tempData).ToList();

            }
            var ReturnArray = Returnlist.ToArray();
            return ReturnArray;
        }



        // POST api/values
        //[Route("api/[controller]/SortIntegers")]
        [HttpPost]
        public Array Post([FromBody] Data data)
        {
            int ArrayLength = data.ValuesArray.Length;
            if (data.DataType == "Integer")
            {
                int[] numbersArray = new int[ArrayLength];

                for (int i = 0; i < data.ValuesArray.Length; i++)
                {
                    numbersArray[i] = (int.Parse(data.ValuesArray[i]));
                }                if (data.SortingMethod == "Bubble")
                {

                    return IntArrayBubbleSort(numbersArray);
                }
                else if (data.SortingMethod == "Insertion")
                {
                    return IntArrayInsertionSort(numbersArray);
                } else if(data.SortingMethod == "Selection")
                {
                    return IntArraySelectionSort(numbersArray);
                }
                else
                {
                    return null;
                }
            }
            else {
                return null;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
