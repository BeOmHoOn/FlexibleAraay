using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new FlexibleArray<string>();

            arr[3] = "바보";
            arr[7] = "멍튱이";
            arr[1] = "앙대";

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
