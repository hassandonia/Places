﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Places.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlacesView : ContentPage
	{
		public PlacesView ()
		{
			InitializeComponent ();
		}
	}
}