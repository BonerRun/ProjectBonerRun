using System;
using Microsoft.Xna.Framework;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeVector2 : DataType<Vector2>
    {
        public DataTypeVector2()
        {
            type = typeof(Vector2);
        }

        protected override Vector2 loadDataP(string input)
        {
            return new Vector2(float.Parse(input.Split('/')[0]), float.Parse(input.Split('/')[1]));
        }

        protected override string saveDataP(Vector2 input)
        {
            return input.X + "/" + input.Y;
        }
    }
}
