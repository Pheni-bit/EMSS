using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public static class Permutations
{

   
    public static List<string> GetAllCombinations(int[] minArr, int[] maxArr)
    {
        List<string> stringCombinations = new List<string>();
        var current = minArr.ToArray();
        while (true)
        {
            stringCombinations.Add(string.Join(",", current));
            int pos = 0;
            while (pos < maxArr.Length)
            {
                current[pos]++;
                if (current[pos] <= maxArr[pos])
                    break;
                current[pos] = minArr[pos];
                pos++;
            }
            if (pos == maxArr.Length)
                break;    
        }
        return stringCombinations;
    }
}
