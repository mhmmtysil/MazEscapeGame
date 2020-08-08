using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdConfiguration : MonoBehaviour
{
    public static AdConfiguration Instance { get; private set; }
    BannerView bannerView;
    InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        MobileAds.Initialize(initStatus => { });
        RewardBasedVideoInit();
        RequestBanner();
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    private void RewardBasedVideoInit()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }

    public void ShowRewardAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5390271097374264/9169208237";//"ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-5390271097374264/5458135886";//"ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, adUnitId);
    }
    #region Handles

    private void HandleRewardBasedVideoLeftApplication(object sender, EventArgs e)
    {

    }

    private void HandleRewardBasedVideoClosed(object sender, EventArgs e)
    {

    }

    private void HandleRewardBasedVideoRewarded(object sender, Reward e)
    {
        GameConfiguration.Instance.NextLevel();
    }

    private void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {

    }

    private void HandleRewardBasedVideoOpened(object sender, EventArgs e)
    {

    }

    private void HandleRewardBasedVideoStarted(object sender, EventArgs e)
    {
        LoadingScreen.Instance.WhenLoad();
    }

    private void HandleRewardBasedVideoLoaded(object sender, EventArgs e)
    {
        rewardBasedVideo.Show();
    }
    #endregion

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5390271097374264/7117759964";//"ca-app-pub-5390271097374264/7117759964";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-5390271097374264/4075103151";//"ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5390271097374264/7559778943";//"ca-app-pub-5390271097374264/7559778943";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-5390271097374264/9135858146";//"ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        interstitial.OnAdLoaded += HandleOnAdLoaded;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        interstitial.Show();
    }

}
