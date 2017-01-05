using System;
using System.Collections.Generic;
using System.Text;

namespace WindowSpy
{
    class WindowEnumerator
    {
        public struct Window
        {
            public string ClassName;
            public string Text;

            public override string ToString()
            {
                return "[" + ClassName + "] - '" + Text + "'";
            }

            public int IconIndex
            {
                get
                {
                    switch (ClassName)
                    {
                        case "Shell_TrayWnd":
                            return 4;
                        case "Progman":
                            return 1;
                        default:
                            return 0;
                    }
                }
            }
        }

        private int count = 0;
        private List<Window> windows = new List<Window>();

        public void Thing()
        {
            windows.Clear();
            InteropStuff.EnumWindows(Callback, IntPtr.Zero);
            System.Windows.Forms.MessageBox.Show("I got " + count.ToString() + " windows");
        }

        private bool Callback(IntPtr hWnd, IntPtr lParam)
        {
            count++;
            Console.Out.WriteLine("I got " + hWnd.ToString());

            var text = InteropStuff.GetWindowText(hWnd);
            var className = InteropStuff.GetClassName(hWnd);

            windows.Add(new Window { Text = text, ClassName = className });

            return true;
        }

        public List<Window> Windows
        {
            get
            {
                return windows;
            }
        }
    }
}
