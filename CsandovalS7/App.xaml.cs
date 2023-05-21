﻿using CsandovalS7.Vistas;
using SQLitePCL;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CsandovalS7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Vistas.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
