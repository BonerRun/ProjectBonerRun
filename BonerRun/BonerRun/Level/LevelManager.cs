using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonerRun.Core;
namespace BonerRun.Level
{
    public class LevelManager
    {


        public RunLevel currentLevel
        {
            get;
            set;
        }

        public List<RunLevel> followingLevels
        {
            get;
            set;
        }

        public LevelManager(GameManager mrg)
        {
            followingLevels = new List<RunLevel>();


            //Loading a test level
            currentLevel = RunLevel.LoadLevel("Content/Levels/JonisBoner.boner",mrg.renderCore);

        }


    }
}
