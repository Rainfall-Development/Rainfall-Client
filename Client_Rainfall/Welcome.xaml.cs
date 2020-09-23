using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Client_Rainfall
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            if(Agreement.IsChecked == true)
            {
                Client client = new Client();
                client.Show();
                Hide();
            }
            else
            {
                 MessageBoxResult result= MessageBox.Show("You must agree with the Terms of Service before continuing. If not, the application will now exit.", "Terms of Service agreement", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                switch(result)
                {
                    case MessageBoxResult.OK:                        
                        break;
                    case MessageBoxResult.Cancel:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
