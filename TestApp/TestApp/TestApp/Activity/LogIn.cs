
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Calligraphy;

namespace TestApp
{
	[Activity(Theme = "@android:style/Theme.NoTitleBar",MainLauncher = true)]
	public class LogIn : Activity
	{
		
        Button logInButton,confirmButton;
		FontSet fontSet;
		ViewGroup viewGroup_main,linear_layout,relativeLayout1;
		PopupWindow popupWindow;
		LayoutInflater inflater;
		ImageView next, back;
		string[] files;
		int Clicks = 0;
		int pages = 0;
          protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LogIn);
			viewsFinder();
			eventHandlers();
			fontSet = new FontSet(this);
			fontSet.loopLayout(viewGroup_main);
			files = getFiles();
			pages = files.Length / 8 - 1 ;

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
		void next_Click(object sender, EventArgs e)
		{
			
			if (Clicks < pages)
			{   
				Clicks++;
				string[] files_folder = getFilesOnClick(Clicks);
				ImageSet imageset = new ImageSet(files_folder);
				imageset.loopLayout(linear_layout);
			}
		}
		void back_Click(object sender, EventArgs e)
		{
			if (Clicks > 0)
		    {
				Clicks--;
				string[] files_folder = getFilesOnClick(Clicks);
				ImageSet imageset = new ImageSet(files_folder);
				imageset.loopLayout(linear_layout);
			}

		}
		void confirmButton_Click(object sender, EventArgs e)
		{
			Clicks = 0;
			var metrics = Resources.DisplayMetrics;
			var widthInDp = metrics.WidthPixels - 20;
			var heightInDp = metrics.HeightPixels - 250;
			Console.WriteLine("Width: " + widthInDp + " Height: " + heightInDp);
			inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			var view =  inflater.Inflate(Resource.Layout.Fragment,null);
			ImageView imageview1 = view.FindViewById<ImageView>(Resource.Id.imageView4);
			files = getFiles();
			ImageSet imageset = new ImageSet(files);
			linear_layout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout3); 
			imageset.loopLayout(linear_layout);
			next = view.FindViewById<ImageView>(Resource.Id.rightArrow);
			back = view.FindViewById<ImageView>(Resource.Id.leftArrow);
			relativeLayout1 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
			FontSet fontset = new FontSet(this);
			fontset.loopLayout(relativeLayout1);
			next.Click += next_Click;
			back.Click += back_Click;
			popupWindow = new PopupWindow(widthInDp,heightInDp);
			popupWindow.ContentView = view;
			popupWindow.OutsideTouchable = true;
			popupWindow.Focusable = true;
			ColorDrawable dw = new ColorDrawable(Color.ParseColor("#000000"));
			popupWindow.SetBackgroundDrawable(dw);
			popupWindow.ShowAtLocation((View)sender, GravityFlags.Center,0,10);	

		}
		public string[] getFilesOnClick(int clicks)
		{
			string[] files_folder = Directory.GetFiles("//storage//emulated//0//DCIM//walls");
			int start = clicks * 8; 
			int finish , k = 0,particul_size;
			if ((files_folder.Length % 8 != 0) && ((files_folder.Length - start) < 8))
				finish = start + files_folder.Length % 8;
			else finish = start + 8;
			particul_size = finish - start;
			string[] particular = new string[particul_size];
			Console.WriteLine("Lenght: " + files_folder.Length + " Start: " + start + " Finish: "+ finish + " Clicks: " + clicks);
			for (int i = start; i < finish; i++)
			{
				particular[k] = files_folder[i];
				k++;
			}

			foreach (string str in files_folder) {
				Console.WriteLine(str);
			}
			return particular;
		}

		public string[] getFiles()
		{
			string[] files_folder = Directory.GetFiles("//storage//emulated//0//DCIM//walls");
			return files_folder;
		}
	}
}