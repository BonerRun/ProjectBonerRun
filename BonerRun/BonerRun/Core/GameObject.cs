namespace BonerRun.Core
{
	public class GameObject
	{
        public GameManager parentManager
        {
            get;
            set;
        }

		public GameObject(GameManager parentManager)
		{
            this.parentManager = parentManager;
		}
	}
}
