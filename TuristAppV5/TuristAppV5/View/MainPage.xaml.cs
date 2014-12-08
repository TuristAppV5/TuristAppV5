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

        private async void facebook_Click(object sender, RoutedEventArgs e)
        {

            FacebookClient fb = new FacebookClient("722191401190090|zV8YHfAogIsAsGHsE8TOZWIY_0g");

            dynamic friendsTaskResult = await fb.GetTaskAsync("/posts");
            var result = (IDictionary<string, object>)friendsTaskResult;
            var data = (IEnumerable<object>)result["data"];
            foreach (var item in data)
            {
                var message = (IDictionary<string, object>)item;

                FacebookData.Messages.Add(new VisitRoskilde { Message = (string)message["message"] });
            }

    


            //dynamic stuff = JsonConvert.DeserializeObject("{'message': 'Julen n\u00e6rmer sig, og n\u00e6ste uge i Roskilde byder p\u00e5 en masse sk\u00f8nne juleaktiviteter lige fra vikinge-julefest til nissev\u00e6rksted. I weekenden er der julemarked p\u00e5 St\u00e6ndertorvet, og Gimle inviterer b\u00f8rn og barnlige sj\u00e6le til julebanko. Der er ogs\u00e5 masser af julemusik at varme sj\u00e6len p\u00e5. H\u00f8r fx Roskilde Domkirkes pigekor synge julen ind, kom i godt hum\u00f8r med Roskilde Gospel Choir eller fang Bj\u00e6ldebanden, n\u00e5r de g\u00e5r rundt i byens gader i weekenden og spiller julejazz. \nNext week in Roskilde is all about Christmas! During the weekend, there is a Christmas Market at St\u00e6ndertovet, the city\u2019s main square, and Gimle invites children and young at heart to Christmas bingo. There are also lots of Christmas music to warm the soul.', 'id': '163262523852993_341533356025908', 'created_time': '2014-12-05T09:18:09+0000'}");
            //facebookData1.Text = stuff.message + "\n\n" + stuff.created_time;


            //string json = "{'message': 'Julen n\u00e6rmer sig, og n\u00e6ste uge i Roskilde byder p\u00e5 en masse sk\u00f8nne juleaktiviteter lige fra vikinge-julefest til nissev\u00e6rksted. I weekenden er der julemarked p\u00e5 St\u00e6ndertorvet, og Gimle inviterer b\u00f8rn og barnlige sj\u00e6le til julebanko. Der er ogs\u00e5 masser af julemusik at varme sj\u00e6len p\u00e5. H\u00f8r fx Roskilde Domkirkes pigekor synge julen ind, kom i godt hum\u00f8r med Roskilde Gospel Choir eller fang Bj\u00e6ldebanden, n\u00e5r de g\u00e5r rundt i byens gader i weekenden og spiller julejazz. \nNext week in Roskilde is all about Christmas! During the weekend, there is a Christmas Market at St\u00e6ndertovet, the city\u2019s main square, and Gimle invites children and young at heart to Christmas bingo. There are also lots of Christmas music to warm the soul.', 'id': '163262523852993_341533356025908', 'created_time': '2014-12-05T09:18:09+0000'}";
            //dynamic dynJson = JsonConvert.DeserializeObject(json);
            //foreach (var item in dynJson)
            //{

            //    //facebookData1.Text = item.message;
            //}
            //facebookData1.Text = dynJson.message;


            //var fb = new FacebookClient("CAACEdEose0cBAOQAcLf1mIalNfhhKZB2zA6DwoIVZCnIanFIyVpQYiu022h19VoetuzN0xeIPIA7qxyH1OT4SWwuubIRxey0zf173WDcVL4z7t83QdLZCAaUCPGhumZBwBJXaJYNCMnvUoqjduZAwZCAL4hcmUYly3FNfmtYuQGjUVV9WOEdw7Ne4NQpRGmPrUda65IjmFaxA6FJoKLh0a");
            //var result = await fb.GetTaskAsync("fql",
            //    new
            //    {
            //        q =
            //            "SELECT message FROM stream WHERE source_id IN (SELECT page_id FROM page WHERE name='visitroskilde') LIMIT 3"
            //    });
            //facebookData1.Text = result.ToString();


        }
    }

    public class VisitRoskilde
    {
        public string Message { get; set; }
    }

    public class FacebookData
    {
        private static ObservableCollection<VisitRoskilde> messages = new ObservableCollection<VisitRoskilde>();

        public static ObservableCollection<VisitRoskilde> Messages
        {
            get
            {
                return messages;
            }
        }
    }
}
