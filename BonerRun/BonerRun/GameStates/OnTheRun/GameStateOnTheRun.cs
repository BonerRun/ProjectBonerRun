using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonerRun.Core;
using BonerRun.Level;
namespace BonerRun.GameStates.OnTheRun
{
    public class GameStateOnTheRun:GameState
    {

        private LevelManager levelManager;


        public GameStateOnTheRun(GameManager mrg)
            : base(mrg)
        {
        }

        public override void Initialize()
        {
            levelManager = new LevelManager(parentManager);

        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            parentManager.renderCore.render();
        }

        public override void Destroy()
        {

        }

    }
}
