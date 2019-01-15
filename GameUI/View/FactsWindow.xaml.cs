using AGAST2.Infrastructure.LevelTypes;
using GameUI.View;
using GameUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AGAST2.GameUI
{
    /// <summary>
    /// Interaction logic for TwoPlayers.xaml
    /// </summary>
    public partial class FactsWindow : Window
    {

        public FactsWindow()
        {
            InitializeComponent();

        }


        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Instructions(object sender, RoutedEventArgs e)
        {
            HowToPlay instructionsWindow = new HowToPlay();
            instructionsWindow.Show();
            this.Close();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var dataContext = (ViewModelFacts)DataContext;
            dataContext.KeyModifer = e.SystemKey.ToString();
            int success = dataContext.OnKeyDown(e.Key.ToString());
            if (success == 1)
            {
                PlayerOneWin p1 = new PlayerOneWin();
                p1.Show();
                this.Close();
            }
            if(success == 2)
            {
                PlayerTwoWin p2 = new PlayerTwoWin();
                p2.Show();
                this.Close();
            }

        }


    }
}
