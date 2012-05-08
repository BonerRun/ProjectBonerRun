using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using MoshiRendering.Core;
using BonerRun.Input;
using BonerRun.GameStates.Intro;
namespace BonerRun.Core
{
	public sealed class GameManager
	{
        public List<GameState> gameStates
        {
            get;
            set;
        }

        public GameSettings gameSettings
        {
            get;
            set;
        }

        public GameInfo gameInfo
        {
            get;
            set;
        }

        public RenderingCore renderCore
        {
            get;
            set;
        }

        public InputManager inputManager
        {
            get;
            set;
        }

        public BonerGame game
        {
            get;
            set;
        }

		public GameManager(BonerGame game)
		{
            this.game = game;


		}

		public void Initialize()
		{
            renderCore = new RenderingCore(game.GraphicsDevice, game.Content);
            inputManager = new InputManager("Keyboard");


            gameStates = new List<GameState>();
            gameStates.Add(new GameStateIntro(this));
		}

		public void Update()
		{
            gameStates[0].Update();
		}

		public void Draw()
		{
            gameStates[0].Draw();
		}

        public void GameStateBack()
        {
            if (gameStates.Count >= 1)
            {
                gameStates[0].Destroy();
                gameStates.RemoveAt(0);
            }
        }

        public void setGameState(GameState gameState, bool initialize, bool destroyold)
        {
            if (destroyold)
            {
                GameStateBack();
            }

            if (initialize)
            {
                gameState.Initialize();
            }
            gameStates.Insert(0, gameState);
        }

	}
}
