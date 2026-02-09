public class Solution {
    public TreeNode BalanceBST(TreeNode root) {
        var nodeList = new List<TreeNode>();
        CollectNodes(root, nodeList);
        return BuildBalancedTree(nodeList, 0, nodeList.Count - 1);
    }
    // Collect nodes with an in-order traversal
    private void CollectNodes(TreeNode node, List<TreeNode> nodeList) {
        if (node == null) return;
        CollectNodes(node.left, nodeList);
        nodeList.Add(node);
        CollectNodes(node.right, nodeList);
    }
    // Rebuild tree from sorted nodes
    private TreeNode BuildBalancedTree(List<TreeNode> nodeList, int start, int end) {
        if (start > end) return null;
        int mid = start + (end - start) / 2;
        TreeNode root = nodeList[mid];
        root.left = BuildBalancedTree(nodeList, start, mid - 1);
        root.right = BuildBalancedTree(nodeList, mid + 1, end);
        return root;
    }
}
