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
	public class openPopUp
	{
		string[] files, deletedFiles;
		ImageSet imageset;
		LinearLayout linear_layout;
		int widthInDp, heightInDp;
		int Clicks;
		int pages;
		LayoutInflater inflater;
		PopupWindow popupWindow;
		Context mContext;
		LinearLayout root;

		public openPopUp(Context context,int widthInDp, int heightInDp,LinearLayout root)
		{
			this.root = root;
			mContext = context;
			this.widthInDp = widthInDp;
			this.heightInDp = heightInDp;
			files = getFiles();
			if (files.Length % 8 != 0) pages = files.Length / 8;
			else pages = files.Length / 8 - 1;


		}

		public void open(Button button) { 

			Console.WriteLine("Width: " + widthInDp + " Height: " + heightInDp);
			inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			var view = inflater.Inflate(Resource.Layout.Fragment, null);
			linear_layout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout3);
			ImageView imageview1 = view.FindViewById<ImageView>(Resource.Id.imageView4);
			files = getFiles();
			imageset = new ImageSet(files, mContext);
			linear_layout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout3);
			imageset.loopLayout(linear_layout);
			ImageView next = view.FindViewById<ImageView>(Resource.Id.rightArrow);
			ImageView back = view.FindViewById<ImageView>(Resource.Id.leftArrow);
			ImageView delete_file = view.FindViewById<ImageView>(Resource.Id.imageView1);
			RelativeLayout relativeLayout1 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
			FontSet fontset = new FontSet(mContext);
			fontset.loopLayout(relativeLayout1);
			next.Click += next_Click;
			back.Click += back_Click;
			delete_file.Click += Delete_File_Click;
			popupWindow = new PopupWindow(widthInDp, heightInDp);
			popupWindow.ContentView = view;
			popupWindow.OutsideTouchable = true;
			popupWindow.Focusable = true;
			ColorDrawable dw = new ColorDrawable(Color.ParseColor("#000000"));
			popupWindow.SetBackgroundDrawable(dw);
			popupWindow.ShowAtLocation((View)button, GravityFlags.Center, 0, 10);
			root.Alpha = 0.3F;
			popupWindow.DismissEvent += delegate
			{
				root.Alpha = 1;
			};
		}
		public string[] getFilesOnClick(int clicks)
		{
			string[] files_folder = Directory.GetFiles("//storage//emulated//0//DCIM//walls");
			int start = clicks * 8;
			int finish, k = 0, particul_size;
			if ((files_folder.Length % 8 != 0) && ((files_folder.Length - start) < 8))
				finish = start + files_folder.Length % 8;
			else finish = start + 8;
			particul_size = finish - start;
			string[] particular = new string[particul_size];
			Console.WriteLine("Lenght: " + files_folder.Length + " Start: " + start + " Finish: " + finish + " Clicks: " + clicks);
			for (int i = start; i < finish; i++)
			{
				particular[k] = files_folder[i];
				k++;
			}

			foreach (string str in files_folder)
			{
				Console.WriteLine(str);
			}
			return particular;
		}

		public string[] getFiles()
		{
			string[] files_folder = Directory.GetFiles("//storage//emulated//0//DCIM//walls");
			return files_folder;
		}

		void Delete_File_Click(object sender, EventArgs e)
		{
			
			deletedFiles = imageset.getDeleted();
			foreach (string deleted in deletedFiles)
			{
				Console.WriteLine(deleted);
				if (deleted != null)
					File.Delete(deleted);
			}
			string[] files_folder = getFilesOnClick(Clicks);
			imageset = new ImageSet(files_folder, mContext);
			imageset.loopLayout(linear_layout);
		}
		void next_Click(object sender, EventArgs e)
		{
			if (Clicks < pages)
			{
				Clicks++;
				string[] files_folder = getFilesOnClick(Clicks);
				imageset = new ImageSet(files_folder, mContext);
				imageset.loopLayout(linear_layout);
			}
		}
		void back_Click(object sender, EventArgs e)
		{
			
			if (Clicks > 0)
			{
				Clicks--;
				string[] files_folder = getFilesOnClick(Clicks);
				imageset = new ImageSet(files_folder, mContext);
				imageset.loopLayout(linear_layout);
			}

		}
	}
}

