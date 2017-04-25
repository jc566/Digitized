using UnityEngine;
using System.Collections;

public class SnowballCollisionEvent : MonoBehaviour {
    public GameObject player; //reference to the player
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
			Invoke ("runRespawnInfo", 3); //run function to trigger respawn conditions in snow region
        }
    }
	public void runRespawnInfo()
	{
		player.GetComponent<SnowRegionRespawn>().respawnPlayer();
	}
}
