﻿using AGAST2.Infrastructure.LevelTypes;
using GameUI.View;
using GameUI.ViewModel;
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
        }

        private void TwoPlayersButton_Click(object sender, RoutedEventArgs e)
        {
            Window factsWindow = new FactsWindow { DataContext = new ViewModelFacts() };
            factsWindow.Show();
            this.Close();
        }


        private void Trivia_Click(object sender, RoutedEventArgs e)
        {
            Window triviaWindow = new TriviaWindow { DataContext = new ViewModelTrivia() };
            triviaWindow.Show();
            this.Close();
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            HowToPlay instructionsWindow = new HowToPlay();
            instructionsWindow.Show();
            this.Close();
        }
    }
}
