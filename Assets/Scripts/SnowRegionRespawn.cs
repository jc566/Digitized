using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SnowRegionRespawn : MonoBehaviour {
    public GameObject respawnLoc; //reference to the respawn location

    public GameObject player; //reference to the player

    public GameObject respawnWaypoint; //references to Respawn WayPoint to toggle

    public List<GameObject> copiedList; //will recieve the list from Spawn_script.cs

    public GameObject[] allSnowballsSpawned; //store the copied list

    public Sprite whipIcon; //reference to whip
    GameObject[] children;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //set ref

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
     * Toggle SnowRespawn Waypoint ON - DONE
     * Stop the Snowballs Spawning - DONE
     * Delete the Snowballs in map - DONE
     * Remove item from Inventory Script 
     * Remove icon in inventory UI - DONE
     * Toggle Item to turn on and off instead of deleting it
     */
    public void respawnPlayer()
    {
        copiedList = GameObject.Find("avalancheTrigger").GetComponent<spawn_script>().allSnowballsSpawned;//copy the values from Spawn_script
        allSnowballsSpawned = copiedList.ToArray();//convert list to array
        //delete each snowball
        for (int i = 0; i < allSnowballsSpawned.Length;i++)
        {
            Destroy(allSnowballsSpawned[i]);
        }


        //find and delete the whip from the inventory
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");

        int InventorySize = inventory.transform.GetChildCount(); //get the size of the inventory
        children = new GameObject[InventorySize]; //instantiate the array now

        //first populate the list of children. They should all be empty at first
        for (int i = 0; i < InventorySize; i++)
        {
            children[i] = inventory.transform.GetChild(i).gameObject;

            Debug.Log(children[i].GetComponent<Image>().sprite);

            if (children[i].GetComponent<Image>().sprite == whipIcon)
            {
                children[i].GetComponent<Image>().sprite = null;
            }
        }


        respawnWaypoint.SetActive(true); //set the respawn waypoint to active
        player.GetComponent<Rigidbody>().velocity = Vector3.zero; //stop all physics movement
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; //stop all physics movement
        player.transform.position = respawnLoc.transform.position; //set the player to this new location upon death from snowball
    }
}
