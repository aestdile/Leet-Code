
public class Solution {
    public int DayOfYear(string date) {
        int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        
        string[] parts = date.Split('-');
        int year = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int day = int.Parse(parts[2]);

        if (IsLeapYear(year)) {
            daysInMonths[1] = 29;
        }

        int dayOfYear = day;
        for (int i = 0; i < month - 1; i++) {
            dayOfYear += daysInMonths[i];
        }

        return dayOfYear;
    }

    private bool IsLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
