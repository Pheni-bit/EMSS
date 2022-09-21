using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    // INPUT DATA
    static int metalTypeIndex, jTypeCount, amountOfCombinations;
    static float feetPerPound, weightOfCoilPounds, coilLengthFeet, coilLengthInches, resultTotalLength, resultWasteLength;
    static int[] joistMinimums, joistMaximums;
    static float[] joistLengths;
    static string[] joistLabels;
    static int[] bestCombination;
    static List<string> allCombinations;
    public static int MetalTypeIndex
    {
        get { return metalTypeIndex; }
        set { metalTypeIndex = value; 
            FeetPerPound = value;}
    }
    public static float FeetPerPound
    {
        get { return feetPerPound; }
        private set { feetPerPound = metalTypeIndexPerPound[(int)value];
            CoilLengthFeet = feetPerPound;
        }
    }
    public static float CoilLengthFeet
    {
        get { return coilLengthFeet; } 
        private set { coilLengthFeet = weightOfCoilPounds / value;
            CoilLengthInches = CoilLengthFeet;
        }
    }
    public static float CoilLengthInches
    {
        get { return coilLengthInches; }
        private set { coilLengthInches = value * 12; }
    }
    public static int JTypeCount
    {
        get { return jTypeCount; }
        set { jTypeCount = value; }
    }
    public static float WeightOfCoilPounds
    {
        get { return weightOfCoilPounds; } 
        set { weightOfCoilPounds = value; }
    }
    public static string[] JoistLabels
    {
        get { return joistLabels; }
        set { joistLabels = value; }
    }
    public static float[] JoistLengths
    {
        get { return joistLengths; }
        set { joistLengths = value; }
    }
    public static int[] JoistMinimums
    {
        get { return joistMinimums; } 
        set { joistMinimums = value; }
    }
    public static int[] JoistMaximums
    {
        get { return joistMaximums; } 
        set { joistMaximums = value; }
    }

    // STATIC DATA 

    //Calculation
    public static void PlugNPlay()
    {
        ResultTotalLength = 0;
        ResultWasteLength = float.MaxValue;
        AllCombinations = Permutations.GetAllCombinations(JoistMinimums, JoistMaximums);
        AmountOfCombinations = AllCombinations.Count;
        //loading is halfway
        foreach (string str in AllCombinations)
        {
            int[] vs = new int[jTypeCount];
            float totalLength = FrontEndWaste + BackEndWaste + MarginOfError + CylinderSevenCutt;
            string[] strings = str.Split(',');
            for (int i = 0; i < JTypeCount; i++)
            {
                int x = int.Parse(strings[i]);
                vs[i] = x;
                totalLength += JoistLengths[i] * (x + CylinderSevenCutt);
            }
            if (totalLength <= CoilLengthInches)
            {
                float f = CoilLengthInches - totalLength;
                if (f < ResultWasteLength)
                {
                    ResultWasteLength = f;
                    ResultTotalLength = totalLength;
                    BestCombination = vs;
                }
            }
        }
    }

    // SETTINGS DATA
    static float cylinderrSevenCutt = 0.375f, marginOfError = 12.0f,
        frontEndWasteInch = 48.0f, backEndWasteInch = 12.0f;
    static string[] metalTypeLabels =
{
        "6\" Galvanized Steel",
        "8\" Galvanized Steel",
        "10\" Galvanized Steel",
        "12\" Galvanized Steel",
        "14\" Galvanized Steel",
        "16\" Galvanized Steel",
        "18\" Galvanized Steel",
    };
    static float[] metalTypeIndexPerPound =
{
        0 , 6.16f, 6.98f, 7.8f, 8.61f, 9.43f, 10.24f, 11.06f
    };


    public static float CylinderSevenCutt
    {
        get { return cylinderrSevenCutt; }  set { cylinderrSevenCutt = value; }
    }

    public static string[] MetalTypeLabels
    {
        get { return metalTypeLabels; } set { metalTypeLabels = value; }
    }
    
    public static float MarginOfError
    {
        get { return marginOfError; }   set { marginOfError = value; }
    }

    public static float[] MetalTypeIndexPerPound
    {
        get { return metalTypeIndexPerPound; }  set { metalTypeIndexPerPound = value; }
    }
    public static float FrontEndWaste
    {
        get { return frontEndWasteInch; }   set { frontEndWasteInch = value; }
    }
    public static float BackEndWaste
    {
        get { return backEndWasteInch; }    set { backEndWasteInch = value; }
    }
    public static int AmountOfCombinations
    {
        get { return amountOfCombinations; }    set { amountOfCombinations = value; }
    }
    public static List<string> AllCombinations
    {
        get { return allCombinations;  } set { allCombinations = value; }
    }
    public static int[] BestCombination
    {
        get { return bestCombination; } set { bestCombination = value; }
    }
    public static float ResultTotalLength
    {
        get { return resultTotalLength; } set { resultTotalLength = value; }
    }
    public static float ResultWasteLength
    {
        get { return resultWasteLength; } set { resultWasteLength = value; }
    }

}
