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
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriListeGridView.SelectedIndex == -1)
            {
                MessageDialog telefonfejl = new MessageDialog("Vælg venligst et item", "Ups! Der skete en fejl!");
                await telefonfejl.ShowAsync();
            }
            else
            {
                this.Frame.Navigate(typeof (SelectedKategoriliste));
            }

        }
        //public class MyFriends
        //{
        //    public long uid { get; set; }            
        //    public string message { get; set; }
        //}

        private async void facebook_Click(object sender, RoutedEventArgs e)
        {
            //string json = "https://graph.facebook.com/visitroskilde/posts?limit=3&access_token=722191401190090|zV8YHfAogIsAsGHsE8TOZWIY_0g";
            //dynamic dynJson = JsonConvert.DeserializeObject(json);
            //foreach (var item in dynJson)
            //{
            //    Debug.WriteLine("{0}", item.message);
            //}


            var fb = new FacebookClient("CAACEdEose0cBAOQAcLf1mIalNfhhKZB2zA6DwoIVZCnIanFIyVpQYiu022h19VoetuzN0xeIPIA7qxyH1OT4SWwuubIRxey0zf173WDcVL4z7t83QdLZCAaUCPGhumZBwBJXaJYNCMnvUoqjduZAwZCAL4hcmUYly3FNfmtYuQGjUVV9WOEdw7Ne4NQpRGmPrUda65IjmFaxA6FJoKLh0a");
            var result = await fb.GetTaskAsync("fql",
                new
                {
                    q =
                        "SELECT message FROM stream WHERE source_id IN (SELECT page_id FROM page WHERE name='visitroskilde') LIMIT 3"
                });
            facebookData1.Text = result.ToString();


            //var fb = new FacebookClient("CAACEdEose0cBABdJW0hjA0hzlU1DAHw30YQwfuSewPQrfI6V7Qgxa8pawGqgdgJDd8O7FuSh5ByLHx725mxYD07cbur1p02kLoekiApRNdKgQfxNTxmBtlqTjvqGbLWZAYPYvVOHBrZCkiFGrcWIY92JSKNGBmPihhKkC2ZCMdy6aZBvVlNYZCb5ML5GTTwPoXg9NYQ0HlkD5LAmE6GxZA");
            //var query = string.Format(@"SELECT message FROM stream WHERE source_id IN (SELECT page_id FROM page WHERE name='visitroskilde') LIMIT 3");

            //dynamic parameters = new ExpandoObject();
            //parameters.q = query;
            //dynamic results = fb.GetTaskAsync("/fql", parameters);

            //List<MyFriends> q = JsonConvert.DeserializeObject<List<MyFriends>>(results.ToString());

            //listView1.ItemsSource = q;

        }
    }
}
