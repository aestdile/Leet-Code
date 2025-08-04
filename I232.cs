public class Solution {
    public int TotalFruit(int[] fruits) {
        int sum = 0;
        for (int i = 0; i < fruits.Length; i++)
        {
            List<int> ls = new();
            int calc = 0;
            for (int j = i; j < fruits.Length; j++)
            {
                if (ls.IndexOf(fruits[j]) != -1)
                    calc++;
                else if (ls.Count <= 1 && ls.IndexOf(fruits[j]) == -1)
                {
                    ls.Add(fruits[j]);
                    calc++;
                }
                else if (ls.Count == 2 && ls.IndexOf(fruits[j]) == -1)
                    break;
            }
            if (calc > sum)
                sum = calc;
            if (sum > fruits.Length - (i + 1))
                break;
        }
        return sum;
    }
}
