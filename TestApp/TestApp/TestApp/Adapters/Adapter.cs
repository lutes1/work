using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace TestApp
{
	public class Adapter : BaseAdapter
	{
		string[] items;
		Context mContext;
		 
		public Adapter(Context context, string[] items )
		{
			this.items = items;
			mContext = context;
		}

		public override int Count
		{
			get
			{
				return items.Length;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return items[position];
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null)
			{
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.rowLayout, null, false);
			}

			ImageView images = row.FindViewById<ImageView>(Resource.Id.image);
			ImageView images1 = row.FindViewById<ImageView>(Resource.Id.image2);
			var path = Android.Net.Uri.Parse(items[position]);
			Console.WriteLine(position);
			if (position % 2 == 1)
			{
				images.SetImageURI(path);
			}
			else if (position % 2 == 0)
			{
				images1.SetImageURI(path);
			}
			return row;
		}
	}
}

