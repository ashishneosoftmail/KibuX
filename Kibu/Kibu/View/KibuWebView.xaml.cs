using Acr.UserDialogs;
using Kibu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kibu.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KibuWebView : ContentPage
    {
        public KibuWebView()
        {
            InitializeComponent();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                kibuWeb.Source = WebUrl.baseUrl;
                kibuWeb.Navigated += KibuWeb_Navigated;
                kibuWeb.Navigating += KibuWeb_Navigating;
            }
            else
                DisplayAlert("Kibu", "Check your internet connection", "OK");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                kibuWeb.Source = WebUrl.baseUrl;
                kibuWeb.Navigated += KibuWeb_Navigated;
                kibuWeb.Navigating += KibuWeb_Navigating;
            }
        }

        private void KibuWeb_Navigating(object sender, WebNavigatingEventArgs e)
        {
            UserDialogs.Instance.ShowLoading();
        }

        private void KibuWeb_Navigated(object sender, WebNavigatedEventArgs e)
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}