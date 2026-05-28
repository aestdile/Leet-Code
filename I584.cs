public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        Trie trie = new();

        int indexIfNothingIsFound = -1;
        int minLength = int.MaxValue;

        for (int i = 0; i < wordsContainer.Length; i++)
        {
            var reverse = Reverse(wordsContainer[i]);
            trie.Add(Reverse(wordsContainer[i]), i);

            if (reverse.Length < minLength)
            {
                minLength = reverse.Length;
                indexIfNothingIsFound = i;
            }
        }
        
        List<int> result = new(wordsQuery.Length);

        foreach (var prefix in wordsQuery.Select(Reverse))
        {
            var index = trie.GetNodeByPrefix(prefix);
            result.Add(index == -1 ? indexIfNothingIsFound : index);
        }

        return [.. result];
    }

    private static char[] Reverse(string s)
    {
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            result[i] = s[s.Length - 1 - i];
        }

        return result;
    }
}

internal class Trie
{
    private readonly IEqualityComparer<char> _comparer;
    private readonly TrieNode _root;

    public Trie(IEqualityComparer<char> comparer = null)
    {
        _comparer = comparer ?? EqualityComparer<char>.Default;
        _root = new TrieNode(char.MinValue);
    }

    public void Add(char[] word, int index)
    {
        TrieNode current = _root;

        foreach (var c in word)
        {
            var n = GetChildNode(current, c);

            if (n is not null)
            {
                current = n;
            }
            else
            {
                var node = new TrieNode(c);
                current.Children.Add(node);
                current = node;
            }
        }

        if (!current.IsTerminal)
        {
            current.WordLength = word.Length;
            current.Index = index;
        }
    }

    public int GetNodeByPrefix(char[] prefix)
    {
        var current = _root;

        foreach (var c in prefix)
        {
            var n = GetChildNode(current, c);

            if (n is null)
            {
                break;
            }

            current = n;
        }

        if (current == _root)
        {
            return -1;
        }

        if (current.IsTerminal)
        {
            return current.Index;
        }

        Queue<TrieNode> queue = new(current.Children);
        int minIndex = int.MaxValue;
        int minLength = int.MaxValue;

        while (queue.Count > 0)
        {
            var n = queue.Dequeue();

            if (n.IsTerminal)
            {
                if (minLength > n.WordLength)
                {
                    minLength = n.WordLength;
                    minIndex = n.Index;
                }
                else if (minLength == n.WordLength)
                {
                    minIndex = Math.Min(minIndex, n.Index);
                }

            }
            else
            {
                foreach (var childNode in n.Children)
                {
                    queue.Enqueue(childNode);
                }
            }
        }

        return minIndex;
    }

    private TrieNode GetChildNode(TrieNode node, char key)
    {
        foreach (var n in node.Children)
        {
            if (_comparer.Equals(key, n.Key))
            {
                return n;
            }
        }

        return null;
    }

    private sealed class TrieNode(char key)
    {
        public char Key { get; } = key;

        public int Index { get; set; }

        public bool IsTerminal => WordLength != -1;

        public int WordLength { get; set; } = -1;

        public List<TrieNode> Children { get; } = [];

        public override string ToString() => $"Key: {Key}";
    }
}
