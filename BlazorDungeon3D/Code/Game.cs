namespace BlazorDungeon3D.Code
{
    public class Game
    {
        public Player player;
        public Map map;
        public ViewPort viewport;
        public Compass compass;
        public int speed;           // Milliseconds between moves
        public bool waitMovement;

        public Game()
        {
            player = new Player();
            map = new Map();
            viewport = new ViewPort();
            compass = new Compass();
            speed = 200;
        }

        public void Move(string code)
        {
            switch (code)
            {
                case "KeyW":
                    GoForward();
                    break;
                case "KeyS":
                    GoBack();
                    break;
                case "KeyA":
                    GoLeft();
                    break;
                case "KeyD":
                    GoRight();
                    break;
                case "KeyQ":
                    TurnLeft();
                    break;
                case "KeyE":
                    TurnRight();
                    break;
            }

            map.UpdateVisibleMap(player.curX, player.curY);
        }

        public void Render()
        {
            viewport.UpdateViewport(player, map);
            map.UpdateCellMap(player.curX, player.curY, player.curDir);
        }

        public void GoForward()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX, player.curY - 1].type == '0') player.curY--;
                    break;
                case 1:
                    if (map.mapCells[player.curX + 1, player.curY].type == '0') player.curX++;
                    break;
                case 2:
                    if (map.mapCells[player.curX, player.curY + 1].type == '0') player.curY++;
                    break;
                case 3:
                    if (map.mapCells[player.curX - 1, player.curY].type == '0') player.curX--;
                    break;
            }

            Render();
        }

        public void GoBack()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX, player.curY + 1].type == '0') player.curY++;
                    break;
                case 1:
                    if (map.mapCells[player.curX - 1, player.curY].type == '0') player.curX--;
                    break;
                case 2:
                    if (map.mapCells[player.curX, player.curY - 1].type == '0') player.curY--;
                    break;
                case 3:
                    if (map.mapCells[player.curX + 1, player.curY].type == '0') player.curX++;
                    break;
            }

            Render();
        }

        public void GoLeft()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX - 1, player.curY].type == '0') player.curX--;
                    break;
                case 1:
                    if (map.mapCells[player.curX, player.curY - 1].type == '0') player.curY--;
                    break;
                case 2:
                    if (map.mapCells[player.curX + 1, player.curY].type == '0') player.curX++;
                    break;
                case 3:
                    if (map.mapCells[player.curX, player.curY + 1].type == '0') player.curY++;
                    break;
            }

            Render();
        }

        public void GoRight()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX + 1, player.curY].type == '0') player.curX++;
                    break;
                case 1:
                    if (map.mapCells[player.curX, player.curY + 1].type == '0') player.curY++;
                    break;
                case 2:
                    if (map.mapCells[player.curX - 1, player.curY].type == '0') player.curX--;
                    break;
                case 3:
                    if (map.mapCells[player.curX, player.curY - 1].type == '0') player.curY--;
                    break;
            }

            Render();
        }

        public void TurnLeft()
        {
            if (player.curDir > 0)
                player.curDir--;
            else
                player.curDir = 3;

            Render();
        }

        public void TurnRight()
        {
            if (player.curDir < 3)
                player.curDir++;
            else
                player.curDir = 0;

            Render();
        }
    }
}
