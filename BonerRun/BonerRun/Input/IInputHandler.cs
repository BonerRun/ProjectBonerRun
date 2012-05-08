namespace BonerRun.Input
{
    public interface IInputHandler
    {

        #region Members
        bool isActive
        {
            get;
            set;
        }

        string name
        {
            get;
            set;
        }
        #endregion

        void handlePad();

        void handleKeyboard();

    }
}
