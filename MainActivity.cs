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
		*/



		//Global vars
		double clicks_Total = 0;
		double clicks_Current = 0;
		int cat_Amount = 0;
		int cat_Cost = 10;
		double cat_CostMultiplier = 1; //Not the final solution, but just to somehow change the cost after buying a cat.
		double mult = 1;

		Random randomCatEffectChanse = new Random();
		Random effectType = new Random();

		private Button BtnClickMe;
		private Button BtnBuyCat;
		private TextView TVClicks;
		private TextView TVCurrent;
		private TextView TVCatAmount;
		private Button btnSQL;

		//DEBUG
		private TextView TVCatCost;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Find the buttons
			BtnClickMe = FindViewById<Button> (Resource.Id.btnClick);
			BtnClickMe.Click += new EventHandler (click_Click);

			BtnBuyCat = FindViewById<Button> (Resource.Id.btnBuyCat);
			BtnBuyCat.Click += new EventHandler (buyCat_Click);

			TVClicks = FindViewById<TextView> (Resource.Id.tvClickCount);
			TVCatAmount = FindViewById<TextView> (Resource.Id.tvCatCount);
			TVCurrent = FindViewById<TextView> (Resource.Id.tvCurrentCount);

			//DEBUG
			TVCatCost = FindViewById<TextView> (Resource.Id.textView1);
			//btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			//btnSQL.Click += new EventHandler (btnSQL_Click);

		}

		private void click_Click (object sender, EventArgs e)
		{
			clicks_Total += 1 * mult;
			clicks_Current += 1 * mult;

			//Randomizes a number between 1 and 100, and if the number is less then the cat amount a effect can take place
			if (randomCatEffectChanse.Next (0, 100) < cat_Amount) {

				//Randomizes a number as previous, and thereby decide a suitable effect
				if (effectType.Next (0, 100) < 50) {
					//DubbleCoin effect
					clicks_Total += 1 * mult;
					clicks_Current += 1 * mult;
				} else {
					// + 200 clicks
					clicks_Total += 200;     //NOTE: NOT MULTIPLIED
					clicks_Current += 200;
				}
			
			
			}


			TVClicks.Text = "Total: " + clicks_Total;
			TVCurrent.Text = "Current: " + clicks_Current;
		}

		private void buyCat_Click (object sender, EventArgs e)
		{
			if (clicks_Current >= cat_Cost) {
				cat_Amount++;
				clicks_Current -= cat_Cost;
				cat_CostMultiplier++;
				cat_Cost = (int)(cat_Cost * cat_CostMultiplier);

			}
			TVCatCost.Text = cat_Cost.ToString();
			TVCatAmount.Text = "Cats: " + cat_Amount;
			TVCurrent.Text = "Current: " + clicks_Current;
		}
		/* //No more SQL will replace with a webservice insted
		private void btnSQL_Click (object sender, EventArgs e)
		{
			string sqlConnectionString = "Data Source=dbadmin.one.com;user id=marlind_net;password=123456789M;database=marlind_net;connection timeout=10";
			SqlConnection myConnection = new SqlConnection(sqlConnectionString);

			try
			{
				myConnection.Open();
				Toast.MakeText (this,"I has completed my mission master!", ToastLength.Long).Show();
				myConnection.Close ();
			}
			catch(Exception a)
			{
				btnSQL.Text = a.ToString ();
			}


		}*/
	}
}


