using Android.App;
using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using System.IO;

namespace TestApp
{
     
     public class photosPopUp : DialogFragment
	{
		ViewGroup viewGroup;
		FontSet fontSet;
		TextView textView1, textView3;
		Typeface typeface;
		ListView listView;
		Adapter adapter;
		string path = "fonts/BebasNeueRegular.ttf";
		string[] files;
		Context context;
		public photosPopUp(Context context) {
			fontSet = new FontSet(context);
			this.context = context;
			typeface = Typeface.CreateFromAsset(context.Assets, path);
			}	

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
          {
           	base.OnCreateView(inflater, container, savedInstanceState);
		    var view = inflater.Inflate(Resource.Layout.Fragment,container,false);
		    viewGroup = view.FindViewById<ViewGroup>(Resource.Id.linear_layout_popup);
			textView1 = view.FindViewById<TextView>(Resource.Id.textView1);
			textView3 = view.FindViewById<TextView>(Resource.Id.textView3);
			listView = view.FindViewById<ListView>(Resource.Id.listView1);
			files = getFiles();
			adapter = new Adapter(context,files);
			listView.Adapter = adapter;
			fontSet.loopLayout(viewGroup);
			textView1.SetTypeface(typeface, TypefaceStyle.Bold);
			textView3.SetTypeface(typeface, TypefaceStyle.Bold);
			return view; 
          }
		public override void OnActivityCreated(Bundle savedInstanceState)
          {
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			Dialog.Window.RequestFeature(WindowFeatures.SwipeToDismiss);
			base.OnActivityCreated(savedInstanceState);
          }

		public string[] getFiles()
		{
			string[] files_folder = Directory.GetFiles("//storage//emulated//0//DCIM//walls");
			foreach (string file in files_folder)
			{
				Console.WriteLine(file);
			}
			return files_folder;
		}
     }
}

