
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
		
        Button logInButton,confirmButton;
		FontSet fontSet;
		ViewGroup viewGroup_main;
		PopupWindow popupWindow;
		LayoutInflater inflater;
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
			confirmButton = FindViewById<Button>(Resource.Id.button2);
		}
		//event handlers
		public void eventHandlers() { 
			logInButton.Click += LogInButton_Click;
			confirmButton.Click += confirmButton_Click;
		}
		//button click handler-->popup
        void LogInButton_Click(object sender, EventArgs e)
        {
			photosPopUp popUp = new photosPopUp(this);
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
            popUp.Show(transaction, "popup");

        }
		void confirmButton_Click(object sender, EventArgs e)
		{ 
			inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			var view =  inflater.Inflate(Resource.Layout.Fragment,null);
			popupWindow = new PopupWindow(ViewGroup.LayoutParams.MatchParent, -1);
			popupWindow.ContentView = view;
			popupWindow.ShowAtLocation((View)sender, GravityFlags.Center,10,10);	
		
		}

	}
}