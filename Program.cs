using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Contains some samples / tests / metrics measuring methods for Heap implementations
    /// Uses a sample set of 2 million integers for heap formation in most cases for benchmarking
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BeforeMinHeapMaxHeap();

            MinHeapConstruct();

            MaxHeapConstruct();

            AfterMinHeapMaxHeapAdding_WorstCase();

            AfterMinHeapMaxHeapAdding_AverageCase();

            TopNMinHeapConstruct();

            BottomNMaxHeapConstruct();

            AfterBottomNMaxHeapAdding_WorstCase();

            AfterBottomNMaxHeapAdding_AverageCase();

            BottomNEntityMinHeapConstruct();

            TopNEntityMinHeapConstruct();
        }

        private static void BeforeMinHeapMaxHeap()
        {
            double[] data = new double[2000000];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int val = data.Length; val > 0; val--)
            {
                data[val - 1] = val;
            }

            stopWatch.Stop();
            Console.WriteLine("Time: {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void AfterMinHeapMaxHeapAdding_WorstCase()
        {
            double[] data = new double[2000000];


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            MinHeap<double> heap = new MinHeap<double>(data.Length);

            for (int val = data.Length; val > 0; val--)
            {
                heap.Add(val);
            }

            for (int i = 0; i < 50; i++)
            {
                //// 50 bottom n
                //Console.WriteLine(heap.Pop());
                heap.Pop();
            }

            stopWatch.Stop();
            Console.WriteLine("Time: {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void AfterMinHeapMaxHeapAdding_AverageCase()
        {
            Random rand = new Random();
            int[] int_data = Enumerable.Range(0, 2000001).OrderBy(c => rand.Next()).ToArray();
            double[] data = new double[int_data.Count()];
            for (int ind = 0; ind < data.Count(); ind++)
            {
                data[ind] = int_data[ind];
                //data[ind] = rand.Next(100000000);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            MinHeap<double> heap = new MinHeap<double>(data.Length);

            for (int val = 0; val < data.Length; val++)
            {
                heap.Add(data[val]);
            }

            for (int i = 0; i < 50; i++)
            {
                //// 50 bottom n
                //Console.WriteLine(heap.Pop());
                heap.Pop();
            }

            stopWatch.Stop();
            Console.WriteLine("Time: {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void AfterBottomNMaxHeapAdding_AverageCase()
        {
            Random rand = new Random();
            int[] int_data = Enumerable.Range(0, 2000001).OrderBy(c => rand.Next()).ToArray();
            double[] data = new double[int_data.Count()];
            for (int ind = 0; ind < data.Count(); ind++)
            {
                data[ind] = int_data[ind];
                //data[ind] = rand.Next(100000000);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            BottomNMaxHeap<double> heap = new BottomNMaxHeap<double>(50);

            for (int val = 0; val < data.Length; val++)
            {
                heap.Add(data[val]);
            }

            for (int i = 0; i < 50; i++)
            {
                //// 50 bottom n
                //Console.WriteLine(heap.Pop());
                heap.Pop();
            }

            stopWatch.Stop();
            Console.WriteLine("Time: {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void AfterBottomNMaxHeapAdding_WorstCase()
        {
            double[] data = new double[2000000];


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            BottomNMaxHeap<double> heap = new BottomNMaxHeap<double>(50);

            for (int val = data.Length; val > 0; val--)
            {
                heap.Add(val);
            }

            for (int i = 0; i < 50; i++)
            {
                //// 50 bottom n
                Console.WriteLine(heap.Pop());
                //heap.Pop();
            }

            stopWatch.Stop();
            Console.WriteLine("Time: {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void MinHeapConstruct()
        {
            double[] data_arr = new[] { 8.0, 7, 2, 1, 18, 32, 16, 21, 4, 0, 70 };
            MinHeap<double> heap = new MinHeap<double>(data_arr.Length);

            foreach (var item in data_arr)
            {
                heap.Add(item);
                Console.WriteLine(heap);
            }
            //Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void MaxHeapConstruct()
        {
            double[] data_arr = new[] { 8.0, 7, 2, 1, 18, 32, 16, 21, 4, 0, 70 };
            MaxHeap<double> heap = new MaxHeap<double>(data_arr.Length);

            foreach (var item in data_arr)
            {
                heap.Add(item);
            }
            Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private static void TopNEntityMinHeapConstruct()
        {
            PriceData[] data_arr = GetPriceData_Small();
            TopNEntityMinHeap<PriceData, double> heap = new TopNEntityMinHeap<PriceData, double>(data_arr.Length, (pd) => pd.Open);

            foreach (var item in data_arr)
            {
                heap.Add(item);
            }
            //Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.ReadLine();
        }

        private static void BottomNEntityMinHeapConstruct()
        {
            PriceData[] data_arr = GetPriceData_Small();
            BottomNEntityMaxHeap<PriceData, double> heap = new BottomNEntityMaxHeap<PriceData, double>(data_arr.Length, (pd) => pd.Open);

            foreach (var item in data_arr)
            {
                heap.Add(item);
            }
            //Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.ReadLine();
        }

        private static PriceData[] GetPriceData_Small()
        {
            return new PriceData[]
            {
                new PriceData { SecurityId = 8, SecurityName = "Sec 8", Open = 8.0},
                new PriceData { SecurityId = 7, SecurityName = "Sec 7", Open = 7},
                new PriceData { SecurityId = 2, SecurityName = "Sec 2", Open = 2},
                new PriceData { SecurityId = 1, SecurityName = "Sec 1", Open = 1},
                new PriceData { SecurityId = 18, SecurityName = "Sec 18", Open = 18},
                new PriceData { SecurityId = 32, SecurityName = "Sec 32", Open = 32},
                new PriceData { SecurityId = 16, SecurityName = "Sec 16", Open = 16},
                new PriceData { SecurityId = 21, SecurityName = "Sec 21", Open = 21},
                new PriceData { SecurityId = 4, SecurityName = "Sec 4", Open = 4},
                new PriceData { SecurityId = 0, SecurityName = "Sec 0", Open = 0},
                new PriceData { SecurityId = 70, SecurityName = "Sec 70", Open = 70},
            };
        }

        private static void BottomNMaxHeapConstruct()
        {
            double[] data_arr = new[] { 8.0, 7, 2, 1, 18, 32, 16, 21, 4, 0, 70 };
            BottomNMaxHeap<double> heap = new BottomNMaxHeap<double>(data_arr.Length);

            foreach (var item in data_arr)
            {
                heap.Add(item);
            }
            //Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.ReadLine();
        }

        private static void TopNMinHeapConstruct()
        {
            double[] data_arr = new[] { 8.0, 7, 2, 1, 18, 32, 16, 21, 4, 0, 70 };
            TopNMinHeap<double> heap = new TopNMinHeap<double>(data_arr.Length);

            foreach (var item in data_arr)
            {
                heap.Add(item);
            }
            //Console.WriteLine(heap);

            while (heap.CanPop())
            {
                Console.WriteLine(heap.Pop());
            }

            Console.ReadLine();
        }

    }
}
