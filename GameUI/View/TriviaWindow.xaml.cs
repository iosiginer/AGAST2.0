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
using AGAST2.Infrastructure.LevelTypes;
using GameUI.ViewModel;

namespace AGAST2.GameUI
{
    /// <summary>
    /// Interaction logic for Trivia.xaml
    /// </summary>
    public partial class TriviaWindow : Window
    {
        public TriviaWindow()
        {
            InitializeComponent();
            var vm = new ViewModelTrivia();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }       


        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void SubmitAnswer(object sender, RoutedEventArgs e)
        {
            bool success = ((ViewModelTrivia)DataContext).SubmitAnswer(((Button)sender).Content as string);
            if (!success)
                this.Back(sender, e);
        }

    }
}
