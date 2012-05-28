using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BonerRun.Core;
using BonerRun.Level;
using BonerRun.Obstacles;
using MoshiRendering.Core;
namespace BonerRun.GameStates.OnTheRun
{
    public class GameStateOnTheRun:GameState
    {

        private LevelManager levelManager;


        private float countDown = 0.5f;
        private RenderText countDownText;


        private bool running = true;

        public GameStateOnTheRun(GameManager mrg)
            : base(mrg)
        {
        }

        public override void Initialize()
        {
            levelManager = new LevelManager(parentManager);

            parentManager.renderCore.camera.position = new Vector2(parentManager.renderCore.settings.screensize.X / 2, parentManager.renderCore.settings.screensize.Y / 2);

            countDownText = new RenderText(parentManager.renderCore,countDown.ToString(),Color.Black);
            countDownText.position = new Vector2(parentManager.renderCore.settings.screensize.X / 2, parentManager.renderCore.settings.screensize.Y / 2);
            countDownText.layer = 2;
            parentManager.renderCore.objects.Add(countDownText);

            parentManager.renderCore.objects.Add(parentManager.player);
            parentManager.renderCore.animationManager.animations.Add(parentManager.player);
            parentManager.player.position = new Vector2(100, parentManager.renderCore.settings.screensize.Y - parentManager.player.getcurrentAnimation().size.Y);



            PlayerInputHandler handler = new PlayerInputHandler(parentManager);
            parentManager.inputManager.registerHandler(handler);

        }

        public override void Update()
        {

            if (countDown > 0)
            {
                countDown -= 0.016f;             
                countDownText.text = (countDown.ToString()).Substring(0, 3);
                if (countDown < 0)
                {
                    parentManager.renderCore.objects.Remove(countDownText);
                    countDown = 0;
                }
            }
            else if(running)
            {
                //Real game loop right here
                parentManager.player.Update();
                parentManager.renderCore.camera.position = new Vector2(parentManager.player.position.X + parentManager.renderCore.settings.screensize.X/3, parentManager.renderCore.camera.position.Y);

                //Collision Detection with the environment

                foreach (IObstacle obstacle in levelManager.currentLevel.obstacles)
                {

                    if (parentManager.player.hitbox.Intersects(obstacle.hitbox))
                    {
                        Color[] playerColor = new Color[(int)parentManager.player.getcurrentAnimation().size.X * (int)parentManager.player.getcurrentAnimation().size.Y];
                        Color[] obstacleColor = new Color[(int)obstacle.getcurrentAnimation().size.X * (int) obstacle.getcurrentAnimation().size.Y];

                        parentManager.player.getCurrentFrameTexture().GetData(playerColor);
                        obstacle.getCurrentFrameTexture().GetData(obstacleColor);

                        if(IntersectPixels(parentManager.player.hitbox,playerColor,obstacle.hitbox,obstacleColor))
                        {
                            running = false;
                            Reset();
                        }
                    }
                }
            }

            parentManager.renderCore.update();

        }

        public override void Draw()
        {
            parentManager.renderCore.render();
        }

        public override void Destroy()
        {

        }


        public void Reset()
        {
            countDown = 0.5f;
            parentManager.player.position = new Vector2(100, parentManager.renderCore.settings.screensize.Y - parentManager.player.getcurrentAnimation().size.Y);
            parentManager.renderCore.camera.position = new Vector2(parentManager.player.position.X + parentManager.renderCore.settings.screensize.X / 3, parentManager.renderCore.camera.position.Y);
            running = true;
            parentManager.renderCore.objects.Add(countDownText);
            parentManager.player.Reset();
        }

        /// <summary>
        /// Determines if there is overlap of the non-transparent pixels
        /// between two sprites.
        /// </summary>
        /// <param name="rectangleA">Bounding rectangle of the first sprite</param>
        /// <param name="dataA">Pixel data of the first sprite</param>
        /// <param name="rectangleB">Bouding rectangle of the second sprite</param>
        /// <param name="dataB">Pixel data of the second sprite</param>
        /// <returns>True if non-transparent pixels overlap; false otherwise</returns>
        private bool IntersectPixels(Rectangle rectangleA, Color[] dataA,
                                    Rectangle rectangleB, Color[] dataB)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }


    }
}
