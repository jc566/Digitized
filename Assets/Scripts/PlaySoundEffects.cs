using UnityEngine;
using System.Collections;

public class PlaySoundEffects : MonoBehaviour {

    

    public AudioSource soundEffect; //reference to the sound effect we want to play

    public bool playSound = false; //do we play a sound yes or no?

    public AudioClip soundToBePlayed; //audio clip to be played

    // Use this for initialization
    void Start () {

        soundEffect = GetComponent<AudioSource>(); //get the audio source component attached to object

	}
	
	// Update is called once per frame
	void Update () {
        
        if(playSound == true & soundEffect.isPlaying == false)
        {
            PlaySoundEffect();
            playSound = false;
        }
	}


    public void PlaySoundEffect()
    {
        soundEffect.PlayOneShot(soundToBePlayed, 0.4f);
        //soundEffect.Play();
        //playSound = false;
        //soundEffect.PlayDelayed(0.1f);

    }

}
