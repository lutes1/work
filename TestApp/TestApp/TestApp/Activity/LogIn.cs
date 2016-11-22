
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
	[Activity(Theme = "@android:style/Theme.NoTitleBar")]
	public class LogIn : Activity
	{
		
        Button logInButton,confirmButton;
		FontSet fontSet;
		ViewGroup viewGroup_main,linear_layout,relativeLayout1;
		PopupWindow popupWindow;
		LayoutInflater inflater;
		ImageView next, back,delete_file;
		ImageSet imageset;
		string[] files,deletedFiles;
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

			if (files.Length % 8 != 0) pages = files.Length / 8;
			else pages = files.Length / 8 - 1;
		}
		//find views
		public void viewsFinder() { 
			viewGroup_main = FindViewById<ViewGroup>(Resource.Id.linearLayoutpage);
			logInButton = FindViewById<Button>(Resource.Id.button1);
			confirmButton = FindViewById<Button>(Resource.Id.button2);
			}
		//event handlers
		public void eventHandlers() { 
			
			confirmButton.Click += confirmButton_Click;
		}
		//button click handler-->popup
       void next_Click(object sender, EventArgs e)
		{
			
			if (Clicks < pages)
			{   
				Clicks++;
				string[] files_folder = getFilesOnClick(Clicks);
				imageset = new ImageSet(files_folder,this);
				imageset.loopLayout(linear_layout);
			}
		}
		void back_Click(object sender, EventArgs e)
		{
			if (Clicks > 0)
		    {
				Clicks--;
				string[] files_folder = getFilesOnClick(Clicks);
				imageset = new ImageSet(files_folder,this);
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
			imageset = new ImageSet(files,this);
			linear_layout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout3); 
			imageset.loopLayout(linear_layout);
			next = view.FindViewById<ImageView>(Resource.Id.rightArrow);
			back = view.FindViewById<ImageView>(Resource.Id.leftArrow);
			delete_file = view.FindViewById<ImageView>(Resource.Id.imageView1);
			relativeLayout1 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
			FontSet fontset = new FontSet(this);
			fontset.loopLayout(relativeLayout1);
			next.Click += next_Click;
			back.Click += back_Click;
			delete_file.Click += Delete_File_Click;
			popupWindow = new PopupWindow(widthInDp,heightInDp);
			popupWindow.ContentView = view;
			popupWindow.OutsideTouchable = true;
			popupWindow.Focusable = true;
			ColorDrawable dw = new ColorDrawable(Color.ParseColor("#000000"));
			popupWindow.SetBackgroundDrawable(dw);
			popupWindow.ShowAtLocation((View)sender, GravityFlags.Center,0,10);	

		}

		void Delete_File_Click(object sender, EventArgs e)
		{
			deletedFiles = imageset.getDeleted();
			foreach (string deleted in deletedFiles) {
				Console.WriteLine(deleted);
				if (deleted != null)
				File.Delete(deleted);
			}
			string[] files_folder = getFilesOnClick(Clicks);
			imageset = new ImageSet(files_folder,this);
			imageset.loopLayout(linear_layout);
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