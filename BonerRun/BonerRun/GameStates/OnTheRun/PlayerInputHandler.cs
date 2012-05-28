using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using BonerRun.Core;
using BonerRun.Input;
namespace BonerRun.GameStates.OnTheRun
{
    public class PlayerInputHandler:InputHandler
    {

        private InputManager parent;
        private GameManager mrg;

        public PlayerInputHandler(GameManager mrg)
        {
            this.parent = mrg.inputManager;
            this.mrg = mrg;
            name = "PlayerInputHandler";
            isActive = true;
        }

        public override void handlePad()
        {
            if (parent.padoldstate.Buttons.A == ButtonState.Released && parent.padstate.Buttons.A == ButtonState.Pressed)
            {
                mrg.player.Jump();
            }
        }


        public override void handleKeyboard()
        {
            if (parent.oldstate.IsKeyUp(Keys.Up) && parent.state.IsKeyDown(Keys.Up))
            {
                mrg.player.Jump();
            }

            if (parent.oldstate.IsKeyUp(Keys.RightControl) && parent.state.IsKeyDown(Keys.RightControl))
            {
                mrg.player.ShortHop();
            }

            if (parent.oldstate.IsKeyUp(Keys.Escape) && parent.state.IsKeyDown(Keys.Escape))
            {
                mrg.game.Exit();
            }

            if (parent.oldstate.IsKeyUp(Keys.Enter) && parent.state.IsKeyDown(Keys.Enter))
            {
                ((GameStateOnTheRun)mrg.gameStates[0]).Reset();
            }

        }


    }
}
