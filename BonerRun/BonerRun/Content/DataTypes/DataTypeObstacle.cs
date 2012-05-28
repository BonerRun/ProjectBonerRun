using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoshiRendering.Animation;
using BonerRun.Obstacles;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeObstacle:DataType<Obstacle>
    {

        public DataTypeObstacle()
        {
            type = typeof(Obstacle);
        }

        protected override Obstacle loadDataP(string input)
        {
            Obstacle obstacle = new Obstacle();

            string[] args = input.Split(';');

            obstacle.position = new Vector2(int.Parse(args[0].Split('/')[0]), int.Parse(args[0].Split('/')[1]));
            obstacle.spriteSheet = FileLoader.contentManager.Load<Texture2D>("Graphic/Obstacles/" + args[1]);
            obstacle.camAffected = true;

            obstacle.animations = new List<MoshiRendering.Animation.IAnimation>();
            obstacle.animations.Add(new Animation(obstacle,1,new Vector2(obstacle.spriteSheet.Width,obstacle.spriteSheet.Height),false,Vector2.Zero,1));


            return obstacle;     
        }

        protected override string saveDataP(Obstacle input)
        {
            return input.ToString();
        }
    }
}
