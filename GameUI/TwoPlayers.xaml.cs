using AGAST2.GameLogic.Factories;
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

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for TwoPlayers.xaml
    /// </summary>
    public partial class TwoPlayers : Window
    {
        private Fact f;
      
        public TwoPlayers()
        {
            InitializeComponent();
            f = Factory.GetFact();
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = f.Phrase;
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
                Correct c = new Correct("f");
                c.Show();
                this.Close();
                //player two wins
            }
            else if(e.Key == Key.S && !True.Content.Equals(f.CorrectOption))
            {
                Wrong w = new Wrong("f");
                w.Show();
                this.Close();
                //wrong - player one wins
            }
            else if(e.Key == Key.L && True.Content.Equals(f.CorrectOption))
            {
                Correct c = new Correct("f");
                c.Show();
                this.Close();
                //player one wins
            }
            else if(e.Key == Key.L && !True.Content.Equals(f.CorrectOption))
            {
                Wrong w = new Wrong("f");
                w.Show();
                this.Close();
                //wrong - player two wins
            }

        }

        private void True_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A && False.Content.Equals(f.CorrectOption))
            {
                Correct c = new Correct("f");
                c.Show();
                this.Close();
                //player two wins
            }
            else if(e.Key == Key.A && !False.Content.Equals(f.CorrectOption))
            {
                Wrong w = new Wrong("f");
                w.Show();
                this.Close();
                //wrong - player one wins
            }
            else if (e.Key == Key.K && False.Content.Equals(f.CorrectOption))
            {
                Correct c = new Correct("f");
                c.Show();
                this.Close();
                //player one wins
            }
            else if(e.Key == Key.K && !False.Content.Equals(f.CorrectOption))
            {
                Wrong w = new Wrong("f");
                w.Show();
                this.Close();
                //wrong - player two wins
            }

        }
    }
}
