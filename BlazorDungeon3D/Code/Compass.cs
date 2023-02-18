namespace BlazorDungeon3D.Code
{
    public class Compass
    {
        public string Draw(int curDir)
        {
            string ret = "";

            switch (curDir)
            {
                case 0:
                    ret = Char.ConvertFromUtf32(8681);
                    break;
                case 1:
                    ret = Char.ConvertFromUtf32(8678);
                    break;
                case 2:
                    ret = Char.ConvertFromUtf32(8679);
                    break;
                case 3:
                    ret = Char.ConvertFromUtf32(8680);
                    break;
            }

            return ret;
        }
    }
}
