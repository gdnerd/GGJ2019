using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class trumpHeadController : MonoBehaviour {

    public GameObject headSprite;

    // Use this for initialization
    void Start () {
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
    }
	
	// Update is called once per frame
	void Update () {
        headSprite.transform.position = VRTK_DeviceFinder.HeadsetTransform().position;
        headSprite.transform.localRotation = VRTK_DeviceFinder.HeadsetTransform().rotation;
    }
}
