public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int ans = 0;

        for (int i = 0; i < fruits.Length; i++)
        {
            bool check = false;
            for (int j = 0; j < baskets.Length; j++)
            {
                if (fruits[i] <= baskets[j])
                {
                    check = true;
                    baskets[j] = 0;
                    break;
                }
            }
            if (check == false)
            {
                ans += 1;
            }
        }
        return ans;
    }
}
