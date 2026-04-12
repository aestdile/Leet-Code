public class Solution {
    public int MinimumDistance(string word) {
        if (word.Length < 3) {
            return 0;
        }

        return MinDistance(word, 0, null, new Dictionary<(int, int?), int>());
    }

    public int MinDistance(string word, int lastLeft, int? lastRight, Dictionary<(int, int?), int> state) {
        var prevPos = lastLeft;
        if(lastRight != null) {
            prevPos = Math.Max(lastLeft, lastRight.Value);
        }

        if (prevPos == word.Length - 2) {
            if (lastRight == null) {
                return 0;
            }
            var distanceFromLeft = Distance(word[lastLeft], word[word.Length - 1]);
            var distanceFromRight = Distance(word[lastRight.Value], word[word.Length - 1]);

            return Math.Min(distanceFromLeft, distanceFromRight);
        }

        var key = (lastLeft, lastRight);
        if (!state.ContainsKey(key)) {
            var distanceFromRight = 0;
            var rightPos = 0;
            if (lastRight != null) {
                distanceFromRight = Distance(word[lastRight.Value], word[prevPos + 1]);
                rightPos = lastRight.Value;
            }
            var ifUsedRight = MinDistance(word, lastLeft, prevPos + 1, state) + distanceFromRight;

            var distanceFromLeft = Distance(word[lastLeft], word[prevPos + 1]);
            var ifUsedLeft = MinDistance(word, prevPos + 1, lastRight, state) + distanceFromLeft;

            state[key] = Math.Min(ifUsedLeft, ifUsedRight);
        }

        return state[key];
    }

    public int Distance(char from, char to) {
        (var xFrom, var yFrom) = Position(from);
        (var xTo, var yTo) = Position(to);

        var r = Math.Abs(xFrom - xTo) + Math.Abs(yFrom - yTo);
        return r;
    }

    public (int, int) Position(char c) {
        var code = (int)c - (int)'A';
        var x = code % 6;
        var y = code / 6;

        return (x, y);
    }
}
