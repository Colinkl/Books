﻿using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        BooksViewModel viewModel;
        public BooksPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new BooksViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           viewModel.OnAppearing();
        }
    }
}