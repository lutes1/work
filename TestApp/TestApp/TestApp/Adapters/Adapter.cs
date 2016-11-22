using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace TestApp
{
	public class Adapter : BaseAdapter<Data>
	{
		List<Data> items;
		//int elementTag = 0;
		Context mContext;
		FontSet fontset;
		ListView listView;
		LinearLayout root;
		LayoutInflater inflater,inflater2;
		int widthInDp, heightInDp;
		int checkbox_counter;
		string save_id;


		public Adapter(Context context, List<Data> items,ListView listview,int widthInDp,int heightInDp,LinearLayout root )
		{
			this.widthInDp = widthInDp;
			this.heightInDp = heightInDp - 400;
			listView = listview;
			fontset = new FontSet(context);
			this.items = items;
			mContext = context;
			this.root = root; 
		}

		public override Data this[int position]
		{
			get
			{
				return items[position];
			}
		}

		public override int Count
		{
			get
			{
				return items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = null;
			ISharedPreferences prefs = mContext.GetSharedPreferences("data", FileCreationMode.Private);
			ISharedPreferencesEditor edit = prefs.Edit();
//ROW1-----------------------------------------------------------------------------------------------------------------------------------------row1----------
			if (items[position].type == 1) {
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.row1Layout, null, false);
				Button button = row.FindViewById<Button>(Resource.Id.button1);
				TextView textview_row1 = row.FindViewById<TextView>(Resource.Id.textView1);
				button.Text = items[position].text;
				fontset.changeFont(row);
				string save_id1 = position + "_time";
				Console.WriteLine(save_id);
				textview_row1.Text = prefs.GetString("time", "N/A");
//timepicker popup
				button.Click += delegate {
					inflater = mContext.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
					var view = inflater.Inflate(Resource.Layout.TimePopUp, null);
					Console.WriteLine("Width: " + widthInDp + " Height: " + heightInDp);
					RelativeLayout linearLayout = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
					fontset.loopLayout(linearLayout);
					PopupWindow popupWindow = new PopupWindow(widthInDp, heightInDp);
					popupWindow.ContentView = view;
					popupWindow.OutsideTouchable = true;
					popupWindow.Focusable = true;
//*++++++timepicker popup dismis event
					popupWindow.DismissEvent += delegate
					{
						root.Alpha = 1;
					};
					ColorDrawable dw = new ColorDrawable(Color.ParseColor("#80000000"));
					popupWindow.SetBackgroundDrawable(dw);
					popupWindow.ShowAtLocation(button, GravityFlags.Center, 0, 10);
					Button button1 = view.FindViewById<Button>(Resource.Id.button1);
					TimePicker timePicker = view.FindViewById<TimePicker>(Resource.Id.timePicker1);
//timepicker popupclose
					button1.Click += delegate
					{
						
						textview_row1.Text = timePicker.CurrentHour + " : " + timePicker.CurrentMinute;
						string time = textview_row1.Text;
						popupWindow.Dismiss();
						edit.PutString("time", time);
						edit.Apply();
					};
					root.Alpha = 0.3F;
				};
			}
//ROW2-----------------------------------------------------------------------------------------------------------------------------------------Row2----------------
			if (items[position].type == 2 )
			{
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.row2Layout, null, false);
				fontset.changeFont(row);
				Button increment = row.FindViewById<Button>(Resource.Id.button3);
				Button decrement = row.FindViewById<Button>(Resource.Id.button4);
				TextView textview = row.FindViewById<TextView>(Resource.Id.textView2);
				TextView textview_info = row.FindViewById<TextView>(Resource.Id.textView1);
				textview_info.Text = items[position].text;
				save_id = position + "_counter";
				textview.Text = prefs.GetInt(save_id, 0);
//increment click
				increment.Click+= delegate {
					var value = Int32.Parse(textview.Text);
					value++;
					textview.Text = value.ToString();
					edit.PutInt(save_id, value);
					edit.Apply();
				};
//decrement click
				decrement.Click+= delegate {var value = Int32.Parse(textview.Text);
					value--;
					textview.Text = value.ToString();
					edit.PutInt(save_id, value);
					edit.Apply();
			};

			}
//ROW3----------------------------------------------------------------------------------------------------------------------------------------------Row3----------
			if (items[position].type == 3)
			{
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.row3Layout, null, false);
				Button ChkPopupButton = row.FindViewById<Button>(Resource.Id.button1_row3);
				ChkPopupButton.Text = items[position].text;
				fontset.changeFont(row);
				TextView result_checkbox_selected = row.FindViewById<TextView>(Resource.Id.textView_checkboxes);
				save_id = position + "_checkbox_counter";
				result_checkbox_selected.Text = prefs.GetInt(save_id, -1).ToString();

//+++++++++++++++++++++checkbox popup
				ChkPopupButton.Click+= delegate	 {inflater2 = mContext.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
					var view = inflater2.Inflate(Resource.Layout.ChkPopUp, null);
					LinearLayout linearLayout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout);
					fontset.loopLayout(linearLayout);
					PopupWindow popupWindow2 = new PopupWindow(widthInDp, heightInDp + 350);
					popupWindow2.ContentView = view;
					popupWindow2.OutsideTouchable = true;
					popupWindow2.Focusable = true;
					ColorDrawable dw = new ColorDrawable(Color.ParseColor("#80000000"));
					popupWindow2.SetBackgroundDrawable(dw);
					popupWindow2.ShowAtLocation(ChkPopupButton, GravityFlags.Center, 0, 10);
					root.Alpha = 0.3F;
					popupWindow2.DismissEvent += delegate {
						root.Alpha = 1;
					};
					Button buttonChk = view.FindViewById<Button>(Resource.Id.button1);
					checkbox_counter = 0;

					CheckBox checkbox1 = view.FindViewById<CheckBox>(Resource.Id.checkBox1);
					CheckBox checkbox2 = view.FindViewById<CheckBox>(Resource.Id.checkBox2);
					CheckBox checkbox3 = view.FindViewById<CheckBox>(Resource.Id.checkBox3);
					CheckBox checkbox4 = view.FindViewById<CheckBox>(Resource.Id.checkBox4);

					RelativeLayout relativeLayout1 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
					RelativeLayout relativeLayout2 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout2);
					RelativeLayout relativeLayout3 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout3);
					RelativeLayout relativeLayout4 = view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout4);

					bool checkbox1_get_state = prefs.GetBoolean(save_id + "checkbox1", false);
					bool checkbox2_get_state = prefs.GetBoolean(save_id + "checkbox2", false);
					bool checkbox3_get_state = prefs.GetBoolean(save_id + "checkbox3", false);
					bool checkbox4_get_state = prefs.GetBoolean(save_id + "checkbox4", false);

					if (checkbox1_get_state)
					{
						checkbox1.Checked = true;
						checkbox_counter++;
						relativeLayout1.SetBackgroundColor(Color.ParseColor("#951994bc"));
					}

					if (checkbox2_get_state)
					{
						checkbox2.Checked = true;
						checkbox_counter++;
						relativeLayout2.SetBackgroundColor(Color.ParseColor("#951994bc"));
					}
					if (checkbox3_get_state)
					{
						checkbox3.Checked = true;
						checkbox_counter++;
						relativeLayout3.SetBackgroundColor(Color.ParseColor("#951994bc"));
					}
					if (checkbox4_get_state)
					{
						checkbox4.Checked = true;
						checkbox_counter++;
						relativeLayout4.SetBackgroundColor(Color.ParseColor("#951994bc"));
					}
					checkbox1.Click += Checkbox_Click;
					checkbox2.Click += Checkbox_Click;
					checkbox3.Click += Checkbox_Click;
					checkbox4.Click += Checkbox_Click;
