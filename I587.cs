public class Solution {
    public bool AsteroidsDestroyed(int mass, int[] asteroids) {
        Array.Sort(asteroids);
        long bigMass = mass;
        foreach(var rock in asteroids){
            if(bigMass >= rock){
                bigMass+=rock;
            }else{
                return false;;
            }
        }

        return true;
    }
}
