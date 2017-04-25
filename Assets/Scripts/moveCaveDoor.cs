using UnityEngine;
using System.Collections;

public class moveCaveDoor : MonoBehaviour {

    //make reference to the player
    public GameObject player;

    //make boolean for door opening
    public bool moveDoor = false;
	// Use this for initialization
	void Start () {
       player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	if (player.GetComponent<InventoryScript>().haveBoots == true)
        {
            moveDoor = true;
        }

    if(moveDoor == true)
        {
            this.GetComponent<PlaySoundEffects>().playSound = true;
            this.gameObject.transform.Translate(Vector3.up * 1.0f * Time.deltaTime);
        }

        //Delete the Cave Door if it goes too high 
        if (this.gameObject.transform.position.y > 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
