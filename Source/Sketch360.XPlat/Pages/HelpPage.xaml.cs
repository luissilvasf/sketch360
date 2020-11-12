﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using Microsoft.AppCenter.Analytics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sketch360.XPlat.Pages
{
    /// <summary>
    /// Help page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpPage"/> class.
        /// </summary>
        public HelpPage()
        {
            InitializeComponent();

            var source = new UrlWebViewSource
            {
                Url = DependencyService.Get<IBaseUrl>().GetBase() + "about.html"
            };

            WebView.Source = source;
            WebView.Navigating += WebView_Navigating;
        }

        protected override void OnAppearing()
        {
            Analytics.TrackEvent("Help page");

            base.OnAppearing();
        }

        private async void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("file://", System.StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            await Launcher.OpenAsync(new System.Uri(e.Url)).ConfigureAwait(false);

            e.Cancel = true;
        }
    }
}