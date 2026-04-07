using System;
using System.Collections.Generic;

public class Robot {
    private bool moved = false;
    private int idx = 0;
    private List<int[]> pos = new List<int[]>();
    private List<int> dir = new List<int>();
    private Dictionary<int, string> toDir = new Dictionary<int, string>();

    public Robot(int width, int height) {
        toDir[0] = "East";
        toDir[1] = "North";
        toDir[2] = "West";
        toDir[3] = "South";

        for (int i = 0; i < width; ++i) {
            pos.Add(new int[] { i, 0 });
            dir.Add(0);
        }
        for (int i = 1; i < height; ++i) {
            pos.Add(new int[] { width - 1, i });
            dir.Add(1);
        }
        for (int i = width - 2; i >= 0; --i) {
            pos.Add(new int[] { i, height - 1 });
            dir.Add(2);
        }
        for (int i = height - 2; i > 0; --i) {
            pos.Add(new int[] { 0, i });
            dir.Add(3);
        }
        dir[0] = 3;
    }

    public void Step(int num) {
        moved = true;
        idx = (idx + num) % pos.Count;
    }

    public int[] GetPos() {
        return pos[idx];
    }

    public string GetDir() {
        if (!moved) {
            return "East";
        }
        return toDir[dir[idx]];
    }
}
