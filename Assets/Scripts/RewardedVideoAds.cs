using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedVideoAds : MonoBehaviour, IUnityAdsListener
{
    #if UNITY_IOS
        private string gameId = "3481041";

#elif UNITY_ANDROID
                private string gameId = "3481040";
#endif
    public Text mycompletion;
    Button myButton;
    public string myPlacementId = "rewardedVideo";
    bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if ((showResult == ShowResult.Finished) && (placementId == myPlacementId))
        {
            // Reward the user for watching the ad to completion.
            int currentValue = int.Parse(mycompletion.text);
            mycompletion.text = (currentValue + 1).ToString();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
