using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CoreModule;
namespace ClientModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int[] lightIdUsing = new int[] { 1001, 1002 };
            LightCore.Init();
            List<LightCore> lightList = LightCore.GetList.Where(l => lightIdUsing.Contains(l.LightId)).ToList();

            lightList[0].UIForLight = lblLight;
            lightList[0].UIForOn = btnOn;
            lightList[0].UIForOff = btnOff;

            lightList[1].UIForLight = lblLight1;
            lightList[1].UIForOn = btnOn1;
            lightList[1].UIForOff = btnOff1;

            lightList[2].UIForLight = lblLight2;
            lightList[2].UIForOn = btnOn2;
            lightList[2].UIForOff = btnOff2;

            LightCore.ApplyCurrentStatus();
        }
    }
}
