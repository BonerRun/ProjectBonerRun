using System;
using Microsoft.Xna.Framework;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeColor : DataType<Color>
    {
        public DataTypeColor()
        {
            type = typeof(Color);
        }

        protected override Color loadDataP(string input)
        {
            return new Color(Int32.Parse(input.Split('.')[0]), Int32.Parse(input.Split('.')[1]), Int32.Parse(input.Split('.')[2]));
        }

        protected override string saveDataP(Color input)
        {
            return input.R + "." + input.G + "." + input.B;
        }
    }
}
