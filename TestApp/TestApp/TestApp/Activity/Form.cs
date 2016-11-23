
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using System.Drawing;
using Android.Media;

namespace TestApp
{
	[Activity(Label = "Form" , MainLauncher = true , Theme = "@android:style/Theme.NoTitleBar")]
	public class Form : Activity
	{
		LinearLayout root;
		FontSet fonSet;
		Adapter adapter;
		static Form form;
		Bitmap bitmap;
		File image;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.FormLayout);
			form = this;
			//font set
			root = FindViewById<LinearLayout>(Resource.Id.FormRoot);
			fonSet = new FontSet(this);
			fonSet.loopLayout(root);
			Button button_clear = FindViewById<Button>(Resource.Id.button2);
			//listview create
			ListView listView = FindViewById<ListView>(Resource.Id.listView1);
			List<Data> data = new List<Data>(5);
			data.Add(new Data { type = 1, text = "one", data = null });
			data.Add(new Data { type = 2, text = "two", data = null });
			data.Add(new Data { type = 3, text = "three", data = null });
			data.Add(new Data { type = 4, text = "four", data = null });
			data.Add(new Data { type = 3, text = "five", data = null });
			data.Add(new Data { type = 2, text = "six", data = null });
			data.Add(new Data { type = 4, text = "seven", data = null });
			data.Add(new Data { type = 3, text = "eight", data = null });
			data.Add(new Data { type = 1, text = "nine", data = null });
			data.Add(new Data { type = 4, text = "ten", data = null });
			data.Add(new Data { type = 3, text = "eleven", data = null });
			data.Add(new Data { type = 2, text = "twelve", data = null });
			data.Add(new Data { type = 4, text = "thirteen", data = null });
			data.Add(new Data { type = 3, text = "fourteen", data = null });
			data.Add(new Data { type = 1, text = "fifteen", data = null });
			data.Add(new Data { type = 3, text = "eight", data = null });
			data.Add(new Data { type = 1, text = "nine", data = null });
			data.Add(new Data { type = 4, text = "ten", data = null });
			data.Add(new Data { type = 3, text = "eleven", data = null });
			data.Add(new Data { type = 2, text = "twelve", data = null });
			data.Add(new Data { type = 4, text = "thirteen", data = null });
			data.Add(new Data { type = 3, text = "fourteen", data = null });
			data.Add(new Data { type = 1, text = "fifteen", data = null });
			var metrics = Resources.DisplayMetrics;
			var widthInDp = metrics.WidthPixels - 20;
			var heightInDp = metrics.HeightPixels - 250;
			adapter = new Adapter(this,data,listView,widthInDp,heightInDp,root,button_clear,form);
			listView.Adapter = adapter;

		}
		public void openCamera() {
			var cameraIntent = new Intent(MediaStore.ActionImageCapture);
			image = new File("//storage//emulated//0//DCIM//walls",String.Format("myPhoto_{0}.png", Guid.NewGuid()));
			cameraIntent.PutExtra(MediaStore.ExtraOutput , Android.Net.Uri.FromFile(image));
			StartActivityForResult(cameraIntent, 0);
		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			bitmap = LoadAndResizeBitmap(image.Path , 344 , 180);

			 
			using (var os = new System.IO.FileStream(image.Path, System.IO.FileMode.Open))
			{
				bitmap.Compress(Bitmap.CompressFormat.Png, 95, os);
			}

		}
		public static Bitmap LoadAndResizeBitmap(string fileName, int width, int height)
		{
			// First we get the the dimensions of the file on disk
			BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
			BitmapFactory.DecodeFile(fileName, options);

			// Next we calculate the ratio that we need to resize the image by
			// in order to fit the requested dimensions.
			int outHeight = options.OutHeight;
			int outWidth = options.OutWidth;
			int inSampleSize = 1;

			if (outHeight > height || outWidth > width)
			{
				inSampleSize = outWidth > outHeight
								   ? outHeight / height
								   : outWidth / width;
			}

			// Now we will load the image and have BitmapFactory resize it for us.
			options.InSampleSize = inSampleSize;
			options.InJustDecodeBounds = false;
			Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

			return resizedBitmap;
		}

	}
}

