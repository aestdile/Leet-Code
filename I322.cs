public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            var limit = 100001;
            var prefixSum = new int[limit];
            for (var i = 0; i < potions.Length; i++)
            {
                var neededSpellCost = success % potions[i] == 0
                    ? success / potions[i]
                    : success / potions[i] + 1;

                if (neededSpellCost < limit)
                    prefixSum[neededSpellCost]++;
            }

            for (var i = 1; i < prefixSum.Length; i++)
                prefixSum[i] += prefixSum[i - 1];

            var result = new int[spells.Length];
            for (var i = 0; i <  spells.Length; i++)
                result[i] = prefixSum[spells[i]];

            return result;
        }
}
