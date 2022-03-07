using UnityEngine;
using UnityEngine.Advertisements;

public class MonetizationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        string gameId = "4221089";
        
        Advertisement.Initialize(gameId,Debug.isDebugBuild);
    }

    public void ShowInterstitial()
    {
        if(Advertisement.IsReady("Interstitial_Android")){
            Advertisement.Show("Interstitial_Android");
        }
    }
    public void iaiaiai()
    {
        Advertisement.Show("Interstitial_Android");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
