using AGAST2.GameUI;
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

namespace GameUI.View
{
    /// <summary>
    /// Interaction logic for PlayerTwoWin.xaml
    /// </summary>
    public partial class PlayerTwoWin : Window
    {
        public PlayerTwoWin()
        {
            InitializeComponent();
        }

        private void TryAgain(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
