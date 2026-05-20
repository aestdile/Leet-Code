public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        int[] C = new int[B.Length];
        HashSet<int> numbers = new HashSet<int>();
        for(int i=0;i<A.Length;i++){
            numbers.Add(A[i]);
            numbers.Add(B[i]);
            C[i]=(i+1)*2-numbers.Count;
        }
        return C;
    }
}
