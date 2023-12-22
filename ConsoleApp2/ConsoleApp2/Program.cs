using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Reflection;

class Program
{
    static int[] FindSubarrayWithSum(int[] arr, int targetSum)
    {
        //int n = arr.Length;

        //for (int start = 0; start < n; start++)
        //{
        //    int currentSum = 0;

        //    for (int end = start; end < n; end++)
        //    {
        //        currentSum += arr[end];

        //        if (currentSum == targetSum)
        //        {
        //            Console.Write("Subarray found from index " + start + " to " + end + ": ");
        //            for (int i = start; i <= end; i++)
        //            {
        //                Console.Write(arr[i] + " ");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        int n = arr.Length;
        int start = 0;
        int currentSum = 0;

        for (int end = 0; end < n; end++)
        {
            currentSum += arr[end];

            while (currentSum > targetSum)
            {
                currentSum -= arr[start];
                start++;
            }

            if (currentSum == targetSum)
            {
                int subarraySize = end - start + 1;
                int[] subarray = new int[subarraySize];
                Array.Copy(arr, start, subarray, 0, subarraySize);
                return subarray;
            }
        }

        return null;
    }

    static void Main(string[] args)
    {
        //int[] arr = { 2, 1, 1, 3, 4, 1, 1, 1, 1, 2, 1, 5, 1, 0, 0, 0, 0, 0, 0, 0 };
        //int targetSum = 20;

        ////Console.WriteLine("Subarrays with sum " + targetSum + ":");
        ////FindSubarraysWithSum(arr, targetSum);

        //int[] result = FindSubarrayWithSum(arr, targetSum);

        //if (result != null)
        //{
        //    Console.WriteLine("Dãy con có tổng bằng " + targetSum + " là: " + string.Join(", ", result));
        //}
        //else
        //{
        //    Console.WriteLine("Không tìm thấy dãy con có tổng bằng " + targetSum);

        //    //TestWithChromeDriver();
        //}

        int[][] arrayOfArrays = new int[][]
        {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 6, 7, 8, 9, 10 },
            new int[] { 11, 12, 13, 14, 15 }
        };

        int[] subArray = { 8, 9, 10 };

        if (ContainsSubarray(arrayOfArrays, subArray))
        {
            Console.WriteLine("Subarray is present in the array of arrays.");
        }
        else
        {
            Console.WriteLine("Subarray is not present in the array of arrays.");
        }
    }

    static bool CompareArrays(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            return false;
        }

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                return false;
            }
        }

        return true;
    }

    static bool IsSubarrayPresent(int[] mainArray, int[] subArray)
    {
        int n = mainArray.Length;
        int m = subArray.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j;
            for (j = 0; j < m; j++)
            {
                if (mainArray[i + j] != subArray[j])
                {
                    break;
                }
            }
            if (j == m)
            {
                return true;
            }
        }

        return false;
    }

    static bool ContainsSubarray(int[][] arrayOfArrays, int[] subArray)
    {
        foreach (var array in arrayOfArrays)
        {
            if (IsSubarrayPresent(array, subArray))
            {
                return true;
            }
        }
        return false;
    }

    public static void TestWithChromeDriver()
    {
        using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
        {
            driver.Navigate().GoToUrl(@"https://code-maze.com/selenium-aspnet-core-ui-tests/");
            //var link = driver.FindElement(By.PartialLinkText("TFS Test API"));
            //var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
            //((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
            //var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            //var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("TFS Test API")));
            //clickableElement.Click();
        }
    }
}
