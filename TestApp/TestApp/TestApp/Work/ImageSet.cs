using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace TestApp
{
	public class ImageSet
	{
		private string[] items;
		int postion = 0,deletePosition = 0;
		string[] selected = new string[16];
		Context context;
		ImageView iv;
		public ImageSet(string[] items,Context context)
		{
			this.context = context;
			this.items = items;
		}
		public void loopLayout(ViewGroup viewGroup)
		{

			for (int i = 0; i < viewGroup.ChildCount; i++)
			{
				var childView = viewGroup.GetChildAt(i);

				if (childView is ViewGroup)
				{
					for (int j = 0; j < ((ViewGroup)childView).ChildCount; j++)
					{
						var childView2 = ((ViewGroup)childView).GetChildAt(j);
						setImageSRC(childView2);
					}
				}
			
			}
		}
		public void setImageSRC(View childview)
		{

			if (childview is ViewGroup)
				loopLayout((ViewGroup)childview);

			if (childview is ImageView)
			{
				if (postion < items.Length)
				{
					Console.WriteLine(items[postion]);
					var path = Android.Net.Uri.Parse(items[postion]);
					((ImageView)childview).SetImageURI(path);
					((ImageView)childview).Tag = path;
					((ImageView)childview).Alpha = 1;
					Console.WriteLine(((ImageView)childview).Width + "<----Width" + ((ImageView)childview).Height+ "<-------Height" );
					Console.WriteLine("Position: " + postion + " Tag: " + ((ImageView)childview).Tag);
					}
				else {
					((ImageView)childview).SetImageResource(0);
				}
				postion++;
				((ImageView)childview).LongClick += Handle_LongClick;	
				
			}

		}
		//handle long click!
		void Handle_LongClick(object sender, View.LongClickEventArgs e)
		{
			selected[deletePosition] = ((ImageView)sender).Tag.ToString();
			((ImageView)sender).Alpha = 0.5F;
			iv = new ImageView(context);
			iv.SetImageResource(Resource.Drawable.oneSelected);
			float x = ((ImageView)sender).GetX();
			float y = ((ImageView)sender).GetY();
			iv.ScaleX = 0.7F;
			iv.ScaleY = 0.7F;
			iv.SetX(x + 280);
			iv.SetY(y + 120);
			((ViewGroup)((ImageView)sender).Parent).AddView(iv);
			deletePosition++;

			foreach (string selecteD in selected) {
				Console.WriteLine(selecteD);
			}
		}
		//get string
		public string[] getDeleted() {
			return selected;
		}

	}
}

