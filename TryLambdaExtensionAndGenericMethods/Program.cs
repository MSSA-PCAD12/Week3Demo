using System.Diagnostics.Contracts; 

namespace TryLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var strarr = new string[] { "Apple","Banana","Cherry","Mango","Pineapple","Strawberry"};
            var projectStringLength = strarr.Select(s => s.Length);
            var projectInitialChar = strarr.Select(s => s[0]);
            var projectLastChar = strarr.Select(s => s[^1]);
            var projectFirstTwoChar = strarr.Select(s => s[..2]);


            // LINQ - Extension Methods (select,where,zip,chunk.....)
            // Generic Methods, Lambda - use shorthand (s)=>y  given s return y
            // using Lambda to supply our logic to Linq extension method
            //the final form of select
            // use new { [prop1]=[projection1] ,[prop2]=[projection2],...... } to define an anonymous class

            var whatIsIt = strarr.Select(s=> new 
            {
                StringLength= s.Length,
                InitialChar= s[0],
                LastChar= s[^1],
                FirstTwoChar= s[..2]
            });
            foreach (var item in whatIsIt)
            {
                Console.WriteLine($"{item.FirstTwoChar}-{item.LastChar}-{item.StringLength}-{item.InitialChar}" );
            }

            projectStringLength.Print("Project string length");
            projectInitialChar.Print("Project Initial letter");
            projectLastChar.Print("Project Last letter");
            projectFirstTwoChar.Print("Project First 2 letter");
            //var result = arr.Where(i => i>5 );
            var result = arr.Where(i => i % 2 == 1).Sum();

            Console.WriteLine(result);

            var something = arr.Chunk(5);

            foreach (var i in something) {
                foreach (var j in i)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }

            IEnumerable<(int,string)> zipped = arr.Zip(strarr);
            foreach (var i in zipped) {
                Console.WriteLine(i.Item1 + "--" +i.Item2);
            }

            //arr.Aggregate
            if (arr.All(i => i > 0)) { Console.WriteLine("All numbers are positive."); }

            var groups = arr.GroupBy(i => $"Group {(i % 3)}");

            foreach (var aGroup in groups)
            {
                Console.Write( $"in group {aGroup.Key}:" );
                foreach (int i in aGroup) {
                    Console.Write(i);
                }
                Console.WriteLine("");
            }

            var sumPerGroup = arr.GroupBy(i => $"Group {(i % 3)}").Select(
              (group, idx) => $"{group.Key} has sum of {group.Sum()}"
              );

            sumPerGroup.Print("Group Sum");
            //filtering - where
            //aggregate - sum, min,max,avg,stdev, - aggregate
            //grouping - divide into groups - groupby
            //projection - pick subset of attribute - select


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
        }

        //TupleDemo
        static (int, string) demo() {
            return (3, "hello");
        }
    }

    static class Extensions {
        // non generic version, only works with IEnumerable<char>
        //public static void Print(this IEnumerable<char> arr,string title) {
        //    Console.WriteLine($"------------{title}------------");
        //    foreach (var item in arr)
        //    {
        //        Console.WriteLine(item);
        //    }     
        //}

        // generic version
        public static void Print<T>(this IEnumerable<T> arr, string title)
        {
            Console.WriteLine($"------------{title}------------");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
