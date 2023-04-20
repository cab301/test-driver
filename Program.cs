namespace Exercise4_Solution;
class Program
{
    const int ARRAY_SIZE = 10;
    const int RANDOM_MAX = 1000;

    static void Main(string[] args)
    {
        TestDriver.AddTestClass(typeof(Program));
        TestDriver.RunAllTests();
        // int seed = (int)DateTime.Now.Ticks;
        // Random number = new Random(seed);
        // Random rnd = new Random(seed);
        // int[] nums = new int[ARRAY_SIZE];
        // for (int i = 0; i < ARRAY_SIZE; i++)
        //     // randomly generate an integer beteen 0 and RAMDOM_MAX
        //     nums[i] = rnd.Next(RANDOM_MAX);

        // Console.Clear();
        // Console.WriteLine();
        // Console.WriteLine("before heap sorting:");
        // for (int i = 0; i < ARRAY_SIZE; i++)
        // {
        //     Console.WriteLine(nums[i]);
        // }

        // HeapSort(nums);

        // Console.WriteLine();
        // Console.WriteLine("after heap sorting:");
        // for (int i = 0; i < ARRAY_SIZE; i++)
        // {
        //     Console.WriteLine(nums[i]);
        // }

        // Console.ReadLine();
    }

    [Test("Test HeapSort with empty array")]
    public TestResult TestHeapSortEmptyArray()
    {
        int[] nums = new int[]{};
        HeapSort(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[]", "[]", actualString, nums.Length == 0);
    }

    [Test("Test HeapSort with one element")]
    public TestResult TestHeapSortOneElement()
    {
        int[] nums = new int[1];
        nums[0] = 1;
        HeapSort(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1]", "[1]", actualString, nums.Length == 1 && nums[0] == 1);
    }

    [Test("Test HeapSort with five elements, sorted in random order")]
    public TestResult TestHeapSortFiveElements()
    {
        int[] nums = new int[5];
        nums[0] = 1;
        nums[1] = 3;
        nums[2] = 2;
        nums[3] = 5;
        nums[4] = 4;
        HeapSort(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1,3,2,5,4]", "[1,2,3,4,5]", actualString, nums.Length == 5 && nums[0] == 1 && nums[1] == 2 && nums[2] == 3 && nums[3] == 4 && nums[4] == 5);
    }

    [Test("Test HeapSort with five elements, sorted in ascending order")]
    public TestResult TestHeapSortFiveElementsAscending()
    {
        int[] nums = new int[5];
        nums[0] = 1;
        nums[1] = 2;
        nums[2] = 3;
        nums[3] = 4;
        nums[4] = 5;
        HeapSort(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1,2,3,4,5]", "[1,2,3,4,5]", actualString, nums.Length == 5 && nums[0] == 1 && nums[1] == 2 && nums[2] == 3 && nums[3] == 4 && nums[4] == 5);
    }

    [Test("Test HeapSort with five elements, sorted in descending order")]
    public TestResult TestHeapSortFiveElementsDescending()
    {
        int[] nums = new int[5];
        nums[0] = 5;
        nums[1] = 4;
        nums[2] = 3;
        nums[3] = 2;
        nums[4] = 1;
        HeapSort(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[5,4,3,2,1]", "[1,2,3,4,5]", actualString, nums.Length == 5 && nums[0] == 1 && nums[1] == 2 && nums[2] == 3 && nums[3] == 4 && nums[4] == 5);
    }

    [Test("Test HeapSort with random elements")]
    public TestResult TestHeapSortRandomElements()
    {
        int seed = (int)DateTime.Now.Ticks;
        Random rnd = new Random(seed);
        int[] nums = new int[ARRAY_SIZE];
        for (int i = 0; i < ARRAY_SIZE; i++)
            // randomly generate an integer beteen 0 and RAMDOM_MAX
            nums[i] = rnd.Next(RANDOM_MAX);

        string input = "[" + string.Join(",", nums) + "]";
        HeapSort(nums);
        string actual = "[" + string.Join(",", nums) + "]";
        bool sorted = true;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                sorted = false;
                break;
            }
        }

        return new TestResult(input, "Array should be sorted in non-descending order", actual, sorted);
    }

