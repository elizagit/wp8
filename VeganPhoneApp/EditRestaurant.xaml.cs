using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace VeganPhoneApp
{
    public partial class EditRestaurant : PhoneApplicationPage
    {
        public EditRestaurant()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                Name.Text = parameter;
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}