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

namespace AGAST2.GameUI
{
    /// <summary>
    /// Interaction logic for Trivia.xaml
    /// </summary>
    public partial class Trivia : Window
    {
        private Factory factory = new Factory();
        private List<String> options;
        private int score1;

        public Trivia(int score1, int none)
        {

            InitializeComponent();
            this.score1 = score1;
            none = 0;
            this.Run();


        }

        public Question Run()
        {
            Question question = factory.GetQuestion();
            options = question.Options;

            btn1.Content = options[0];
            btn2.Content = options[1];
            btn3.Content = options[2];
            btn4.Content = options[3];
            Dispatcher.BeginInvoke(new Action(() =>
            {

                Title.Content = question.AsString();

            }));

            return question;
        }

       

        private void Label_Score(object sender, RoutedEventArgs e)
        {
            //Get label.
            var label = sender as Label;
            //Set content.
            label.Content = "Score:   " + this.score1;
        }

       
        private void Btn_click_One(object sender, RoutedEventArgs e)
        {
            if (btn1.Content.Equals("a"))
            {
                this.score1 = this.score1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    score.Content = "Score:   " + this.score1;
                }));
                btn1.Background = Brushes.Green;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Correct Answer!";
                }));
                //Next_Question(btn1);

            }
            else
            {
                
                btn1.Background = Brushes.Red;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Wrong Answer!";
                }));
                //Next_Question(btn1);
            }

        }

        private void Btn_click_Two(object sender, RoutedEventArgs e)
        {
            if (this.Run().CheckIfCorrect(btn2.Content.ToString()))
            {
                this.score1 = this.score1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    score.Content = "Score:   " + this.score1;
                }));
                btn1.Background = Brushes.Green;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Correct Answer!";
                }));
               // Next_Question(btn1);
            }
            else
            {
                btn1.Background = Brushes.Red;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Wrong Answer!";
                }));
                //Next_Question(btn1);
            }

        }

        private void Btn_click_Three(object sender, RoutedEventArgs e)
        {
            if (btn3.Content.Equals(q.CorrectOption))
            {
                this.score1 = this.score1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    score.Content = "Score:   " + this.score1;
                }));
                btn1.Background = Brushes.Green;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Correct Answer!";
                }));
               // Next_Question(btn1);
            }
            else
            {
                btn1.Background = Brushes.Red;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Wrong Answer!";
                }));
                Next_Question(btn1);
            }

        }

        private void Btn_click_Four(object sender, RoutedEventArgs e)
        {
            if (btn4.Content.Equals(q.CorrectOption))
            {
                this.score1 = this.score1 + 1;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    score.Content = "Score:   " + this.score1;
                }));
                btn1.Background = Brushes.Green;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Correct Answer!";
                }));
               // Next_Question(btn1);
            }
            else
            {
                btn1.Background = Brushes.Red;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Title.Content = "Wrong Answer!";
                }));
                //Next_Question(btn1);
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
