using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TuristAppV5.Model;
using TuristAppV5.View;
using TuristAppV5.Viewmodel;

namespace TuristAppV5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadFacebookData();

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriListeGridView2.SelectedIndex == -1)
            {
                MessageDialog fejl = new MessageDialog("Vælg venligst et item", "Ups! Der skete en fejl!");
                await fejl.ShowAsync();
            }
            else
            {
                MainViewmodel.SelectedKategoriliste = (Kategoriliste) kategoriListeGridView2.SelectedItem;
                this.Frame.Navigate(typeof (SelectedKategoriliste));
            }

        }

        private async void LoadFacebookData()
        {
            try
            {
                var fb = new FacebookClient("722191401190090|zV8YHfAogIsAsGHsE8TOZWIY_0g");
                dynamic result = await fb.GetTaskAsync("visitroskilde");
                dynamic name = result["name"];
                dynamic about = result["about"];
                dynamic phone = result["phone"];
                dynamic website = result["website"];
                dynamic likes = result["likes"].ToString();

                facebookName.Text = name;
                facebookAbout.Text = about;
                facebookPhone.Text = "Telefon: " + phone;
                facebookWebsite.Text = "Hjemmeside: " + website;
                facebookLikes.Text = "Likes: " + likes;

                dynamic result1 = await fb.GetTaskAsync("visitroskilde/feed?fields=message, created_time&limit=3&offset=3");
                dynamic data = result1["data"];

                foreach (dynamic item in data)
                {
                    if (facebookMessage.Items != null)
                    {
                        facebookMessage.Items.Add(item["message"] + "\n" + DateTime.Parse(item["created_time"]));
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                string error = "N/A";
                facebookName.Text = error;
                facebookAbout.Text = error;
                facebookPhone.Text = "Telefon: " + error;
                facebookWebsite.Text = "Hjemmeside: " + error;
                facebookLikes.Text = "Likes: " + error;
                if (facebookMessage.Items != null)
                {
                    facebookMessage.Items.Add("Ingen feeds tilgængelig");
                }
            }
        }
    }
}
