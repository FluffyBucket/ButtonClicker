using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using System.Data;
//using System.Data.SqlClient;

namespace ButtonClicker
{
	[Activity (Label = "ButtonClicker", MainLauncher = true)]


	public class MainActivity : Activity
	{
		/*
			NOTES- and IDEAS-LIST:
			- How about later on making a "shop-window" with a list-layout? //Erik
			- Added a bunch of buttons. Id of buttons is as follows: "button1" and then upp to "button8".
			- Added a bunch of textview's to go along with the buttons. Id of them are as follows "textview1" to "textview6".
			NOTE! Change these buttons and texviews names to something better when they have an actual function.
			- If anyone comes up with new nice cat effects, please write them here below. //Erik

		*/


		//Global vars


		bool hasName = false;
		string username;

		Random randomCatEffectChanse = new Random();
		Random effectType = new Random();

		private Button BtnClickMe;
		private Button BtnOpenShop;
		private TextView TVClicks;
		private TextView TVCurrent;
		private TextView TVCatAmount;
		private TextView TVBananaAmount;
		private Button btnSQL;

		//DEBUG VARS
		private TextView TVCatCost;
		private TextView TVBananaCost;
		private Button BtnGiveCat;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//If logged in....

			//else
			Base.LoadValues (0, 0, 0, 10, 0, 2000);



			//LAYOUT STUFF
			BtnClickMe = FindViewById<Button> (Resource.Id.btnClick);
			BtnClickMe.Click += new EventHandler (click_Click);


			BtnOpenShop = FindViewById<Button> (Resource.Id.button5);
			BtnOpenShop.Text = "Shop";
			BtnOpenShop.Click += new EventHandler (openShop_click);

			TVClicks = FindViewById<TextView> (Resource.Id.tvClickCount);
			TVCurrent = FindViewById<TextView> (Resource.Id.tvCurrentCount);
			TVCatAmount = FindViewById<TextView> (Resource.Id.tvCatCount);
			TVBananaAmount = FindViewById<TextView> (Resource.Id.textView3);
			TVBananaCost = FindViewById<TextView> (Resource.Id.textView5);
			//DEBUG
			TVCatCost = FindViewById<TextView> (Resource.Id.textView1);
			BtnGiveCat = FindViewById<Button> (Resource.Id.button2);
			BtnGiveCat.Text = "Im a developer";
			BtnGiveCat.Click += new EventHandler (click_DebugMeCats);
			btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			btnSQL.Click += new EventHandler (btnSQL_Click);

			Update();
		}

		public void Update()
		{
			TVClicks.Text = "Total: " + Base.clicks_Total;
			TVCurrent.Text = "Current: " + Base.clicks_Current;
			TVBananaAmount.Text = "Bananans: " + Base.banana_Amount;
			TVBananaCost.Text = "Banana Price: " + Base.banana_Cost;
			TVCatCost.Text = "Cat Price: " + Base.cat_Cost;
			TVCatAmount.Text = "Cats: " + Base.cat_Amount;
		}

		private void click_DebugMeCats (object sender, EventArgs e)
		{
			Base.Debug ();
			Update ();
		}

		private void click_Click (object sender, EventArgs e)
		{
			Base.Click ();
			Update ();
		}

		private void openShop_click (object sender, EventArgs e)
		{
			var shop = new Intent(this, typeof(Shop));
	 		StartActivity(shop);
		}
			
		protected void nameEntry() {
			var factory = LayoutInflater.From (this);
			var text_entry_view = factory.Inflate (Resource.Layout.input_dialog, null);

			var builder = new AlertDialog.Builder (this);
			//builder.SetIconAttribute (Android.Resource.Attribute.DialogIcon);
			builder.SetTitle (Resource.String.strNameEntryTitle);
			builder.SetView (text_entry_view);
			builder.SetPositiveButton ("Ok", OkClicked);
			builder.Create ();
			builder.Show();

		}

		private void OkClicked (object sender, DialogClickEventArgs e)
		{
			hasName = true;

			username = GetString (Resource.String.usernameEntryText);
			Toast.MakeText (this, username, ToastLength.Long).Show ();
			//Toast toast = new Toast.MakeText (this, Resource.String.usernameEntryText.ToString, ToastLength.Long);
			//toast.Show ();
		}
		
		 //No more SQL will replace with a webservice insted
		private void btnSQL_Click (object sender, EventArgs e)
		{
			nameEntry ();

		}
	}
}


