using AGAST2.Infrastructure.LevelTypes;
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
    public partial class TwoPlayers : Window
    {
        private Fact f = new Fact();
        private int score_p1;
        private int score_p2;

        public TwoPlayers(int score_p1, int score_p2)
        {
            InitializeComponent();
            this.score_p1 = score_p1;
            this.score_p2 = score_p2;
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = f.Phrase;
        }

        private void Player_One(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = "Player One Score:   " + this.score_p1;
        }

        private void PlayerTwo(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = "Player Two Score:   " + this.score_p2;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void Player_Two(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void False_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && True.Content.Equals(f.CorrectOption))
            {
                this.score_p2 = this.score_p2 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player Two Score:   " + this.score_p2;
                }));
                True.Background = Brushes.Green;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    label.Content = "Correct Answer!";
                }));
            }
            else if (e.Key == Key.S && !True.Content.Equals(f.CorrectOption))
            {
                this.score_p1 = this.score_p1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p1_label.Content = "Player One Score:   " + this.score_p1;
                }));

                True.Background = Brushes.Red;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    label.Content = "Wrong Answer!";
                }));
            }


            else if (e.Key == Key.L && True.Content.Equals(f.CorrectOption))
            {
                this.score_p1 = this.score_p1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p1_label.Content = "Player One Score:   " + this.score_p1;
                }));
                
                //c
            }
            else if (e.Key == Key.L && !True.Content.Equals(f.CorrectOption))
            {
                this.score_p2 = this.score_p2 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player Two Score:   " + this.score_p2;
                }));

              //w
            }

        }

        private void True_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A && False.Content.Equals(f.CorrectOption))
            {
                this.score_p2 = this.score_p2 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player Two Score:   " + this.score_p2;
                }));

              //c
            }

            else if (e.Key == Key.A && !False.Content.Equals(f.CorrectOption))
            {
                this.score_p1 = this.score_p1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player One Score:   " + this.score_p1;
                }));

                //w
            }
            else if (e.Key == Key.K && False.Content.Equals(f.CorrectOption))
            {

                this.score_p1 = this.score_p1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player One Score:   " + this.score_p1;
                }));
                //w
            }
            else if (e.Key == Key.K && !False.Content.Equals(f.CorrectOption))
            {
                this.score_p2 = this.score_p2 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    p2_label.Content = "Player Two Score:   " + this.score_p2;
                }));

               //w
            }

        }
    }
}
