using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using athena.AR.SVC.Library;


namespace athenaSVC.Test.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.postButtton.Click += new RoutedEventHandler(postButtton_Click);
            this.updateButton.Click += new RoutedEventHandler(updateButton_Click);
        }

        void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Common.UpdateAR(-10);
        }

        void postButtton_Click(object sender, RoutedEventArgs e)
        {
           
            Common.PostAR();
        }
    }
}
