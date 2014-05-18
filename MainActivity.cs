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

			
			KNOWN BUGS:
			- Can buy first cat without enough clicks [Fixed]
			- Cannot click atm... I'll fix this after dinner.... [Fixed]
		*/



		//Global vars
		double clicks_Total = 0;
		double clicks_Current = 0;
		int cat_Amount = 0;
		int cat_Cost = 10;
		double cat_CostMultiplier = 1; 
		double mult = 1;
		bool hasName = false;

		Random randomCatEffectChanse = new Random();
		Random effectType = new Random();

		private Button BtnClickMe;
		private Button BtnBuyCat;
		private TextView TVClicks;
		private TextView TVCurrent;
		private TextView TVCatAmount;
		private Button btnSQL;

		//DEBUG VARS
		private TextView TVCatCost;
		private Button BtnGiveCat;


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
			TVCatCost.Text = "Cat Price: " + cat_Cost.ToString ();
			BtnGiveCat = FindViewById<Button> (Resource.Id.button2);
			BtnGiveCat.Text = "Debug me cats!";
			BtnGiveCat.Click += new EventHandler (click_DebugMeCats);
			//btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			//btnSQL.Click += new EventHandler (btnSQL_Click);
			if (hasName == false)
			{
				AlertDialog.Builder alert = new AlertDialog.Builder(this);

				alert.setTitle("Title");
				alert.setMessage("Message");

				// Set an EditText view to get user input 
				final EditText input = new EditText(this);
				alert.setView(input);

				alert.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						String value = input.getText();
						// Do something with value!
					}
				});

				alert.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						// Canceled.
					}
				});

				alert.show();

			}

		}

		private void click_DebugMeCats (object sender, EventArgs e)
		{
			//For debug only
			cat_Amount += 20; if (cat_Amount > 100)
				cat_Amount = 100;
			TVCatAmount.Text = "Cats: " + cat_Amount;
		}

		private void click_Click (object sender, EventArgs e)
		{
			int clickstack = (int)(1 * mult);

			//Randomizes a number between 1 and 100, and if the number is less then the cat amount a effect can take place
			if (randomCatEffectChanse.Next (0, 100) < cat_Amount) {

				//Choise of effect
				switch (effectType.Next (1, 4)) { //Min: Lowest possible, Max: One above highest
				case 1:
					//DubbleCoin effect
					clickstack *= 2;
					break;
				case 2:
					// + 200 clicks
					clicks_Total += 200;     
					clicks_Current += 200;
					break;
				case 3:
					// + 500 total clicks
					clicks_Total += 500;
					break;
				}
			}

			clicks_Total += clickstack;     
			clicks_Current += clickstack;

			TVClicks.Text = "Total: " + clicks_Total;
			TVCurrent.Text = "Current: " + clicks_Current;
		}

		private void buyCat_Click (object sender, EventArgs e)
		{
			if (clicks_Current >= cat_Cost && cat_Amount < 100) { //Can not buy more than 100 cats
				cat_Amount++;
				clicks_Current -= cat_Cost;
				cat_CostMultiplier++;
				cat_Cost = (int)(cat_Cost * cat_CostMultiplier);
			} else if (cat_Amount >= 100) {
				new AlertDialog.Builder(this)
					.SetMessage("Stop buying cats, damn it!")
					.Show();
			} else if (clicks_Current < cat_Cost) {
				new AlertDialog.Builder(this)
					.SetMessage("You are one poor fuc*er. You can buy 20 more clicks for only 3457,45 SEK")
					.Show();
			}
			TVCatCost.Text = "Cat Price: " + cat_Cost.ToString();
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


