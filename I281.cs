public class Solution {
    public int MaxFreqSum(string s) {
        int[] vowels = new int[26];
        int[] consonans = new int[26];
        int maxVowel = 0;
        int maxConsonans = 0;
        for (int i = 0; i < s.Length; i++){
            if (s[i] == 'a' || s[i] == 'e' || s[i] == 'u' || s[i] == 'i' || s[i] == 'o'){
                vowels[s[i] - 'a']++;
                if (vowels[s[i] - 'a'] > maxVowel) maxVowel = vowels[s[i] - 'a'];
            }
            else{
                consonans[s[i] - 'a']++;
                if (consonans[s[i] - 'a'] > maxConsonans) maxConsonans = consonans[s[i] - 'a'];
            }
        }
        return maxVowel + maxConsonans; 
    }
}