//+++++++++++++++++++++checkbox popup close
					buttonChk.Click += delegate
					{
						popupWindow2.Dismiss();
						result_checkbox_selected.Text = checkbox_counter.ToString();

						edit.PutBoolean(save_id + "checkbox1", checkbox1.Checked);
						edit.PutBoolean(save_id + "checkbox2", checkbox2.Checked);
						edit.PutBoolean(save_id + "checkbox3", checkbox3.Checked);
						edit.PutBoolean(save_id + "checkbox4", checkbox4.Checked);
						edit.PutInt(save_id , checkbox_counter);
						edit.Apply();
					};
					
			};
			}
//ROW4--------------------------------------------------------------------------------------------------------------------------------------------------row4------------
			if (items[position].type == 4)
			{
				row = LayoutInflater.From(mContext).Inflate(Resource.Layout.row4Layout, null, false);
				Button button = row.FindViewById<Button>(Resource.Id.button1_row4);
				button.Text = items[position].text;
				fontset.changeFont(row);
			}
			
			return row;
		}
//-------------ADITIONAL------------------------------------------------------------------------------------------------------------------------------ADITIONAL-------
void Checkbox_Click(object sender, EventArgs e)
		{
			if (((CheckBox)sender).Checked)
			{	checkbox_counter++;
				((RelativeLayout)((CheckBox)sender).Parent).SetBackgroundColor(Color.ParseColor("#951994bc"));
				((CheckBox)sender).SetBackgroundResource(Resource.Drawable.check);
			}
			else {
				checkbox_counter--;
				((RelativeLayout)((CheckBox)sender).Parent).SetBackgroundColor(Color.ParseColor("#500b415b"));
				((CheckBox)sender).SetBackgroundResource(Resource.Drawable.checkbox_normal);
			}
		}

	}
}

