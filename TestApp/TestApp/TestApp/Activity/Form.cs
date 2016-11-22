
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestApp
{
	[Activity(Label = "Form", MainLauncher = true,Theme = "@android:style/Theme.NoTitleBar")]
	public class Form : Activity
	{
		LinearLayout root;
		FontSet fonSet;
		Adapter adapter;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.FormLayout);
			//font set
			root = FindViewById<LinearLayout>(Resource.Id.FormRoot);
			fonSet = new FontSet(this);
			fonSet.loopLayout(root);
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
			var metrics = Resources.DisplayMetrics;
			var widthInDp = metrics.WidthPixels - 20;
			var heightInDp = metrics.HeightPixels - 250;
			adapter = new Adapter(this,data,listView,widthInDp,heightInDp,root);
			listView.Adapter = adapter;

		}
	}
}

