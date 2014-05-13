using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Data;
using System.Data.SqlClient;

namespace ButtonClicker
{
	[Activity (Label = "ButtonClicker", MainLauncher = true)]
	public class MainActivity : Activity
	{
		/*
			NOTES- and IDEAS-LIST:
			- How about later on making a "shop-window" with a list-layout? //Erik
			- Added a bunch of buttons. Id of buttons is as follows: "button1" and then upp to "button8"
			NOTE! Change these buttons names to something better when they have an actual function.
			- Added a bunch of textview's to go along with the buttons. Id of them are as follows "textview1" to "textview6".
		*/



		//Global vars
		double clicks_Total = 0;
		double clicks_Current = 0;
		int cat_Amount = 0;
		int cat_Cost = 10;
		double cat_CostMultiplier = 1; //Not the final solution, but just to somehow change the cost after buying a cat.
		double mult = 1;

		private Button BtnClickMe;
		private Button BtnBuyCat;
		private TextView TVClicks;
		private TextView TVCurrent;
		private TextView TVCatAmount;
		private Button btnSQL;

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

			btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			btnSQL.Click += new EventHandler (btnSQL_Click);

		}

		private void click_Click (object sender, EventArgs e)
		{
			clicks_Total += 1 * mult;
			clicks_Current += 1 * mult;
			TVClicks.Text = "Total: " + clicks_Total;
			TVCurrent.Text = "Current: " + clicks_Current;
		}

		private void buyCat_Click (object sender, EventArgs e)
		{
			if (clicks_Current >= cat_Cost) {
				cat_Amount++;
				clicks_Current -= cat_Cost;
				cat_Cost = (int)(cat_Cost * cat_CostMultiplier);
				cat_CostMultiplier++;
			}

			mult += (cat_Amount); //This might be the plan, but are mult goint to increase exponentially?
			//						How about, instead of multiplying, increasing the "chanse" of getting an extra click?
			TVCatAmount.Text = "Cats: " + cat_Amount;
			TVCurrent.Text = "Current: " + clicks_Current;
		}

		private void btnSQL_Click (object sender, EventArgs e)
		{
			SqlConnection myConnection = new SqlConnection("user id=fakeid;" + 
			                                               "password=fakepw; server=dbadmin.one.com;" + 
			                                               "Trusted_Connection=no;" + 
			                                               "database=marlind_net;" + 
			                                               "connection timeout=30");
			try
			{
				myConnection.Open();
			}
			catch(Exception a)
			{
				btnSQL.Text = a.ToString ();
			}


		}
	}
}


