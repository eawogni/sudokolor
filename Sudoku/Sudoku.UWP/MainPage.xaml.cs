using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sudoku.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Sudokolor newGame;
        private bool exist;
        private MusicP mP = new MusicP();
        /// <summary>
        /// MainPage
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            Task<Sudokolor> varGame = DeserelizeDataFromJson("maSauvegarde");
            
        }
        

        /// <summary>
        /// Cette fonction nous permet de désérialiser via un fichier .json
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<Sudokolor> DeserelizeDataFromJson(string fileName)
        {
            exist = false;
            try
            {
                this.newGame = new Sudokolor();
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.GetFileAsync(fileName + ".json");
                var data = await file.OpenReadAsync();

                using (StreamReader r = new StreamReader(data.AsStream()))
                {
                    string text = r.ReadToEnd();
                    var jobject = JsonConvert.DeserializeObject<Sudokolor>(text);
                    if (jobject != null)
                    {
                        newGame.Matrice = jobject.Matrice;
                        exist = true;
                    }
                }
                return newGame;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Lors du clic sur le bouton Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_bt_Play(object sender, RoutedEventArgs e)
        {
            List<object> var = new List<object>();
            var.Add(mP);
            Frame.Navigate(typeof(Play),var);        
        }
        /// <summary>
        /// Lors du clic sur le bouton Setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Click_bt_Settings(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }
        /// <summary>
        /// Lors du clic sur le bouton Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Click_bt_Helps(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Helps));
        }      
        /// <summary>
        /// Fonction qui se déclanche lors du clic sur le bouton save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bt_saved_Click(object sender, RoutedEventArgs e)
        {
            if (exist != false)
            {
                List<object> var = new List<object>();
                var.Add(newGame);
                var.Add(mP);
                // Window.Current.Content = new Play(newGame);
                Frame.Navigate(typeof(Play), var);
            }
            else
            {
                var dialog = new MessageDialog("You no have backup");
                await dialog.ShowAsync();

            }
        }
        /// <summary>
        /// Action qui se passe lorsqu'on change de page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                var parameters = (MusicP)e.Parameter;
                mP.Val = parameters.Val;
                
            }           
        }
    }
}