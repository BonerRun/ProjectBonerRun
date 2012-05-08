namespace BonerRun.Core
{
	public abstract class GameState : GameObject
	{
        public GameState(GameManager mrg)
            : base(mrg)
        { }

        public abstract void Initialize();

        public abstract void Update();

        public abstract void Draw();

        public abstract void Destroy();
	}
}
