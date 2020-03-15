using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
public class Reklam : MonoBehaviour
{
    public string geçişid, bannerid;
    public AdPosition position;
    public BannerView banner;
    public InterstitialAd geçiş;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(reklmalar => { });
        BannerSilme();
        GeçişReklamıİstek();
        BannerRekalmı();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BannerRekalmı()
    {
        banner = new BannerView(bannerid, AdSize.SmartBanner, position);
        AdRequest istek = new AdRequest.Builder().Build();
        banner.LoadAd(istek);

    }
    void BannerSilme()
    {
        if (banner != null)
        {
            banner.Destroy();
        }
    }
    void GeçişReklamıİstek()
    {
        geçiş = new InterstitialAd(geçişid);
        AdRequest istek2 = new AdRequest.Builder().Build();
        geçiş.LoadAd(istek2);
    }
    public void GeçişReklamı()
    {
        if (geçiş.IsLoaded())
        {
            geçiş.Show();
        }
    }
    public void Play()
    {
        BannerSilme();
        SceneManager.LoadScene("Sahne2");
    }
}
