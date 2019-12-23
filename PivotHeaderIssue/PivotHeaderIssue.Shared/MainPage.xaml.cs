// <copyright file="MainPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace PivotHeaderIssue
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Vssl.Samples.Framework;
    using Vssl.Samples.FrameworkInterfaces;
    using Vssl.Samples.ViewModels;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// The dispatcher facade
        /// </summary>
        private IDispatchOnUIThread dispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            this.dispatcher = new UIDispatcher();
            this.dispatcher.Initialize();

            var viewModel = new MainViewModel();
            viewModel.PropertyChanged += this.OnViewModelPropertyChanged;

            viewModel.Init();
            Task.Run(async () =>
            {
                await viewModel.InitAsync();
            });

            // This would normally be injected but for brevity
            this.DataContext = viewModel;

            this.Loaded += (s, e) =>
            {
                this.VM.OnViewShown();
            };
        }

        /// <summary>
        /// Gets the data context cast as the view model interface
        /// </summary>
        public MainViewModel VM
        {
            get { return this.DataContext as MainViewModel; }
        }

        /// <summary>
        /// Called when the view has been navigated to
        /// </summary>
        /// <param name="e">Any navigation parameters</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.VM.OnNavigatedTo();
        }

        /// <summary>
        /// An event handler for pivot item load
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">The event args</param>
        private void Pivot_PivotItemLoaded(Pivot sender, PivotItemEventArgs args)
        {
            if (this.VM != null)
            {
                this.item2.Header = this.VM.Pivot2Title;
            }
        }

        /// <summary>
        /// An event handler for view model property change
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Pivot2Title":
                    this.item2.Header = this.VM.Pivot2Title;
                    break;
            }
        }
    }
}
