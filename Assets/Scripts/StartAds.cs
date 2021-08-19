using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

public class StartAds : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        StartCoroutine(ShowAd());
    }
    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-9167408154391994/4591040331";
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }
    IEnumerator ShowAd()
    {
        yield return new WaitWhile(() => interstitial.IsLoaded()==false);
        interstitial.Show();
    }
}
