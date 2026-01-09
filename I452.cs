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
    private class Result {
        public TreeNode node;
        public int depth;

        public Result(TreeNode node, int depth) {
            this.node = node;
            this.depth = depth;
        }
    }
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        return Dfs(root).node;
    }
    private Result Dfs(TreeNode root) {
        if (root == null) {
            return new Result(null, 0);
        }

        Result left = Dfs(root.left);
        Result right = Dfs(root.right);

        if (left.depth == right.depth) {
            return new Result(root, left.depth + 1);
        }

        if (left.depth > right.depth) {
            return new Result(left.node, left.depth + 1);
        } else {
            return new Result(right.node, right.depth + 1);
        }
    }
}
