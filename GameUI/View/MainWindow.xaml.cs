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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AGAST2.GameUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Button btn = new Button
            {
                Name = "TwoPlayersButton"
            };
            btn.Click += TwoPlayersButton_Click;
            Button button = new Button
            {
                Name = "Trivia"
            };
            button.Click += Trivia_Click;


        }

        private void TwoPlayersButton_Click(object sender, RoutedEventArgs e)
        {

            TwoPlayers twoPlayers = new TwoPlayers(0, 0);
            twoPlayers.Show();
            this.Close();

        }


        private void Trivia_Click(object sender, RoutedEventArgs e)
        {
            Trivia trivia = new Trivia(0, 0);
            trivia.Show();
            this.Close();

        }
    }
}
