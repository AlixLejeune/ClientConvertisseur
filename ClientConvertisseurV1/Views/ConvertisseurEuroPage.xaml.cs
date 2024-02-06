using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Devise> lesDevises;
        public ObservableCollection<Devise> LesDevises { get { return lesDevises; } set { lesDevises = value; OnPropertyChanged(); } }
        private double tbEuros;
        private double tbConvert;
        public double TbEuros { get { return tbEuros; } set { tbEuros = value; OnPropertyChanged(); } }
        public double TbConvert { get { return tbConvert; } set { tbConvert = value; OnPropertyChanged(); } }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ShowDialog(string title, string message)
        {
            ContentDialog box = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };
            box.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult res = await box.ShowAsync();
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7281/api/");
            List<Devise> result =  await service.GetDevisesAsync("Devises");
            if (result == null)
            {
                ShowDialog("Erreur", "API non disponible");
            }
            else
                lesDevises = new ObservableCollection<Devise>(result);
           
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button_Click_Convert(object sender, RoutedEventArgs e)
        {
            if(cbDevises.SelectedItem == null)
            {
                ShowDialog("Erreur", "Devise non sélectionnée");
            }
            else
            {
                TbConvert = TbEuros * ((Devise)cbDevises.SelectedItem).Taux;
            }
        }
    }
}
