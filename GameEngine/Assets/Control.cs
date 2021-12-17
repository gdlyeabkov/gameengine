using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameEngine
{
    class Control
    {
        
        public MainWindow listener;
        public static Key releasedKey = Key.None;
        public static Key pressedKey = Key.None;
        public static string pressedMouseBtn = "None";

        public static bool IsKeyFree(Key key)
        {
            if (key == releasedKey)
            {
                releasedKey = Key.None;
                return true;
            } else
            {
                return false;
            }
        }

        public static bool IsKeyHolded(Key key)
        {
            if (key == pressedKey)
            {
                pressedKey = Key.None;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsMouseBtn(string btn, bool isHold)
        {
            if (btn == pressedMouseBtn)
            {
                if (!isHold) {
                    pressedMouseBtn = "None";
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Control(MainWindow listener)
        {
            this.listener = listener;
            this.listener.KeyUp += ControlKeyUpHandler;
            this.listener.KeyDown += ControlKeyDownHandler;
            this.listener.MouseUp += ControlMouseUpHandler;
            this.listener.MouseDown += ControlMouseDownHandler;
        }

        public static void ControlKeyDownHandler(object sender, KeyEventArgs e)
        {
            pressedKey = e.Key;
        }

        public static void ControlKeyUpHandler(object sender, KeyEventArgs e)
        {
            releasedKey = e.Key;
        }

        public static void ControlMouseUpHandler(object sender, MouseEventArgs e)
        {
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "left";
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "middle";
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "right";
            }*/
            pressedMouseBtn = "None";

        }

        public static void ControlMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "left";
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "middle";
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                pressedMouseBtn = "right";
            }

        }
    }
}
