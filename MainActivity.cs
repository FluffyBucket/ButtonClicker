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
<<<<<<< HEAD
		bool hasName = false;
=======
		
		bool hasName = false;
		string username;
>>>>>>> b30527581d1677ff171feb22e30ea82453b7d0e1

		int banana_Amount = 0;
		int banana_Cost = 2000;
		double banana_CostMultiplier = Math.E;
<<<<<<< HEAD
=======

>>>>>>> b30527581d1677ff171feb22e30ea82453b7d0e1

		Random randomCatEffectChanse = new Random();
		Random effectType = new Random();

		private Button BtnClickMe;
		private Button BtnBuyCat;
		private Button BtnBuyBanana;
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

			//Find the buttons
			BtnClickMe = FindViewById<Button> (Resource.Id.btnClick);
			BtnClickMe.Click += new EventHandler (click_Click);

			BtnBuyCat = FindViewById<Button> (Resource.Id.btnBuyCat);
			BtnBuyCat.Click += new EventHandler (buyCat_Click);

			BtnBuyBanana = FindViewById<Button> (Resource.Id.button8);
			BtnBuyBanana.Text = "Buy Banana";
			BtnBuyBanana.Click += new EventHandler (buyBanana_Click);

			BtnOpenShop = FindViewById<Button> (Resource.Id.button2);
			BtnOpenShop.Text = Shop;
			BtnOpenShop.Click += new EventHandler (openShop_click);


			TVClicks = FindViewById<TextView> (Resource.Id.tvClickCount);
			TVCurrent = FindViewById<TextView> (Resource.Id.tvCurrentCount);
			TVCatAmount = FindViewById<TextView> (Resource.Id.tvCatCount);
			TVBananaAmount = FindViewById<TextView> (Resource.Id.textView3);
			TVBananaAmount.Text = "Bananas: " + banana_Amount.ToString();
			TVBananaCost = FindViewById<TextView> (Resource.Id.textView5);
			TVBananaCost.Text = "Banana Price: " + banana_Cost.ToString();
			//DEBUG
			TVCatCost = FindViewById<TextView> (Resource.Id.textView1);
			TVCatCost.Text = "Cat Price: " + cat_Cost.ToString ();
			BtnGiveCat = FindViewById<Button> (Resource.Id.button2);
			BtnGiveCat.Text = "Debug me cats!";
			BtnGiveCat.Click += new EventHandler (click_DebugMeCats);
			btnSQL = FindViewById<Button> (Resource.Id.btnSQL);
			btnSQL.Click += new EventHandler (btnSQL_Click);

			if (hasName == false)
			{
<<<<<<< HEAD
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
=======
				nameEntry ();
>>>>>>> b30527581d1677ff171feb22e30ea82453b7d0e1

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
			int clickstack = (banana_Amount + 1);

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

		private void openShop_click (object sender, EventArgs else)
		{
			StartActivity(typeof(Activity2));
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

		private void buyBanana_Click (object sender, EventArgs e)
		{
			if (clicks_Current >= banana_Cost && banana_Amount < 9) { //Can not buy more than 9 bananas
				banana_Amount++;
				clicks_Current -= banana_Cost;
				banana_Cost = (int)(banana_Cost * banana_CostMultiplier);
			} else if (banana_Amount >= 100) {
				new AlertDialog.Builder(this)
					.SetMessage("Stop buying bananas, damn it!")
					.Show();
			} else if (clicks_Current < banana_Cost) {
				new AlertDialog.Builder(this)
					.SetMessage("You are one poor fuc*er. You can buy 20 more clicks for only 3457,45 SEK")
					.Show();
			}
			TVBananaCost.Text = "Banana Price: " + banana_Cost.ToString();
			TVBananaAmount.Text = "Bananas: " + banana_Amount.ToString();
			TVCurrent.Text = "Current: " + clicks_Current;
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


