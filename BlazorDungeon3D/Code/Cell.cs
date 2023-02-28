namespace BlazorDungeon3D.Code
{
    public enum CellType
    {
        Corridor = '0',
        Wall = '1'
    }

    public enum ItemType
    {
        Apple = 'a',
        Cheese = 'c',
        Water = 'w',
        Bread = 'b',
        Corn = 'o',
        Scroll = 's'
    }

    public class Cell
    {
        public CellType type; 
        public string cssClass;
        public string character { get; set; }
        public bool visible;        // True for draw on display map

        public ItemType item1; 
        public ItemType item2;

        public string GetItem1TypeName()
        {
            return Enum.GetName(typeof(ItemType), item1);
        }

        public string GetItem2TypeName()
        {
            return Enum.GetName(typeof(ItemType), item2);
        }
    }
}
