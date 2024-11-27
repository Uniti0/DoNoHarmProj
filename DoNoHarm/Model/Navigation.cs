using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoNoHarm.Model
{
    internal static class Navigation
    {
        public static Frame Frame { get; private set; }
        public static Page ActivePage { get; private set; }
        private static bool FrameSelect;

        public static void SetFrame(Frame frame)
        {
            if (FrameSelect == true) 
                return;
            Frame = frame;
            FrameSelect = true;
        }

        public static void Navigate(Page page)
        {
            Frame.Navigate(page);
            ActivePage = page;
        }
    }
}
