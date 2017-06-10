using System;

namespace Basic13
{
    class Program
    {
        //print a range of numbers --use 'all', 'odd', 'even', or 'sum' to select output
        static void printNum(int start, int end, string how){
            if(how == "all"){
                for (int i = start; i <= end; i++){
                System.Console.WriteLine(i);
                }
            }
            if (how == "odd"){
                for (int i = start; i <= end; i++){
                    if(i % 2 != 0){
                         System.Console.WriteLine(i);
                    }
                }
            }
            if (how == "even"){
                for (int i = start; i <= end; i++){
                    if(i % 2 == 0){
                         System.Console.WriteLine(i);
                    }
                }
            }
            int sum = 0;
            if (how == "sum"){
                for (int i = start; i <= end; i++){
                    sum += i;
                    System.Console.WriteLine("New number: " + i + "   Sum: " + sum);
                }
            }
        }
        // manipulate array.  Use 'all', 'max', or 'avg' to select output
        static void ittArray(int[] Array, string type){
            if (type == "all"){
                foreach (int idx in Array){
                System.Console.WriteLine(idx);
                }
            }
            int max = 0;
            if (type == "max"){
                foreach (int idx in Array){
                    if(idx > max){
                        max = idx;
                    }
                }
            System.Console.WriteLine(max);
            }
            if (type == "avg"){
                int sum = 0;
                foreach (int idx in Array){
                    sum += idx;
                }
                int avg = sum/Array.Length;
                System.Console.WriteLine(avg);
            }
        }

        static void oddArray(){
            int[] arrY = new int[128];
            int count = 0;
            for (int idx = 1; idx <= 255; idx++){
                if(idx % 2 != 0){
                    arrY[count] = idx;
                    count++;
                }
            }
            foreach (int idx in arrY){
                System.Console.WriteLine(idx);
            }
        }

        static void numOver(int[] arr1, int num){
            int count = 0;
            foreach (int idx in arr1){
                if(idx > num){
                    count++;
                }
            }
            System.Console.WriteLine(count);
        }

        static void squareArr(int[] arr2){
            for (int idx = 0; idx < arr2.Length; idx++){
                arr2[idx] *= arr2[idx];
            }
            foreach (int num in arr2){
                System.Console.WriteLine(num);
            }
        }

        static void elimNeg(int[] arr){
            for (int num = 0; num < arr.Length; num++){
                if ( arr[num] < 0){
                    arr[num] = 0;
                }
            }
            foreach (int item in arr){
                System.Console.WriteLine(item);
            }
        }
        
        static void minMaxAvg(int[] arr){
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            double avg = 0;
            for (int num = 0; num < arr.Length; num++){
                sum += arr[num];
                if (arr[num] > max){
                    max = arr[num];
                }
                if (arr[num] < min){
                    min = arr[num];
                }
            }
            avg = sum/arr.Length;
            System.Console.WriteLine(min);
            System.Console.WriteLine(max);
            System.Console.WriteLine(avg);
        }

        static void shiftArray(int[] arr){
            int point = 0;
            for (int num = 0; num < arr.Length-1; num++){
                point++;
                arr[num] = arr[point];
            }
            arr[arr.Length-1] = 0;
            foreach (int item in arr){
                System.Console.WriteLine(item);
            }
        }

        static void numToString(object[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if ((int)arr[idx] < 0){
                    arr[idx] = "dojo";
                }
            }
            foreach (object item in arr){
                System.Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            printNum(1, 255, "sum");
            int[] arr = {1,22,3,-2,25};
            object[] array = {3,-4,12,19,-7};
            ittArray(arr, "max");
            oddArray();
            int[] arr1 = {3,57,23,1,44};
            numOver(arr1, 28);
            int[] arr2 = {2,4,6,8};
            squareArr(arr2);
            elimNeg(arr);
            minMaxAvg(arr);
            shiftArray(arr);
            numToString(array);
        }
    }
}
