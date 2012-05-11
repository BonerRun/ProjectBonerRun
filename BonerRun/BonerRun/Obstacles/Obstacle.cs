using Microsoft.Xna.Framework;
using MoshiRendering.Animation;
namespace BonerRun.Obstacles
{
    public class Obstacle:Animated,IObstacle
    {
        public string key
        {
            get;
            set;
        }

        public Rectangle hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)getcurrentAnimation().size.X, (int)getcurrentAnimation().size.Y); }
        }
    }
}
