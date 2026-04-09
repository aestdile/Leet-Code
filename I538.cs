using System;
using System.Collections.Generic;

public class Solution
{
    private int Modulus = 1000000007;

    private long CalculatePower(long BaseValue, long Exponent)
    {
        long Result = 1;
        BaseValue %= Modulus;

        while (Exponent > 0)
        {
            if ((Exponent & 1) == 1)
                Result = (Result * BaseValue) % Modulus;

            BaseValue = (BaseValue * BaseValue) % Modulus;
            Exponent >>= 1;
        }

        return Result;
    }

    private long CalculateModularInverse(long Number)
    {
        return CalculatePower(Number, Modulus - 2);
    }

    public int XorAfterQueries(int[] Nums, int[][] Queries)
    {
        int ArrayLength = Nums.Length;
        int Threshold = (int)Math.Sqrt(ArrayLength);
        
        var LightQueries = new Dictionary<int, List<int[]>>();

        foreach (int[] Query in Queries)
        {
            int Left = Query[0];
            int Right = Query[1];
            int Step = Query[2];
            int Value = Query[3];
            
            if (Step >= Threshold)
            {
                for (int Index = Left; Index <= Right; Index += Step)
                    Nums[Index] = (int)((1L * Nums[Index] * Value) % Modulus);
            }
            else
            {
                if (!LightQueries.ContainsKey(Step))
                    LightQueries[Step] = new List<int[]>();
                    
                LightQueries[Step].Add(Query);
            }
        }

        foreach (var Entry in LightQueries)
        {
            int Step = Entry.Key;
            var QueryList = Entry.Value;
            long[] MultiplierDiff = new long[ArrayLength];
            
            Array.Fill(MultiplierDiff, 1L);
            
            foreach (int[] Query in QueryList)
            {
                int Left = Query[0];
                int Right = Query[1];
                int Value = Query[3];
                
                MultiplierDiff[Left] = (MultiplierDiff[Left] * Value) % Modulus;
                
                int StepsCount = (Right - Left) / Step;
                int NextIndex = Left + (StepsCount + 1) * Step;
                
                if (NextIndex < ArrayLength)
                    MultiplierDiff[NextIndex] = (MultiplierDiff[NextIndex] * CalculateModularInverse(Value)) % Modulus;
            }
            
            for (int Index = 0; Index < ArrayLength; Index++)
            {
                if (Index >= Step)
                    MultiplierDiff[Index] = (MultiplierDiff[Index] * MultiplierDiff[Index - Step]) % Modulus;
                    
                Nums[Index] = (int)((1L * Nums[Index] * MultiplierDiff[Index]) % Modulus);
            }
        }

        int TotalXor = 0;
        
        foreach (int Num in Nums)
            TotalXor ^= Num;

        return TotalXor;
    }
}
