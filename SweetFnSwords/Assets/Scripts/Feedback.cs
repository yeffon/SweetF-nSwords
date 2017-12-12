using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public Health playerHealth;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth = null)
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(3999);
        }
	}
}
