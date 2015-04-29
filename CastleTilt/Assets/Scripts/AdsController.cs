//AdController.cs is a slightly modified version of: http://fa3d.blogspot.co.uk/2015/04/how-to-integrate-admob-into-unity.html

//Banner Ad ID is unique to this game, if a new ID is needed ask me to generate one.
//The banner ad will only display at the bottom of the menu inside Android.

//Please do not click the adverts, it's against the T&C of Admob, just trust me that they work.

//I've commented out any reference to intersitial ads because it'll interfere with how the menu is already designed.
//If you want to put in intersitial ads anyway, I'll generate a ad ID for you.

// - Christian (29th April)

using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;  // For EventArgs

public class AdsController : MonoBehaviour {
	
//	InterstitialAd interstitial;
	BannerView bannerView;
	
	void Start () {
		
		//------ Banner Ad -------
		// Create a 320x50 banner at the top of the screen.
		// Put your Admob banner ad id here
		bannerView = new BannerView(
			"ca-app-pub-3459356071873398/9141096395", AdSize.SmartBanner, AdPosition.Top);
		// Create ad request
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);        
		bannerView.Show();

		/*

		//---- Interstitial Ad -----
		// Initialize an InterstitialAd.
		// Put your admob interstitial ad id here:
		interstitial = new InterstitialAd("ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx");
		
		//Add callback for when ad is loaded
		interstitial.AdLoaded += HandleAdLoaded;
		
		// Create an ad request.
		AdRequest requestInterstitial = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(requestInterstitial);

	*/
	}
	
	
/*	
	public void HandleAdLoaded(object sender, EventArgs args) {
		
		interstitial.Show ();
	}
*/	
	
	void OnDestroy(){
		/*
		if (interstitial!=null) {
			interstitial.AdLoaded -= HandleAdLoaded;
			interstitial.Destroy ();
		}
		*/
		if(bannerView!=null){
			bannerView.Destroy ();
		}
	}
	
}