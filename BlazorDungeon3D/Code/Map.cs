namespace BlazorDungeon3D.Code
{
    public class Map
    {
        public Cell[,] mapCells;

        string chPlayerN = "";
        string chPlayerS = "";
        string chPlayerW = "";
        string chPlayerE = "";
        string chWall = "";
        string chCorridor = "";

        string[] txtCells = {
            "111111111111111111111111111111111111111111111111111111111111111111111",
            "100000100000000010000000001000000000000000001000000000100000000010001",
            "101110111010111011111110101111101111101111101010111110101111111010111",
            "101010001010101000001000100000101000001010001010000010101000000010001",
            "101011101010101111101011111110101011111010111111111010101011111111101",
            "101010001010101000100010001000101000101000100000000010001000100000001",
            "101010111110101010111111101011111110101011111011111111111110111011111",
            "101000000000100010100000001000000000100000000010000000000010001000001",
            "101011111111111010101011111111111111101111111111111110111011101111101",
            "101000100000001010001000000010000000100010000000000010001000101000001",
            "101111101111101011111111101110101110111010111111111011101111101011111",
            "101000100000101000100000100000100010100010100000001000100000000010001",
            "101010101111101110101111111111111011101110111110101110111111111110111",
            "100010001000001010100000001000001000000010000010100010000000100010001",
            "101111111011111010111110101011101111111011111010111011111110101011101",
            "100010001010000000100010100010001000001000001010001000100010001010001",
            "111011101010111111101010101111111011101111111011111010101111111010111",
            "100010001010000000001000101000000010100000001000100010100010000010101",
            "101110111011111111101111111011111110111111101110101110101010111110101",
            "101000100010001000101000001010001000000000101000100010101010000010001",
            "101010101110101010111011101010101110111110101011111010111011111011101",
            "100010100000100010000000100000100000100000100000000010000000001000001",
            "111111111111111111111111111111111111111111111111111111111111111111111" };

        public Map()
        {
            chPlayerN = Char.ConvertFromUtf32(11165);
            chPlayerS = Char.ConvertFromUtf32(11167);
            chPlayerW = Char.ConvertFromUtf32(11164);
            chPlayerE = Char.ConvertFromUtf32(11166);
            chWall = Char.ConvertFromUtf32(1047550);
            chCorridor = " ";

            mapCells =  new Cell[txtCells[0].Length, txtCells.GetLength(0)];

            for (int x = 0; x < txtCells[0].Length; x++)
                for (int y = 0; y < txtCells.GetLength(0); y++)
                {
                    mapCells[x, y] = new Cell();
                    mapCells[x, y].type = txtCells[txtCells.GetLength(0) - y - 1][x];
                    mapCells[x, y].visible = false;
                }
        }

        public void UpdateVisibleMap(int curX, int curY, int curDir)
        {
            int x;
            int y;

            switch (curDir)
            {
                case 0:
                    x = curX;
                    for (y = curY; y >= curY - 3; y--)
                        if (y >= 0 && y < mapCells.GetLength(1))
                            if (mapCells[x, y].type == '0')
                            {
                                mapCells[x, y].visible = true;

                                if (x - 1 >= 0) mapCells[x - 1, y].visible = true;
                                if (x + 1 < mapCells.GetLength(0)) mapCells[x + 1, y].visible = true;
                            }
                            else if (mapCells[x, y].type == '1')
                            {
                                mapCells[x, y].visible = true;
                                break;
                            }
                    break;
                case 1:
                    y = curY;
                    for (x = curX; x >= curX - 3; x--)
                        if (x >= 0 && x < mapCells.GetLength(0))
                            if (mapCells[x, y].type == '0')
                            {
                                mapCells[x, y].visible = true;

                                if (y - 1 >= 0) mapCells[x, y - 1].visible = true;
                                if (y + 1 < mapCells.GetLength(1)) mapCells[x, y + 1].visible = true;
                            }
                            else if (mapCells[x, y].type == '1')
                            {
                                mapCells[x, y].visible = true;
                                break;
                            }
                    break;
                case 2:
                    x = curX;
                    for (y = curY; y <= curY + 3; y++)
                        if (y >= 0 && y < mapCells.GetLength(1))
                            if (mapCells[x, y].type == '0')
                            {
                                mapCells[x, y].visible = true;

                                if (x - 1 >= 0) mapCells[x - 1, y].visible = true;
                                if (x + 1 < mapCells.GetLength(0)) mapCells[x + 1, y].visible = true;
                            }
                            else if (mapCells[x, y].type == '1')
                            {
                                mapCells[x, y].visible = true;
                                break;
                            }
                    break;
                case 3:
                    y = curY;
                    for (x = curX; x <= curX + 3; x++)
                        if (x >= 0 && x < mapCells.GetLength(0))
                            if (mapCells[x, y].type == '0')
                            {
                                mapCells[x, y].visible = true;

                                if (y - 1 >= 0) mapCells[x, y - 1].visible = true;
                                if (y + 1 < mapCells.GetLength(1)) mapCells[x, y + 1].visible = true;
                            }
                            else if (mapCells[x, y].type == '1')
                            {
                                mapCells[x, y].visible = true;
                                break;
                            }
                    break;
            }
        }

        public void UpdateCellMap(int curX, int curY, int curDir)
        {
            for (int y = mapCells.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < mapCells.GetLength(0); x++)
                {
                    if (mapCells[x, y].visible)
                    {
                        if (curX == x && curY == y)
                        {
                            switch (curDir)
                            {
                                case 0:
                                    mapCells[x, y].character = chPlayerS;
                                    break;
                                case 1:
                                    mapCells[x, y].character = chPlayerW;
                                    break;
                                case 2:
                                    mapCells[x, y].character = chPlayerN;
                                    break;
                                case 3:
                                    mapCells[x, y].character = chPlayerE;
                                    break;
                            }
                            mapCells[x, y].cssClass = "mapplayer";
                        }
                        else
                        {
                            if (mapCells[x, y].type == '1')
                            {
                                mapCells[x, y].character = chWall;
                                mapCells[x, y].cssClass = "mapwall";
                            }
                            else
                            {
                                mapCells[x, y].character = chCorridor;
                                mapCells[x, y].cssClass = "mapcorridor";
                            }
                        }
                    }
                    else
                    {
                        mapCells[x, y].character = chCorridor;
                        mapCells[x, y].cssClass = "mapcorridor";
                    }
                }
            }
        }
    }
}