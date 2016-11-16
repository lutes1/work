using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Android.Content;
using System.Timers;
using Android.Views.Animations;

namespace TestApp
{
	[Activity( Icon = "@mipmap/icon", Theme="@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		ImageView imageview_loading;
		Timer timer;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Loading);
			imageview_loading = FindViewById<ImageView>(Resource.Id.loading);
			Animation anim = AnimationUtils.LoadAnimation(ApplicationContext,Resource.Animation.rotate);
			imageview_loading.StartAnimation(anim);

			timer = new Timer();
				timer.Interval = 4500;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
				timer.Start();



		}
		protected void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer.Stop();
			var intent = new Intent(this, typeof(LogIn));
			StartActivity(intent);
			Finish();
		}
	}
}

