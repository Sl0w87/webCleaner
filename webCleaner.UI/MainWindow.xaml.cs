﻿using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using webCleaner.Services;
using webCleaner.ViewModels;
using MenuItem = webCleaner.ViewModels.MenuItem;

namespace webCleaner.UI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.Navigation.Frame = new Frame() { NavigationUIVisibility = NavigationUIVisibility.Hidden };
            Navigation.Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;
         
            // Navigate to the home page.
            this.Loaded += (sender, args) => Navigation.Navigation.Navigate(new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.Content;
            this.HamburgerMenuControl.SelectedItem = e.ExtraData ?? ((ShellViewModel)this.DataContext).GetItem(e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = e.ExtraData ?? ((ShellViewModel)this.DataContext).GetOptionsItem(e.Uri);
            GoBackButton.Visibility = Navigation.Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.GoBack();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            var menuItem = e.InvokedItem as MenuItem;
            if (menuItem != null && menuItem.IsNavigation)
            {
                Navigation.Navigation.Navigate(menuItem.NavigationDestination, menuItem);
            }
        }
    }
}
