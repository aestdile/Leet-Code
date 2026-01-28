public class Solution
{
    public int MinCost(int[][] Grid, int MaxTeleports)
    {
        int RowCount = Grid.Length;
        int ColumnCount = Grid[0].Length;
        int MaxValue = 0;

        for (int RowIndex = 0; RowIndex < RowCount; RowIndex++)
            for (int ColIndex = 0; ColIndex < ColumnCount; ColIndex++)
                MaxValue = Math.Max(MaxValue, Grid[RowIndex][ColIndex]);

        int[,] MinCosts = new int[RowCount, ColumnCount];
        int[] MinCostByValue = new int[MaxValue + 1];
        int[] MinPrefixCost = new int[MaxValue + 1];

        for (int ValueIndex = 0; ValueIndex <= MaxValue; ValueIndex++)
            MinCostByValue[ValueIndex] = int.MaxValue;

        MinCostByValue[Grid[RowCount - 1][ColumnCount - 1]] = 0;

        for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
        {
            MinCosts[RowCount - 1, ColIndex] = MinCosts[RowCount - 1, ColIndex + 1] + Grid[RowCount - 1][ColIndex + 1];
            MinCostByValue[Grid[RowCount - 1][ColIndex]] = Math.Min(MinCostByValue[Grid[RowCount - 1][ColIndex]], MinCosts[RowCount - 1, ColIndex]);
        }

        for (int RowIndex = RowCount - 2; RowIndex >= 0; RowIndex--)
        {
            MinCosts[RowIndex, ColumnCount - 1] = MinCosts[RowIndex + 1, ColumnCount - 1] + Grid[RowIndex + 1][ColumnCount - 1];
            MinCostByValue[Grid[RowIndex][ColumnCount - 1]] = Math.Min(MinCostByValue[Grid[RowIndex][ColumnCount - 1]], MinCosts[RowIndex, ColumnCount - 1]);

            for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
            {
                MinCosts[RowIndex, ColIndex] = Math.Min(
                    MinCosts[RowIndex + 1, ColIndex] + Grid[RowIndex + 1][ColIndex],
                    MinCosts[RowIndex, ColIndex + 1] + Grid[RowIndex][ColIndex + 1]
                );
                MinCostByValue[Grid[RowIndex][ColIndex]] = Math.Min(MinCostByValue[Grid[RowIndex][ColIndex]], MinCosts[RowIndex, ColIndex]);
            }
        }

        for (int TeleportStep = 0; TeleportStep < MaxTeleports; TeleportStep++)
        {
            MinPrefixCost[0] = MinCostByValue[0];
            for (int ValueIndex = 1; ValueIndex <= MaxValue; ValueIndex++)
                MinPrefixCost[ValueIndex] = Math.Min(MinPrefixCost[ValueIndex - 1], MinCostByValue[ValueIndex]);

            for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
            {
                MinCosts[RowCount - 1, ColIndex] = Math.Min(
                    MinPrefixCost[Grid[RowCount - 1][ColIndex]],
                    MinCosts[RowCount - 1, ColIndex + 1] + Grid[RowCount - 1][ColIndex + 1]
                );
                MinCostByValue[Grid[RowCount - 1][ColIndex]] = Math.Min(MinCostByValue[Grid[RowCount - 1][ColIndex]], MinCosts[RowCount - 1, ColIndex]);
            }

            for (int RowIndex = RowCount - 2; RowIndex >= 0; RowIndex--)
            {
                MinCosts[RowIndex, ColumnCount - 1] = Math.Min(
                    MinPrefixCost[Grid[RowIndex][ColumnCount - 1]],
                    MinCosts[RowIndex + 1, ColumnCount - 1] + Grid[RowIndex + 1][ColumnCount - 1]
                );
                MinCostByValue[Grid[RowIndex][ColumnCount - 1]] = Math.Min(MinCostByValue[Grid[RowIndex][ColumnCount - 1]], MinCosts[RowIndex, ColumnCount - 1]);

                for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
                {
                    int WalkCost = Math.Min(
                        MinCosts[RowIndex + 1, ColIndex] + Grid[RowIndex + 1][ColIndex],
                        MinCosts[RowIndex, ColIndex + 1] + Grid[RowIndex][ColIndex + 1]
                    );

                    MinCosts[RowIndex, ColIndex] = Math.Min(WalkCost, MinPrefixCost[Grid[RowIndex][ColIndex]]);
                    MinCostByValue[Grid[RowIndex][ColIndex]] = Math.Min(MinCostByValue[Grid[RowIndex][ColIndex]], MinCosts[RowIndex, ColIndex]);
                }
            }
        }

        return MinCosts[0, 0];
    }
}
