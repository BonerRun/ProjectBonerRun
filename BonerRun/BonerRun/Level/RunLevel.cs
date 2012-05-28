using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MoshiRendering.Core;
using BonerRun.Content;
using BonerRun.Obstacles;
namespace BonerRun.Level
{
    public class RunLevel
    {

        public RenderImage background
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public List<IObstacle> obstacles
        {
            get;
            set;
        }


        public static RunLevel LoadLevel(string path,RenderingCore renderCore)
        {
            RunLevel level = new RunLevel();

            FileLoader.activeFormat = FileFormat.NameFirst;
            FileLoader.activeReader = new StreamReader(File.Open(path, FileMode.Open));

            RenderGroup group = new RenderGroup("levelScenery");

            level.name = (string)FileLoader.Load(string.Empty);
            level.background = new RenderImage(renderCore, null, group, 0);
            level.background.camAffected = true;
            level.background.image = (Texture2D)FileLoader.Load(new Texture2D(renderCore.graphicsDevice,1,1));

            renderCore.objects.Add(level.background);


            level.obstacles = new List<IObstacle>();
            List<Obstacle> list = FileLoader.loadList<Obstacle>();

            foreach (Obstacle obstacle in list)
            {
                level.obstacles.Add(obstacle);
            }
            RenderGroup obstacleGroup = new RenderGroup("Obstacles");

            foreach(IObstacle obstacle in level.obstacles)
            {         
                obstacle.parent = renderCore;
                obstacle.position = new Vector2(obstacle.position.X, obstacle.position.Y + renderCore.settings.screensize.Y - obstacle.getcurrentAnimation().size.Y);
                Vector2 scale = new Vector2(renderCore.settings.screensize.X / renderCore.settings.standardsize.X, renderCore.settings.screensize.Y / renderCore.settings.standardsize.Y);
                obstacle.position = new Vector2(obstacle.position.X * scale.X, obstacle.position.Y * scale.Y);
                obstacle.layer = 1;
                obstacleGroup.objects.Add(obstacle);
            }

            obstacleGroup.AddEverythingToRenderingCore(renderCore);

            return level;
        }

    }
}
