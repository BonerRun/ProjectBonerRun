namespace BonerRun.Input
{
    public abstract class InputHandler:IInputHandler
    {

        #region Members
        public bool isActive
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
        #endregion

        public abstract void handlePad();

        public abstract void handleKeyboard();

    }
}
