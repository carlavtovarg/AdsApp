using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InsterstitialAds : MonoBehaviour
{
    #if UNITY_IOS
        private string gameId = "3481041";

    #elif UNITY_ANDROID
        private string gameId = "3481040";
    #endif
    string video = "video";
    bool testMode = true;

    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        //Advertisement.Initialize(gameGoogleId, testMode);
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayInteristial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayInteristial()
    {
        Advertisement.Show();
    }
}
