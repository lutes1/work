using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Android.Content;
using System.Timers;
using Android.Views.Animations;

namespace TestApp
{
	[Activity(MainLauncher = true, Icon = "@mipmap/icon", Theme="@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		ImageView imageview_loading;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Loading);
			imageview_loading = FindViewById<ImageView>(Resource.Id.loading);
			Animation anim = AnimationUtils.LoadAnimation(ApplicationContext,Resource.Animation.rotate);
			imageview_loading.StartAnimation(anim);
			var intent = new Intent(this, typeof(LogIn));
			StartActivity(intent);

		}
	}
}

