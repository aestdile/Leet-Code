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
    public IList<int> PreorderTraversal(TreeNode root) {
        if (root == null){
            return new List<int>();
        }

        var list = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count != 0){
            var currentNode = stack.Pop();
            list.Add(currentNode.val);

            if (currentNode.right != null){
                stack.Push(currentNode.right);
            }

            if (currentNode.left != null){
                stack.Push(currentNode.left);
            }
        }
        return list;
    }
}
