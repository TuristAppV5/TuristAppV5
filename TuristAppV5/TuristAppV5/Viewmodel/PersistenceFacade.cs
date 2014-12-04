using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using TuristAppV5.Model;

namespace TuristAppV5.Viewmodel
{
    class PersistenceFacade
    {
        private static string jsonFileName = "SavedVariablesAsJson.dat";

        public static async void SaveKategorilisteAsJsonAsync(ObservableCollection<Kategoriliste> _collectionOfKategoriliste)
        {
            string kategorilisteJsonString = JsonConvert.SerializeObject(_collectionOfKategoriliste);
            SerializePersonsFileAsync(kategorilisteJsonString, jsonFileName);
        }

        public static async void SaveKommentarlisteAsJsonAsync(List<Kommentar> _kommentarListe )
        {
            string kommentarlisteJsonString = JsonConvert.SerializeObject(_kommentarListe);
            SerializePersonsFileAsync(kommentarlisteJsonString, jsonFileName);
        }

        public static async Task<ObservableCollection<Kategoriliste>> LoadKategorilisteFromJsonAsync()
        {

            string personsJsonString = await DeSerializePersonsFileAsync(jsonFileName);
            if (personsJsonString != null)
            {
                return
                    (ObservableCollection<Kategoriliste>) JsonConvert.DeserializeObject(personsJsonString, typeof(ObservableCollection<Kategoriliste>));
            }
            return null;
        }

        public static async Task<List<Kommentar>> LoadKommentarlisteFromJsonAsync()
        {
            string kommentarlisteJsonString = await DeSerializePersonsFileAsync(jsonFileName);
            if (kommentarlisteJsonString != null)
            {
                return
                    (List<Kommentar>) JsonConvert.DeserializeObject(kommentarlisteJsonString, typeof (List<Kommentar>));
            }
            return null;
        }

        public static async void SerializePersonsFileAsync(string PersonsString, string fileName)
        {
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, PersonsString);
        }

        public static async Task<string> DeSerializePersonsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
        }
    }
}
