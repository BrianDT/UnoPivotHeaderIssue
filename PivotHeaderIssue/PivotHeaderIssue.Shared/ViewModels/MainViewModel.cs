// <copyright file="MainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace Vssl.Samples.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The view model for the pivot header binding issue sample
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the title of the first pivot
        /// </summary>
        public string Pivot1Title { get; private set; }

        /// <summary>
        /// Gets the title of the second pivot
        /// </summary>
        public string Pivot2Title { get; private set; }

        /// <summary>
        /// Long running tasks that can run async prior to injection ito the view
        /// </summary>
        /// <returns>An awaitable task</returns>
        public override async Task InitAsync()
        {
            await base.InitAsync();

            this.Pivot1Title = "Freddy";
            this.Pivot2Title = "Services";
            this.OnPropertyChanged("Pivot1Title");
            this.OnPropertyChanged("Pivot2Title");
        }

        /// <summary>
        /// Called when the page is navigated to
        /// </summary>
        public void OnNavigatedTo()
        {
        }

        /// <summary>
        /// Actions that take place when the view is displayed
        /// </summary>
        public override void OnViewShown()
        {
            base.OnViewShown();
            this.OnPropertyChanged("Pivot1Title");
            this.OnPropertyChanged("Pivot2Title");
        }
    }
}
