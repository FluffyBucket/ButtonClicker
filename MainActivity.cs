using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
<<<<<<< HEAD
using System.Data;
using System.Data.SqlClient;
=======
using Android.Preferences;
//using System.Data;
//using System.Data.SqlClient;
>>>>>>> ebd6530bdc7ed7f506d078a8e04f147266ebdf93

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
		private Bundle bundle;
		private string username;

		ISharedPreferences prefs;
		ISharedPreferencesEditor editor;
		private EditText Username_input;
		private Button btnOK;

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
		private Button btnReset;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.bundle = bundle;
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

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

			BtnGiveCat = FindViewById<Button> (Resource.Id.button2);
			BtnGiveCat.Text = "Im a developer";
			BtnGiveCat.Click += new EventHandler (click_DebugMeCats);
			BtnGiveCat.Visibility = ViewStates.Gone;
			btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			btnSQL.Click += new EventHandler (btnSQL_Click);
			btnSQL.Visibility = ViewStates.Gone;
			btnReset = FindViewById<Button> (Resource.Id.btnReset);
			btnReset.Click += new EventHandler (RESET);

				prefs = PreferenceManager.GetDefaultSharedPreferences(this); 
				editor = prefs.Edit();
				/*editor.PutInt(("number_of_times_accessed", accessCount++);
					editor.PutString("date_last_accessed", DateTime.Now.ToString("yyyy-MMM-dd"));
					editor.Apply();*/

			username = prefs.GetString ("username", null);
			if (username == null) {
				Base.LoadValues (0, 0, 0, 10, 0, 2000);
				nameEntry ();
			} else if (username == "Haxxor!") {
				Base.LoadValues (0, 0, 0, 10, 0, 2000);
				BtnGiveCat.Visibility = ViewStates.Visible;
				btnSQL.Visibility = ViewStates.Visible;

			}
			else {
				Base.LoadValues (
					prefs.GetInt ("clickcount", 0),
					prefs.GetInt ("clicktotal", 0),
					prefs.GetInt ("catamount", 0),
					prefs.GetInt ("catcost", 10),
					prefs.GetInt ("bananaamount", 0),
					prefs.GetInt ("bananacost", 2000));
			}
			this.Title = "ButtonClicker - " + username; //Displays username in title... Obviously.
			Update();
		}

		protected void OnStart (Bundle bundle)
		{
			base.OnStart(); // Always call the superclass first.
			Update ();
		}

		public void Update()
		{
			TVClicks.Text = "Total: " + Base.clicks_Total;
			TVCurrent.Text = "Current: " + Base.clicks_Current;
			TVBananaAmount.Text = "Bananans: " + Base.banana_Amount;
			TVCatAmount.Text = "Cats: " + Base.cat_Amount;

			editor.PutInt ("clickcount", Base.clicks_Current);
			editor.PutInt ("clicktotal", Base.clicks_Total);
			editor.PutInt ("catamount", Base.cat_Amount);
			editor.PutInt ("catcost", Base.cat_Cost);
			editor.PutInt ("bananaamount", Base.banana_Amount);
			editor.PutInt ("bananacost", Base.banana_Cost);
			editor.Commit ();
		}

		private void RESET (object sender, EventArgs e)
		{
			editor.Clear ();
			editor.Commit ();
			Toast.MakeText (this, "Please restart application now", ToastLength.Long).Show ();
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
		
			SetContentView(Resource.Layout.input_dialog);
			Username_input = FindViewById<EditText> (Resource.Id.evUsername);
			btnOK = FindViewById<Button> (Resource.Id.btnOK);
			btnOK.Click += new EventHandler (OkClicked);
		}

		private void OkClicked (object sender, EventArgs e)
		{
			//if (USERNAME IS OK) 
			username = Username_input.Text;
			if (username != "Admin" && username != "admin" && username != "Admin " && username != "admin " && username != "") {
				editor.PutString ("username", username);
				editor.Commit ();
				//Recreates activity after entered username
				OnCreate (bundle);
				Toast.MakeText (this, username, ToastLength.Long).Show ();
			}
			else {
				Toast.MakeText (this, "Come on, what the fuck did you expect?", ToastLength.Long).Show ();
			}
			Update (); 
			//} else {
			//Toast.MakeText (this, "Username already exists", ToastLength.Long).Show ();}



		}
		
		 //No more SQL will replace with a webservice insted
		private void btnSQL_Click (object sender, EventArgs e)
		{
			string sqlConnectionString = "server=10.0.2.2:3306;user id=master;password=master;database=test_1;connection timeout=10";
			SqlConnection myConnection = new SqlConnection(sqlConnectionString);

			try
			{
				myConnection.Open();
				Toast.MakeText (this,"I has completed my mission master!", ToastLength.Long).Show();
				myConnection.Close ();
			}
			catch(Exception a)
			{
				Toast.MakeText (this,a.ToString(), ToastLength.Long).Show();
			}

		}
	}
}


