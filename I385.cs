public class Solution {
    public int MaxSumDivThree(int[] nums) {
        int total = 0;
        int minOne1 = -1, minOne2 = -1, minTwo1 = -1, minTwo2 = -1;
        for (int i = 0; i < nums.Length; i++) {
            total += nums[i];
            switch (nums[i] % 3) {
                case 1:
                    if (nums[i] < minOne1 || minOne1 == -1) {
                        minOne2 = minOne1;
                        minOne1 = nums[i];
                    } else if (nums[i] < minOne2 || minOne2 == -1) {
                        minOne2 = nums[i];
                    }
                    break;
                case 2:
                    if (nums[i] < minTwo1 || minTwo1 == -1) {
                        minTwo2 = minTwo1;
                        minTwo1 = nums[i];
                    } else if (nums[i] < minTwo2 || minTwo2 == -1) {
                        minTwo2 = nums[i];
                    }
                    break;
                default:
                    break;
            }
        }

        int sub = total;
        switch (total % 3) {
            case 1:
                if (minOne1 > -1) sub = minOne1;
                if (minTwo2 > -1) sub = Math.Min(sub, minTwo1 + minTwo2);
                break;
            case 2:
                if (minTwo1 > -1) sub = minTwo1;
                if (minOne2 > -1) sub = Math.Min(sub, minOne1 + minOne2);
                break;
            default:
                sub = 0;
                break;
        }

        return total - sub;
    }
}