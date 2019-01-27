using UnityEngine;
using System.Collections;

public class VoiceModLogic : MonoBehaviour 
{
	public OVRVoiceModContext[] contexts;

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    void Start()
    {
        clipSampleData = new float[sampleDataLength];
        audioSource = contexts[0].audioSource;
        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
    }

    // Update is called once per frame
    // Logic for LipSync_Demo
    void Update () 
	{
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
            Debug.Log("ClipLoudness: " + clipLoudness);
            
        }
    }


	/// <summary>
	/// Updates the model scale.
	/// </summary>
	void CheckVolume()
	{
        //Debug.Log("Volume = " + contexts[0].GetAverageAbsVolume());
        //float absVol = contexts[0].GetAverageAbsVolume();
        //Debug.Log(contexts[0].audioSource.volume);
        
        
        
        
        //if(absVol > .0009f)
        //{
        //    Debug.Log("Did it!!!! AbsVol = " + absVol);
        //}

        //Debug.Log("num presets " + contexts[i].GetNumPresets());
        //Debug.Log("string " + contexts[i].ToString());
		// xfrms[i].localScale = scale * (1.0f + (contexts[i].GetAverageAbsVolume() * scaleMax));
	}
}
