
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Calligraphy;

namespace TestApp
{
	[Activity(Theme = "@android:style/Theme.NoTitleBar")]
	public class LogIn : Activity
	{
		
        Button logInButton;
		FontSet fontSet;
		ViewGroup viewGroup_main;
          protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LogIn);
			viewsFinder();
			eventHandlers();
			fontSet = new FontSet(this);
			fontSet.loopLayout(viewGroup_main);

		}
		//find views
		public void viewsFinder() { 
			viewGroup_main = FindViewById<ViewGroup>(Resource.Id.linearLayoutpage);
			logInButton = FindViewById<Button>(Resource.Id.button1);
		}
		//event handlers
		public void eventHandlers() { 
			logInButton.Click += LogInButton_Click;
		}
          //button click handler-->popup
        void LogInButton_Click(object sender, EventArgs e)
        {
			photosPopUp popUp = new photosPopUp(this);
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
            popUp.Show(transaction, "popup");

        }

	}
}