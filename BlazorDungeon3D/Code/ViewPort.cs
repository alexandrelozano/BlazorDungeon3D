using System.Numerics;

namespace BlazorDungeon3D.Code
{
    public class ViewPort
    {
        public int vpWidth;
        public int vpHeight;
        public Dictionary<string, string> dicDispBlocks;

        public ViewPort()
        {
            vpWidth = 448;
            vpHeight = 272;

            InitializeDispBlocks();
        }

        private void InitializeDispBlocks()
        {
            dicDispBlocks = new Dictionary<string, string>();

            dicDispBlocks.Add("wallLside0", "none");
            dicDispBlocks.Add("wallLside1", "none");
            dicDispBlocks.Add("wallLside2", "none");
            dicDispBlocks.Add("wallLside3", "none");
            dicDispBlocks.Add("wallLside0_walldecor", "none");
            dicDispBlocks.Add("wallLside1_walldecor", "none");

            dicDispBlocks.Add("wallRside0", "none");
            dicDispBlocks.Add("wallRside1", "none");
            dicDispBlocks.Add("wallRside2", "none");
            dicDispBlocks.Add("wallRside3", "none");
            dicDispBlocks.Add("wallRside0_walldecor", "none");
            dicDispBlocks.Add("wallRside1_walldecor", "none");

            dicDispBlocks.Add("wallSide1_1", "none");
            dicDispBlocks.Add("doorSide1_1", "none");
            dicDispBlocks.Add("doorSide1_1_inner", "none");
            dicDispBlocks.Add("doorSide1_2", "none");
            dicDispBlocks.Add("doorSide1_2_inner", "none");

            dicDispBlocks.Add("wallFront1", "none");
            dicDispBlocks.Add("wallfrontTEXT", "none");
            dicDispBlocks.Add("doorFront1", "none");
            dicDispBlocks.Add("doorFront1_inner", "none");

            dicDispBlocks.Add("doorFront1_button", "none");
            dicDispBlocks.Add("wallSide1_2", "none");

            dicDispBlocks.Add("wallSide2_1", "none");
            dicDispBlocks.Add("doorSide2_1", "none");
            dicDispBlocks.Add("doorSide2_1_inner", "none");
            dicDispBlocks.Add("wallFront2", "none");
            dicDispBlocks.Add("wallFront2_walldecor", "none");
            dicDispBlocks.Add("doorFront2", "none");
            dicDispBlocks.Add("doorFront2_inner", "none");
            dicDispBlocks.Add("wallSide2_2", "none");
            dicDispBlocks.Add("doorSide2_2", "none");
            dicDispBlocks.Add("doorSide2_2_inner", "none");

            dicDispBlocks.Add("wallSide3_1", "none");
            dicDispBlocks.Add("wallFront3", "none");
            dicDispBlocks.Add("wallSide3_2", "none");

            for (int i = 1; i <= 3; i++)
                foreach (string zone in new []{ "L", "R"})
                    foreach (string itemType in Enum.GetNames(typeof(ItemType)))
                        dicDispBlocks.Add($"item{itemType}{zone}_{i}", "none");

        }

        private void disblock(string xclass)
        {
            dicDispBlocks[xclass] = "block";
        }

        private void hideblock(string xclass)
        {
            dicDispBlocks[xclass] = "none";
        }

        private void checkcell(Map map, int x, int y, string xclass)
        {
            if (x >= 0 && x < map.mapCells.GetLength(0) && y >= 0 && y < map.mapCells.GetLength(1))
            {
                if (map.mapCells[x, y].type == CellType.Wall)
                    disblock(xclass);
                else
                    hideblock(xclass);
            }
        }

