using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {

    public Animator anim;
    public AudioClip ToiletLidOpenClip;
    public AudioSource TLOSource;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        TLOSource.clip = ToiletLidOpenClip;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("1"))
        {
            anim.Play("animLid");
            TLOSource.Play();
        }
    }
}
