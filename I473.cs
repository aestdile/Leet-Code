public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
      int n = letters.Length;
      for(int i =0;i<n;i++){
        if(letters[i]>target){
            return letters[i];
        }
      }
      return letters[0];
    }
}
