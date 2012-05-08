using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
namespace BonerRun.Input
{
    public class InputManager
    {
        #region Members
        public Dictionary<string, InputHandler> handels
        {
            get;
            set;
        }

        public bool noInput
        {
            get;
            set;
        }

        public KeyboardState state
        {
            get;
            set;
        }

        public KeyboardState oldstate
        {
            get;
            set;
        }

        public GamePadState padstate
        {
            get;
            set;
        }
        public GamePadState padoldstate
        {
            get;
            set;
        }

        public string inputDevice
        {
            get;
            set;
        }

        private int pointer = 0;
        #endregion

        public InputManager(string device)
        {
            handels = new Dictionary<string, InputHandler>();
            inputDevice = device;
        }

        public void Update()
        {
            oldstate = state;
            state = Keyboard.GetState();

            padoldstate = padstate;
            padstate = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

            if (!noInput)
            {
                int i = 0;

                try
                {
                    foreach (var handle in this.handels)
                    {
                        if (i == pointer)
                        {
                            if (handle.Value.isActive)
                            {
                                if (inputDevice == "XBOX")
                                {
                                    handle.Value.handlePad();
                                }
                                else if (inputDevice == "Keyboard")
                                {
                                    handle.Value.handleKeyboard();
                                }
                            }
                            pointer++;
                            i++;
                        }
                        else
                        {
                            i++;
                        }                     
                    }
                }
                catch (Exception e)
                {
                    this.Update();           
                }
                pointer = 0;
            }

        }


        public void registerHandler(string name, InputHandler handler)
        {
            this.handels.Add(name, handler);
        }
        public void registerHandler(string name, InputHandler handler, bool active)
        {
            handler.isActive = active;
            this.handels.Add(name, handler);
        }

        public void setHandlerActive(string name, bool active)
        {
            foreach (var handler in handels)
            {
                if(handler.Key == name)
                {
                    handler.Value.isActive = active;
                }
            }
        }

    }
}
