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

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for Correct.xaml
    /// </summary>
    public partial class Correct : Window
    {
        private int x;

        public Correct(String s)
        {
            InitializeComponent();
            if (s.Equals("f"))
            {
                x = 0;
            }
            else if (s.Equals("q"))
            {
                x = 1;
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if(x == 0)
            {
                TwoPlayers Players = new TwoPlayers();
                Players.Show();
                this.Close();

            }
            if(x == 1)
            {
                Trivia t = new Trivia();
                t.Show();
                this.Close();
            }
        }
    }
}
