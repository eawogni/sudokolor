using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sudoku.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        private MusicP mP = new MusicP();
        public Settings()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Action qui se passe lorsqu'on change de page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Courbes_BackRequested;
        }
        /// <summary>
        /// Fonction qui active le bouton de retour en arrière
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Courbes_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;
            // Navigate back if possible, and if the event has not
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                Frame.Navigate(typeof(MainPage), mP);
                //rootFrame.GoBack();
            }
        }
        /// <summary>
        /// Ca gère l'élément switch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

       private async void SetMusic_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    mP.Val = "Y";
                }
                else
                {
                    mP.Val = "N";
                }
            }
            var dialog = new MessageDialog("The current settings will be changed when return to main page");
            await dialog.ShowAsync();
        }

       
    }
}