        private void checkItems(Map map, int x, int y, int dir, int order)
        {
            string zone1 = (dir == 0 || dir == 1) ? "L" : "R";
            string zone2 = (dir == 0 || dir == 1) ? "R" : "L";

            if (x > 0 && y > 0 && x < map.mapCells.GetLength(0) && y < map.mapCells.GetLength(1) && map.mapCells[x, y].item1 > 0)
                disblock($"item{map.mapCells[x, y].GetItem1TypeName()}{zone1}_{order}");
            else
                foreach (string itemType in Enum.GetNames(typeof(ItemType)))
                    hideblock($"item{itemType}{zone1}_{order}");

            if (x > 0 && y > 0 && x < map.mapCells.GetLength(0) && y < map.mapCells.GetLength(1) && map.mapCells[x, y].item2 > 0)
                disblock($"item{map.mapCells[x, y].GetItem2TypeName()}{zone2}_{order}");
            else
                foreach (string itemType in Enum.GetNames(typeof(ItemType)))
                    hideblock($"item{itemType}{zone2}_{order}");
        }

        public void UpdateViewport(Player player, Map map)
        {
            switch (player.curDir)
            {
                case 0:
                    checkcell(map, player.curX - 1, player.curY, "wallRside0");
                    checkcell(map, player.curX + 1, player.curY, "wallLside0");
                    checkcell(map, player.curX - 1, player.curY - 1, "wallRside1");
                    checkcell(map, player.curX + 1, player.curY - 1, "wallLside1");
                    checkcell(map, player.curX - 1, player.curY - 2, "wallRside2");
                    checkcell(map, player.curX + 1, player.curY - 2, "wallLside2");
                    checkcell(map, player.curX - 1, player.curY - 3, "wallRside3");
                    checkcell(map, player.curX + 1, player.curY - 3, "wallLside3");
                    checkcell(map, player.curX, player.curY - 1, "wallFront1");
                    checkcell(map, player.curX - 1, player.curY - 1, "wallSide1_2");
                    checkcell(map, player.curX + 1, player.curY - 1, "wallSide1_1");
                    checkcell(map, player.curX, player.curY - 2, "wallFront2");
                    checkcell(map, player.curX - 1, player.curY - 2, "wallSide2_2");
                    checkcell(map, player.curX + 1, player.curY - 2, "wallSide2_1");
                    checkcell(map, player.curX, player.curY - 3, "wallFront3");
                    checkcell(map, player.curX - 1, player.curY - 3, "wallSide3_2");
                    checkcell(map, player.curX + 1, player.curY - 3, "wallSide3_1");
                    checkcell(map, player.curX + 1, player.curY - 3, "wallSide3_1");

                    checkItems(map, player.curX, player.curY - 3, player.curDir, 3);
                    checkItems(map, player.curX, player.curY - 2, player.curDir, 2);
                    checkItems(map, player.curX, player.curY - 1, player.curDir, 1);

                    break;

                case 1:
                    checkcell(map, player.curX, player.curY + 1, "wallRside0");
                    checkcell(map, player.curX, player.curY - 1, "wallLside0");
                    checkcell(map, player.curX - 1, player.curY + 1, "wallRside1");
                    checkcell(map, player.curX - 1, player.curY - 1, "wallLside1");
                    checkcell(map, player.curX - 2, player.curY + 1, "wallRside2");
                    checkcell(map, player.curX - 2, player.curY - 1, "wallLside2");
                    checkcell(map, player.curX - 3, player.curY + 1, "wallRside3");
                    checkcell(map, player.curX - 3, player.curY - 1, "wallLside3");
                    checkcell(map, player.curX - 1, player.curY, "wallFront1");
                    checkcell(map, player.curX - 1, player.curY + 1, "wallSide1_2");
                    checkcell(map, player.curX - 1, player.curY - 1, "wallSide1_1");
                    checkcell(map, player.curX - 2, player.curY, "wallFront2");
                    checkcell(map, player.curX - 2, player.curY + 1, "wallSide2_2");
                    checkcell(map, player.curX - 2, player.curY - 1, "wallSide2_1");
                    checkcell(map, player.curX - 3, player.curY, "wallFront3");
                    checkcell(map, player.curX - 3, player.curY + 1, "wallSide3_2");
                    checkcell(map, player.curX - 3, player.curY - 1, "wallSide3_1");
                    checkcell(map, player.curX - 3, player.curY - 1, "wallSide3_1");

                    checkItems(map, player.curX - 3, player.curY, player.curDir, 3);
                    checkItems(map, player.curX - 2, player.curY, player.curDir, 2);
                    checkItems(map, player.curX - 1, player.curY, player.curDir, 1);

                    break;

                case 2:
                    checkcell(map, player.curX + 1, player.curY, "wallRside0");
                    checkcell(map, player.curX - 1, player.curY, "wallLside0");
                    checkcell(map, player.curX + 1, player.curY + 1, "wallRside1");
                    checkcell(map, player.curX - 1, player.curY + 1, "wallLside1");
                    checkcell(map, player.curX + 1, player.curY + 2, "wallRside2");
                    checkcell(map, player.curX - 1, player.curY + 2, "wallLside2");
                    checkcell(map, player.curX + 1, player.curY + 3, "wallRside3");
                    checkcell(map, player.curX - 1, player.curY + 3, "wallLside3");
                    checkcell(map, player.curX, player.curY + 1, "wallFront1");
                    checkcell(map, player.curX + 1, player.curY + 1, "wallSide1_2");
                    checkcell(map, player.curX - 1, player.curY + 1, "wallSide1_1");
                    checkcell(map, player.curX, player.curY + 2, "wallFront2");
                    checkcell(map, player.curX + 1, player.curY + 2, "wallSide2_2");
                    checkcell(map, player.curX - 1, player.curY + 2, "wallSide2_1");
                    checkcell(map, player.curX, player.curY + 3, "wallFront3");
                    checkcell(map, player.curX + 1, player.curY + 3, "wallSide3_2");
                    checkcell(map, player.curX - 1, player.curY + 3, "wallSide3_1");

                    checkItems(map, player.curX, player.curY + 3, player.curDir, 3);
                    checkItems(map, player.curX, player.curY + 2, player.curDir, 2);
                    checkItems(map, player.curX, player.curY + 1, player.curDir, 1);

                    break;

                case 3:
                    checkcell(map, player.curX, player.curY - 1, "wallRside0");
                    checkcell(map, player.curX, player.curY + 1, "wallLside0");
                    checkcell(map, player.curX + 1, player.curY - 1, "wallRside1");
                    checkcell(map, player.curX + 1, player.curY + 1, "wallLside1");
                    checkcell(map, player.curX + 2, player.curY - 1, "wallRside2");
                    checkcell(map, player.curX + 2, player.curY + 1, "wallLside2");
                    checkcell(map, player.curX + 3, player.curY - 1, "wallRside3");
                    checkcell(map, player.curX + 3, player.curY + 1, "wallLside3");
                    checkcell(map, player.curX + 1, player.curY, "wallFront1");
                    checkcell(map, player.curX + 1, player.curY - 1, "wallSide1_2");
                    checkcell(map, player.curX + 1, player.curY, "wallFront1");
                    checkcell(map, player.curX + 1, player.curY + 1, "wallSide1_1");
                    checkcell(map, player.curX + 2, player.curY, "wallFront2");
                    checkcell(map, player.curX + 2, player.curY - 1, "wallSide2_2");
                    checkcell(map, player.curX + 2, player.curY + 1, "wallSide2_1");
                    checkcell(map, player.curX + 3, player.curY, "wallFront3");
                    checkcell(map, player.curX + 3, player.curY - 1, "wallSide3_2");
                    checkcell(map, player.curX + 3, player.curY + 1, "wallSide3_1");

                    checkItems(map, player.curX + 3, player.curY, player.curDir, 3);
                    checkItems(map, player.curX + 2, player.curY, player.curDir, 2);
                    checkItems(map, player.curX + 1, player.curY, player.curDir, 1);

                    break;
            }
        }
    }
}
