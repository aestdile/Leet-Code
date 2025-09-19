public class Spreadsheet {
    private int rows;
    private Dictionary<string, int> cells;

    public Spreadsheet(int rows) {
        this.rows = rows;
        this.cells = new Dictionary<string, int>();
    }
    
    public void SetCell(string cell, int value) {
        cells[cell] = value;
    }
    
    public void ResetCell(string cell) {
        cells.Remove(cell);
    }
    
    public int GetValue(string formula) {
        string[] parts = formula.Substring(1).Split('+');
        int GetVal(string s) => int.TryParse(s, out int v) ? v : cells.GetValueOrDefault(s, 0);
        return GetVal(parts[0]) + GetVal(parts[1]);
    }
}
