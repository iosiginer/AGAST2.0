﻿using System;
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
        }       


        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            ((ViewModelTrivia)DataContext).CheckAnswer(((Button)sender).Content as string);
        }

    }
}