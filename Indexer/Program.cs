using System;
namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new FlexibleArray<int>();

            arr[3] = 6;
            arr[7] = 3;
            arr[1] = 1;
            
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
