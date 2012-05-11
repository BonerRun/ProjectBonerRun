using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoshiRendering.Animation;
using BonerRun.Obstacles;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeTexture2D : DataType<Texture2D>
    {

        public DataTypeTexture2D()
        {
            type = typeof(Texture2D);
        }

        protected override Texture2D loadDataP(string input)
        {
            return FileLoader.contentManager.Load<Texture2D>(input);
        }

        protected override string saveDataP(Texture2D input)
        {
            return input.ToString();
        }
    }
}
