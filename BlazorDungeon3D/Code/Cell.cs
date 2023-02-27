﻿namespace BlazorDungeon3D.Code
{
    public enum CellType
    {
        Corridor = '0',
        Wall = '1'
    }

    public class Cell
    {
        public CellType type;           // 0 Corridor  1 Wall
        public string cssClass;
        public string character { get; set; }
        public bool visible;        // True for draw on display map

        public char item1;          // a apple
        public char item2;
    }
}
