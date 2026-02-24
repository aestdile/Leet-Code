public class Solution
{
    public int SumRootToLeaf(TreeNode? root, int? number = 0)
        => root?.left is null && root?.right is null
            ? number * 2 + root?.val ?? 0
            : SumRootToLeaf(root.left, number * 2 + root.val) + SumRootToLeaf(root.right, number * 2 + root.val);
}
