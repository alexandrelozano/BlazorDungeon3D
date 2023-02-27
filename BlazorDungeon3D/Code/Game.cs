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
        public Dictionary<Commands, bool> waitMovements;

        public enum Commands
        {
            GoForward,
            GoBackward, 
            GoLeft, 
            GoRight, 
            TurnLeft, 
            TurnRight
        }

        public Game()
        {
            player = new Player();
            map = new Map();
            viewport = new ViewPort();
            compass = new Compass();
            speed = 200;
            waitMovements = new Dictionary<Commands, bool>
            {
                { Commands.GoForward, false },
                { Commands.GoBackward, false },
                { Commands.GoLeft, false },
                { Commands.GoRight, false },
                { Commands.TurnLeft, false },
                { Commands.TurnRight, false }
            };
        }

        public void beginWaitMovement(Commands command)
        {
            waitMovement = true;
            waitMovements[command] = true;
        }

        public void resetWaitMovements()
        {
            waitMovement = false;
            foreach (var key in waitMovements.Keys)
                waitMovements[key] = false;
        }

        public void DoCommand(Commands command)
        {
            switch (command)
            {
                case Commands.GoForward:
                    GoForward();
                    break;
                case Commands.GoBackward:
                    GoBackward();
                    break;
                case Commands.GoLeft:
                    GoLeft();
                    break;
                case Commands.GoRight:
                    GoRight();
                    break;
                case Commands.TurnLeft:
                    TurnLeft();
                    break;
                case Commands.TurnRight:
                    TurnRight();
                    break;
            }
        }

        public void Render()
        {
            viewport.UpdateViewport(player, map);
            map.UpdateVisibleMap(player.curX, player.curY, player.curDir);
            map.UpdateCellMap(player.curX, player.curY, player.curDir);
        }

        public void GoForward()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX, player.curY - 1].type == CellType.Corridor) player.curY--;
                    break;
                case 1:
                    if (map.mapCells[player.curX - 1, player.curY].type == CellType.Corridor) player.curX--;
                    break;
                case 2:
                    if (map.mapCells[player.curX, player.curY + 1].type == CellType.Corridor) player.curY++;
                    break;
                case 3:
                    if (map.mapCells[player.curX + 1, player.curY].type == CellType.Corridor) player.curX++;
                    break;
            }

            Render();
        }

        public void GoBackward()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX, player.curY + 1].type == CellType.Corridor) player.curY++;
                    break;
                case 1:
                    if (map.mapCells[player.curX + 1, player.curY].type == CellType.Corridor) player.curX++;
                    break;
                case 2:
                    if (map.mapCells[player.curX, player.curY - 1].type == CellType.Corridor) player.curY--;
                    break;
                case 3:
                    if (map.mapCells[player.curX - 1, player.curY].type == CellType.Corridor) player.curX--;
                    break;
            }

            Render();
        }

        public void GoLeft()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX + 1, player.curY].type == CellType.Corridor) player.curX++;
                    break;
                case 1:
                    if (map.mapCells[player.curX, player.curY - 1].type == CellType.Corridor) player.curY--;
                    break;
                case 2:
                    if (map.mapCells[player.curX - 1, player.curY].type == CellType.Corridor) player.curX--;
                    break;
                case 3:
                    if (map.mapCells[player.curX, player.curY + 1].type == CellType.Corridor) player.curY++;
                    break;
            }

            Render();
        }

        public void GoRight()
        {
            switch (player.curDir)
            {
                case 0:
                    if (map.mapCells[player.curX - 1, player.curY].type == CellType.Corridor) player.curX--;
                    break;
                case 1:
                    if (map.mapCells[player.curX, player.curY + 1].type == CellType.Corridor) player.curY++;
                    break;
                case 2:
                    if (map.mapCells[player.curX + 1, player.curY].type == CellType.Corridor) player.curX++;
                    break;
                case 3:
                    if (map.mapCells[player.curX, player.curY - 1].type == CellType.Corridor) player.curY--;
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
