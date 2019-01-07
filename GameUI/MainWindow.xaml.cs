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

namespace MusicApp
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
                Name = "btn1"
            };
            btn.Click += Btn1_Click;
            Button button = new Button
            {
                Name = "btn2"
            };
            button.Click += Btn2_Click;


        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TwoPlayers twoPlayers = new TwoPlayers();
            twoPlayers.Show();
            this.Close();

        }


        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Trivia trivia = new Trivia();
            trivia.Show();
            this.Close();

        }
    }
}
