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
using AGAST2.GameLogic.Factories;
using AGAST2.Infrastructure.LevelTypes;

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for Trivia.xaml
    /// </summary>
    public partial class Trivia :Window
    {
        private Question q;
        private List<string> options;

        public Trivia()
        {
            InitializeComponent();
            q = Factory.GetQuestion();
            
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = q.AsString();
            options = q.Options;
        }

        private void Btn_click_One(object sender, RoutedEventArgs e)
        {
           if(btn1.Content.Equals("a"))
            {
                Correct c = new Correct("q");
                c.Show();
                this.Close();

            }
            else
            {
                Wrong w = new Wrong("q");
                w.Show();
                this.Close();
            }

        }

        private void Btn_click_Two(object sender, RoutedEventArgs e)
        {
            if (btn2.Content.Equals(q.CorrectOption))
            {
                Correct c = new Correct("q");
                c.Show();
                this.Close();
            }
            else
            {
                Wrong w = new Wrong("q");
                w.Show();
                this.Close();
            }

        }

        private void Btn_click_Three(object sender, RoutedEventArgs e)
        {
            if (btn3.Content.Equals(q.CorrectOption))
            {
                Correct c = new Correct("q");
                c.Show();
                this.Close();
            }
            else
            {
                Wrong w = new Wrong("q");
                w.Show();
                this.Close();
            }

        }

        private void Btn_click_Four(object sender, RoutedEventArgs e)
        {
            if (btn4.Content.Equals(q.CorrectOption))
            {
                Correct c = new Correct("q");
                c.Show();
                this.Close();
            }
            else
            {
                Wrong w = new Wrong("q");
                w.Show();
                this.Close();
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

    }
}
