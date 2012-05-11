using Microsoft.Xna.Framework;
using MoshiRendering.Animation;
namespace BonerRun.Obstacles
{
    public interface IObstacle:IAnimated
    {
        string key
        {
            get;
            set;
        }

        Rectangle hitbox
        {
            get;
        }
    }
}
