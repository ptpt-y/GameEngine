using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUISound : MonoBehaviour
{
    public string playEventName = null;
    public string stopEventName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        if (!string.IsNullOrEmpty(playEventName))
        {
            if (playEventName == "Play_Ambience")
                AkSoundEngine.SetRTPCValue("WindVolume", 50);
            AkSoundEngine.PostEvent(playEventName, mainCamera);
        }
    }
    public void Stop()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        if (!string.IsNullOrEmpty(stopEventName))
        {
            AkSoundEngine.PostEvent(stopEventName, mainCamera);
        }
    }
}
