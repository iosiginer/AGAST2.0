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
    /// Interaction logic for PlayerOneWin.xaml
    /// </summary>
    public partial class PlayerOneWin : Window
    {
        public PlayerOneWin()
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
