using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestApplication.Model;
using TestApplication.View;

namespace TestApplication.ViewModel
{
    public class TestApplicationVM : INotifyPropertyChanged
    {
        //Свойства для номенклатуры
        public static int Id { get; set; } 
        public static string Name { get; set; }
        public static decimal Price { get; set; }
        public static DateTime FromDate { get; set; }
        public static DateTime ToDate { get; set; }

        //Выбранная номенклатура
        public static Nomenclature SelectedNomenclature { get; set; }

        #region Получение данных
        private List<Nomenclature> allNomenclature = DataWorker.Sel_nomenclature();
        public List<Nomenclature> AllNomenclature
        {
            get { return allNomenclature; }
            set
            {
                allNomenclature = value;
                NotifyPropertyChanged("AllNomenclature");
            }
        }
        private List<User> allUsers = DataWorker.Sel_users();
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
        #endregion

        #region Методы открытия окон
        //Добавление
        private void OpenAddNomenclatureWindowMethod()
        {
            AddNomenclatureWindow addNomenclatureWindow = new AddNomenclatureWindow();
            SetCenterPositionAndOpen(addNomenclatureWindow);
        }
        //Изменение
        private void OpenEditNomenclatureWindowMethod(Nomenclature nomenclature)
        {
            EditNomenclatureWindow editNomenclatureWindow = new EditNomenclatureWindow(nomenclature);
            SetCenterPositionAndOpen(editNomenclatureWindow);
        }
        //Открытие программы после авторизации

        #endregion

        #region Комманды для открытия окон
        //Создание номенклатуры
        private RelayCommand openAddNomenclatureWindow;
        public RelayCommand OpenAddNomenclatureWindow
        {
            get
            {
                return openAddNomenclatureWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNomenclatureWindowMethod();
                }
                );
            }
        }
        //Редактирование номенклатуры
        private RelayCommand openEditNomenclatureWindow;
        public RelayCommand OpenEditNomenclatureWindow
        {
            get
            {
                return openEditNomenclatureWindow ?? new RelayCommand(obj =>
                {
                    if (SelectedNomenclature != null)
                    {
                        OpenEditNomenclatureWindowMethod(SelectedNomenclature);
                    }
                    else ShowMessage("Ничего не выбрано");
                }
                    );
            }
        }

        #endregion

        #region Добавление номенклатуры
        private RelayCommand addNomenclature;
        public RelayCommand AddNomenclature
        {
            get
            {
                return addNomenclature ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (Name == null || Name.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (Price == 0)
                    {
                        SetRedBlockControll(wnd, "PriceBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.IUD_nomenclature('I', Id, Name, Price, FromDate, ToDate);
                        UpdateNomenclatureView();

                        ShowMessage(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        #endregion

        #region Редактирование номенклатуры
        private RelayCommand editNomenclature;
        public RelayCommand EditNomenclature
        {
            get
            {
                return editNomenclature ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Не выбрана номенклатура";

                    if (SelectedNomenclature != null)
                    {
                        if (Name == null || Name.Replace(" ", "").Length == 0)
                        {
                            SetRedBlockControll(wnd, "NameBlock");
                        }
                        if (Price == 0)
                        {
                            SetRedBlockControll(wnd, "PriceBlock");
                        }
                        else
                        {
                            resultStr = DataWorker.IUD_nomenclature('U', Id, Name, Price, FromDate, ToDate);
                            UpdateNomenclatureView();

                            ShowMessage(resultStr);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                    }
                    else ShowMessage(resultStr);
                }
                );
            }
        }
        #endregion

        #region Удаление номенклатуры
                private RelayCommand deleteNomenclature;
                public RelayCommand DeleteNomenclature
                {
                    get
                    {
                        return deleteNomenclature ?? new RelayCommand(obj =>
                        {
                            string resultStr = "Ничего не выбрано";
                            //если сотрудник
                            if (SelectedNomenclature != null)
                            {
                                MessageBoxResult result = MessageBox.Show("Вы уверены?", "Удаление номенклатуры", MessageBoxButton.YesNo);
                                switch (result)
                                {
                                    case MessageBoxResult.Yes:
                                resultStr = DataWorker.IUD_nomenclature('D', SelectedNomenclature.Nomenclature_Id, SelectedNomenclature.Name, SelectedNomenclature.Price, SelectedNomenclature.FromDate, SelectedNomenclature.ToDate);
                                        break;
                                    case MessageBoxResult.No:
                                        break;
                                }
                                UpdateNomenclatureView();
                            }
                            else ShowMessage(resultStr);
                            SetNullValuesToProperties();
                        }
                            );
                    }
                }
                #endregion

        //Сброс значений
        private void SetNullValuesToProperties()
        {
            Id = 0;
            Name = null;
            Price = 0;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
        }

        //Обновление списка номенклатур
        private void UpdateNomenclatureView()
        {
            AllNomenclature = DataWorker.Sel_nomenclature();
            MainWindow.AllNomenclatureView.ItemsSource = null;
            MainWindow.AllNomenclatureView.Items.Clear();
            MainWindow.AllNomenclatureView.ItemsSource = AllNomenclature;
            MainWindow.AllNomenclatureView.Items.Refresh();
        }

        //Выделение поля при ошибке
        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        //Открытие модальных окон
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        //Сообщение пользователю
        private void ShowMessage(string message)
        {
            MessageWindow messageView = new MessageWindow(message);
            SetCenterPositionAndOpen(messageView);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
