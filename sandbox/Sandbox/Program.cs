using System;
using System.Diagnostics.Metrics;

public class main {
    static void main() {
        List<int> nums = new List<int>() { 2, 7, 11, 15 };
        int target = 9;
        int postion_1;
        int postion_2 = 0;

        int counter_1 = 0;
        int counter_2 = 0;

        foreach (int i in nums){
            postion_1 = counter_1;
            counter_2 = 0;

            foreach (int o in nums){
                postion_2 = counter_2;
                if ((i+o) == target){
                    break;
                }
                counter_2++;
            }
            if ((i+postion_2) == target){
                break;
            }
            counter_1++;
        }

        Console.WriteLine($"[{counter_1},{counter_2}]");
    }
}