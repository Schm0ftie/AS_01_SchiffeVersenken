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

using SchiffeVersenken.Logic;

namespace SchiffeVersenken_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogicHandler _Game;
        
        public MainWindow()
        {
            _Game = new LogicHandler();
            

            InitializeComponent();
            Map.ItemsSource = _Game.GetMap().ToList();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
