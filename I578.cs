public class Solution {
    private class TrieNode {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfNumber = false;
    }
    
    // Trie class with insert and search functionality
    private class Trie {
        private readonly TrieNode root;

        public Trie() {
            root = new TrieNode();
        }

        // Insert a number string into the Trie
        public void Insert(string number) {
            TrieNode current = root;
            foreach (char c in number) {
                if (!current.Children.ContainsKey(c)) {
                    current.Children[c] = new TrieNode();
                }
                current = current.Children[c];
            }
            current.IsEndOfNumber = true;
        }
        public int GetLongestCommonPrefixLength(string number) {
            TrieNode current = root;
            int prefixLength = 0;

            foreach (char c in number) {
                if (!current.Children.ContainsKey(c)) {
                    break;
                }
                current = current.Children[c];
                prefixLength++;
            }

            return prefixLength;
        }
    }
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        Trie trie = new Trie();
        int maxLength = 0;

        // Insert all numbers from arr1 into the Trie
        foreach (int num in arr1) {
            trie.Insert(num.ToString());
        }

        // Check each number from arr2 against the Trie to find the longest common prefix
        foreach (int num in arr2) {
            int commonPrefixLength = trie.GetLongestCommonPrefixLength(num.ToString());
            maxLength = Math.Max(maxLength, commonPrefixLength);
        }

        return maxLength;
    }
}
