using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace TestApp
{
	public  class FontSet
	{
		Typeface typeface;

		string path = "fonts/BebasNeueRegular.ttf";

		public FontSet(Context context ){
			typeface = Typeface.CreateFromAsset(context.Assets,path);
		}
		//Loop through GroupViews and get Views
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
						changeFont(childView2);
					}
				}
				if (childView is View)
				{
					changeFont(childView);
				}

			}
		}
		//Set Fonts
		public void changeFont(View childview)
		{

			if (childview is ViewGroup)
				loopLayout((ViewGroup)childview);

			else if (childview is TextView)
			{
				((TextView)childview).SetTypeface(typeface, TypefaceStyle.Normal);
			}
			else if (childview is Button)
			{
				((Button)childview).SetTypeface(typeface, TypefaceStyle.Normal);
			}
		}
	}
}

