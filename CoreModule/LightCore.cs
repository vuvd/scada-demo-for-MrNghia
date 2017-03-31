using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

using BLLModule;
using CoreModuleConfig;
namespace CoreModule
{
    public class LightCore
    {
        public int LightId { get; set; }
        public TextBlock UIForLight { get; set; }
        public Button UIForOn { get; set; }
        public Button UIForOff { get; set; }

        public static List<LightCore> GetList;

        public static void Init()
        {
            GetList = new List<LightCore>();
            int[] lightIdArray = LightConfig.Init();
            foreach (int lightId in lightIdArray)
            {
                LightCore light = new LightCore
                {
                    LightId = lightId,
                    UIForLight = new TextBlock(),
                    UIForOn = new Button(),
                    UIForOff = new Button(),
                };
                if (LightBLL.Create(lightId, false))
                {
                    GetList.Add(light);
                }
            }            
        }        

        public static void ApplyCurrentStatus()
        {
            foreach (LightCore light in GetList)
            {
                ApplyStatus(light.LightId, light.UIForLight);
                light.UIForOn.Click += On;
                light.UIForOff.Click += Off;
            }
        }

        public static void On(object sender, System.Windows.RoutedEventArgs e)
        {
            Button uiForOn = sender as Button;
            LightCore light = GetList.FirstOrDefault(l => l.UIForOn == uiForOn);
            if (light == null)
                return;
            if (LightBLL.SetStatus(light.LightId, true) == true)
            {
                LightCore.ApplyStatus(light.LightId, light.UIForLight);
            }            
        }

        public static void Off(object sender, System.Windows.RoutedEventArgs e)
        {
            Button uiForOff = sender as Button;
            LightCore light = GetList.FirstOrDefault(l => l.UIForOff == uiForOff);
            if (light == null)
                return;
            if (LightBLL.SetStatus(light.LightId, false) == true)
            {
                LightCore.ApplyStatus(light.LightId, light.UIForLight);
            }
        }        

        private static void ApplyStatus(int lightId, TextBlock textBlock)
        {
            bool status = LightBLL.GetStatus(lightId);
            if (status == true)
                textBlock.Background = Brushes.SkyBlue;
            else
                textBlock.Background = Brushes.Gray;
        }        
    }
}
