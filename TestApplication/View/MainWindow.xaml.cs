using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestApplication.ViewModel;

namespace TestApplication.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllNomenclatureView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TestApplicationVM();
            AllNomenclatureView = ViewAllNomenclature;
        }
    }
}
