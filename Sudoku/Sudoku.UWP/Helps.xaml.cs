using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class Helps : Page
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Helps()
        {
            this.InitializeComponent();
            this.contentFAQ.IsEnabled = false;
            this.contentFAQ.Header = "HELP";
            this.contentFAQ.Text = "A complete sudoku grid is an array of 9 squares out of 9, subdivided into 9 squares of 3 squares aside.";
            this.contentFAQ.Text += "\r\n";
            this.contentFAQ.Text += "Each box contains only one color (there are 8 different colors).";
            this.contentFAQ.Text += "\r\n";
            this.contentFAQ.Text += "Each line, column, and square of 3 X 3 must include these 9 differents colors.";
            this.contentFAQ.Text += "\r\n";
            this.contentFAQ.Text += "Therefore, taken alone, a line, a column or a square of 3 out of 3 can not contain several times the same color.";
            this.contentFAQ.MaxWidth = 200;
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
                rootFrame.GoBack();
            }
        }
    }
}
