
using System;
using System.Collections.Generic;
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
		Typeface typeface;
          Button bigButton;


          protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LogIn);

			TextView textview1 = FindViewById<TextView>(Resource.Id.textView1);
			string path = "fonts/BebasNeueRegular.ttf";
			typeface = Typeface.CreateFromAsset(Assets, path);
               
               var viewGroup = FindViewById<LinearLayout>(Resource.Id.linearLayoutpage);
			loopLayout(viewGroup);
               
		}

		public void loopLayout(ViewGroup viewGroup) {

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
                    if(childView is View)
                    {
                         changeFont(childView);
                    }

			}
		}
		public void changeFont(View childview) {

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