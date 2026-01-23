public class Node {
    public long value;
    public int left; // Store original index for identification
    public Node prev;
    public Node next;

    public Node(long value, int left) {
        this.value = value;
        this.left = left;
    }
}

public class Item : IComparable<Item> {
    public Node first;
    public Node second;
    public long cost;

    public Item(Node first, Node second, long cost) {
        this.first = first;
        this.second = second;
        this.cost = cost;
    }

    public int CompareTo(Item other) {
        // Compare by cost; if equal, compare by index for consistency
        if (cost == other.cost) {
            return first.left.CompareTo(other.first.left);
        }
        return cost.CompareTo(other.cost);
    }
}

public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        var pq = new PriorityQueue<Item, Item>();
        bool[] merged = new bool[nums.Length];
        int decreaseCount = 0;
        int count = 0;
        
        List<Node> nodes = new List<Node>();
        nodes.Add(new Node(nums[0], 0));

        // Initialize doubly linked list and priority queue
        for (int i = 1; i < nums.Length; i++) {
            nodes.Add(new Node(nums[i], i));
            // Set up double links
            nodes[i - 1].next = nodes[i];
            nodes[i].prev = nodes[i - 1];
            
            // Add pair to PQ
            var item = new Item(nodes[i - 1], nodes[i],
                                nodes[i - 1].value + nodes[i].value);
            pq.Enqueue(item, item);

            // Count initial inversions
            if (nums[i - 1] > nums[i]) {
                decreaseCount++;
            }
        }

        while (decreaseCount > 0) {
            if (pq.Count == 0) break; 

            var item = pq.Dequeue();
            Node first = item.first;
            Node second = item.second;
            long cost = item.cost;

            // Validation check (Lazy removal)
            // Skip if nodes are already merged or cost is outdated
            if (merged[first.left] || merged[second.left] ||
                first.value + second.value != cost) {
                continue;
            }

            count++;
            
            // Logic to update inversion count
            // 1. The current pair (first, second) is being merged
            if (first.value > second.value) {
                decreaseCount--;
            }

            Node prevNode = first.prev;
            Node nextNode = second.next;

            // Update links: 'first' will represent the new merged node
            first.next = nextNode;
            if (nextNode != null) {
                nextNode.prev = first;
            }
            // 'second' is removed from the chain

            // 2. Check relationship with prevNode (left neighbor)
            if (prevNode != null) {
                // Old relation: (prev, first) -> New relation: (prev, new_first)
                bool oldRelation = prevNode.value > first.value;
                bool newRelation = prevNode.value > cost; // cost is the new value of first

                if (oldRelation && !newRelation) {
                    decreaseCount--; // Inversion removed
                } else if (!oldRelation && newRelation) {
                    decreaseCount++; // Inversion added
                }
                
                // Add new pair to PQ
                var newItem = new Item(prevNode, first, prevNode.value + cost);
                pq.Enqueue(newItem, newItem);
            }

            // 3. Check relationship with nextNode (right neighbor)
            if (nextNode != null) {
                // Old relation: (second, next) -> New relation: (new_first, next)
                bool oldRelation = second.value > nextNode.value;
                bool newRelation = cost > nextNode.value;

                if (oldRelation && !newRelation) {
                    decreaseCount--;
                } else if (!oldRelation && newRelation) {
                    decreaseCount++;
                }
                
                // Add new pair to PQ
                var newItem = new Item(first, nextNode, cost + nextNode.value);
                pq.Enqueue(newItem, newItem);
            }

            // Update value of the merged node and mark second as merged
            first.value = cost;
            merged[second.left] = true;
        }

        return count;
    }
}