    [Test("Test HeapBottomUp with empty array")]
    public TestResult TestHeapBottomUpEmptyArray()
    {
        int[] nums = new int[]{};
        HeapBottomUp(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[]", "[]", actualString, nums.Length == 0);
    }

    [Test("Test HeapBottomUp with one element")]
    public TestResult TestHeapBottomUpOneElement()
    {
        int[] nums = new int[1];
        nums[0] = 1;
        HeapBottomUp(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1]", "[1]", actualString, nums.Length == 1 && nums[0] == 1);
    }

    [Test("Test HeapBottomUp with five elements, sorted in random order")]
    public TestResult TestHeapBottomUpFiveElements()
    {
        int[] nums = new int[5];
        nums[0] = 1;
        nums[1] = 3;
        nums[2] = 2;
        nums[3] = 5;
        nums[4] = 4;
        HeapBottomUp(nums);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1,3,2,5,4]", "[5,4,2,3,1]", actualString, nums.Length == 5 && nums[0] == 5 && nums[1] == 4 && nums[2] == 2 && nums[3] == 3 && nums[4] == 1);
    }

    [Test("Test MaxKeyDelete with heap of size 1")]
    public TestResult TestMaxKeyDeleteSizeOne()
    {
        int[] nums = new int[1];
        nums[0] = 1;
        MaxKeyDelete(nums, 1);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[1]", "[1]", actualString, nums.Length == 1 && nums[0] == 1);
    }

    [Test("Test MaxKeyDelete with heap of size 2")]
    public TestResult TestMaxKeyDeleteSizeTwo()
    {
        int[] nums = new int[2];
        nums[0] = 2;
        nums[1] = 1;
        MaxKeyDelete(nums, 2);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[2,1]", "[1,2]", actualString, nums.Length == 2 && nums[0] == 1 && nums[1] == 2);
    }

    [Test("Test MaxKeyDelete with heap of size 5")]
    public TestResult TestMaxKeyDeleteSizeFive()
    {
        int[] nums = new int[5];
        nums[0] = 5;
        nums[1] = 4;
        nums[2] = 2;
        nums[3] = 3;
        nums[4] = 1;
        MaxKeyDelete(nums, 5);
        string actualString = "[" + string.Join(",", nums) + "]";
        return new TestResult("[5,4,2,3,1]", "[4,3,2,1,5]", actualString, nums.Length == 5 && nums[0] == 4 && nums[1] == 3 && nums[2] == 2 && nums[3] == 1 && nums[4] == 5);
    }

    // convert a complete binary tree into a heap
    static void HeapBottomUp(int[] data)
    {
        int n = data.Length;
        for (int i = (n - 1) / 2; i >= 0; i--)
        {
            int k = i;
            int v = data[i];
            bool heap = false;
            while ((!heap) && ((2 * k + 1) <= (n - 1)))
            {
                int j = 2 * k + 1;  //the left child of k
                if (j < (n - 1))   //k has two children
                    if (data[j] < data[j + 1])
                        j = j + 1;  //j is the larger child of k
                if (v >= data[j])
                    heap = true;
                else
                {
                    data[k] = data[j];
                    k = j;
                }
            }
            data[k] = v;
        }
    }

    // sort the elements in an array 
    static void HeapSort(int[] data)
    {
        //Use the HeapBottomUp procedure to convert the array, data, into a heap
        HeapBottomUp(data);


        //repeatly remove the maximum key from the heap and then rebuild the heap
        for (int i = 0; i <= data.Length - 2; i++)
        {
            MaxKeyDelete(data, data.Length - i);
        }
    }

    //delete the maximum key and rebuild the heap
    static void MaxKeyDelete(int[] data, int size)
    {
        //1. Exchange the root’s key with the last key K of the heap;
        int temp = data[0];
        data[0] = data[size - 1];
        data[size - 1] = temp;

        //2. Decrease the heap’s size by 1;
        int n = size - 1;

        //3. “Heapify” the complete binary tree.
        bool heap = false;
        int k = 0;
        int v = data[0];
        while ((!heap) && ((2 * k + 1) <= (n - 1)))
        {
            int j = 2 * k + 1; //the left child of k
            if (j < (n - 1))   //k has two children
                if (data[j] < data[j + 1])
                    j = j + 1;  //j is the larger child of k
            if (v >= data[j])
                heap = true;
            else
            {
                data[k] = data[j];
                k = j;
            }
        }
        data[k] = v;
    }

}