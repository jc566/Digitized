﻿using UnityEngine;
using System.Collections;

public class WalkingSoundEffectTriggerF2B : MonoBehaviour {

    public GameObject player; //reference to the player

    //references to the audio clips
    public AudioClip forestWalking;
    public AudioClip bridgeWalking;
    public AudioClip snowWalking;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.GetComponent<AudioSource>().clip != bridgeWalking)
            {
            player.GetComponent<AudioSource>().clip = bridgeWalking;
            player.GetComponent<AudioSource>().Play();
            }
            
           
        }
    }
}

