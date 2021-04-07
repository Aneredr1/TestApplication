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
using TestApplication.Model;
using TestApplication.ViewModel;

namespace TestApplication.View
{
    /// <summary>
    /// Логика взаимодействия для EditNomenclatureWindow.xaml
    /// </summary>
    public partial class EditNomenclatureWindow : Window
    {
        public EditNomenclatureWindow(Nomenclature nomenclatureToEdit)
        {
            InitializeComponent();
            DataContext = new TestApplicationVM();
            TestApplicationVM.SelectedNomenclature = nomenclatureToEdit;
            TestApplicationVM.Id = nomenclatureToEdit.Nomenclature_Id;
            TestApplicationVM.Name = nomenclatureToEdit.Name;
            TestApplicationVM.Price = nomenclatureToEdit.Price;
            TestApplicationVM.ToDate = nomenclatureToEdit.ToDate;
            TestApplicationVM.FromDate = nomenclatureToEdit.FromDate;
        }
    }
}
