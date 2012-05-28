using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoshiRendering.Animation;
namespace BonerRun.Core
{
    public class AnimatedGameObject:Animated
    {
        public GameManager parentManager
        {
            get;
            set;
        }

        public AnimatedGameObject(GameManager parentManager)
		{
            this.parentManager = parentManager;
		}
    }
}
