//Created by Joseph Choi
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public bool isMoving = false; //player is not moving by default

    public Vector3 oldPosition; //the old position reference
    public Vector3 curPosition; //the new position reference

    public AudioSource soundEffect;
    public AudioClip forestWalking;
    public AudioClip snowWalking;
    public AudioClip bridgeWalking;
    public bool inSnowRegion = false;
    public bool inForestRegion = false;
    public bool inBridgeRegion = false;



    public ParticleSystem snowParticle;
    public ParticleSystem rainParticle;

    // Use this for initialization
    void Awake()
    {
        snowParticle.Stop();
        rainParticle.Stop();
    }
    void Start()
    {
        
        soundEffect = GetComponent<AudioSource>(); //get the audio source component attached to object


        oldPosition = transform.position; //set the old position
        //isMoving = false; //default set ismoving to false
        //inSnowRegion = false; //default set inSnowRegion to false

    }

    // Update is called once per frame
    void Update()
    {
        curPosition = gameObject.transform.position; //set the current location of the object
       

        setIsMoving(curPosition);





    }

    //check to see if the Game Object (in this case Player) is moving or not
    public void setIsMoving(Vector3 curPosition)
    {

        //if the old position is not the same as current position then set 'isMoving' to true
        if (oldPosition != curPosition)
        {
            


            //soundEffect.Play(); //play sound effect

            //Debug.Log("this is old pos" + oldPosition);
            //Debug.Log("this is cur pos" + gameObject.transform.position);

        }
        else if (oldPosition == curPosition)//other wise, object is not moving and set 'isMoving' to false
        {
            
            isMoving = true;
            //check to see if it should start raining
            if (curPosition.z < -19)
            {
                rainParticle.Play();
            }
            else
            {
                rainParticle.Stop();
            }

            


           soundEffect.PlayDelayed(.2f);
        }
        
        oldPosition = curPosition; //set the old posiiton to be the same as the curPosition to "reset" this stuff

    }



}