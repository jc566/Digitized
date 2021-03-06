using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class spawn_script : MonoBehaviour {
    public Transform [] SpawnLocations;
    public GameObject snow;

    public GameObject avalancheSound;
    

    public List<GameObject> allSnowballsSpawned; //keeps track of all the snowballs spawned

    public bool isRunning;

    void Start() {
        
        avalancheSound = GameObject.Find("AvalancheSoundSpawn");
    }

    void Update()
    {

    }

    public IEnumerator spawnTheSnowballs()
    {

        isRunning = true;


        for (int i = 0; i < 4; i++)
        {
                GameObject rigidSnow = Instantiate(snow, SpawnLocations[0].transform.position, SpawnLocations[0].rotation) as GameObject;
                GameObject rigidSnow1 = Instantiate(snow, SpawnLocations[1].transform.position, SpawnLocations[1].rotation) as GameObject;
                GameObject rigidSnow2 = Instantiate(snow, SpawnLocations[2].transform.position, SpawnLocations[2].rotation) as GameObject;
                GameObject rigidSnow3 = Instantiate(snow, SpawnLocations[3].transform.position, SpawnLocations[3].rotation) as GameObject;

                allSnowballsSpawned.Add(rigidSnow.gameObject);
                allSnowballsSpawned.Add(rigidSnow1.gameObject);
                allSnowballsSpawned.Add(rigidSnow2.gameObject);
                allSnowballsSpawned.Add(rigidSnow3.gameObject);
             
                yield return new WaitForSeconds(2f);
        }

        isRunning = false;
        
        

    }
 	void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player")
        {
            avalancheSound.GetComponent<AudioSource>().PlayDelayed(.1f); //play the avalanche sound as needed
            if (!isRunning)
            {
                StartCoroutine(spawnTheSnowballs());
            }
        }
       
        
    }

    //keep track of the snowballs being created
    public void trackSnowballs()
    {
        
    }
}
