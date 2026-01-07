/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private const int MOD = 1_000_000_007;
    private long totalSum = 0;
    private long maxProduct = 0;
    public int MaxProduct(TreeNode root) {
        totalSum = GetTotalSum(root);
        ComputeSubtreeSum(root);
        return (int)(maxProduct % MOD);
    }
    private long GetTotalSum(TreeNode node) {
        if (node == null) return 0;
        return node.val + GetTotalSum(node.left) + GetTotalSum(node.right);
    }
    private long ComputeSubtreeSum(TreeNode node) {
        if (node == null) return 0;

        long leftSum = ComputeSubtreeSum(node.left);
        long rightSum = ComputeSubtreeSum(node.right);

        long subtreeSum = node.val + leftSum + rightSum;

        long product = subtreeSum * (totalSum - subtreeSum);
        maxProduct = Math.Max(maxProduct, product);

        return subtreeSum;
    }
}
