using UnityEngine;
using System.Collections;

public class spawn_script : MonoBehaviour {
    public Transform [] SpawnLocations;
    public GameObject snow;
    //public Rigidbody[] snowBalls;

    void Start() {
        //Debug.Log("Hiiii");
    }

    void Update()
    {
        //yield return new WaitForSeconds (1);
        /*Rigidbody rigidSnow;
        Rigidbody rigidSnow1;
        Rigidbody rigidSnow2;
        Rigidbody rigidSnow3;
        rigidSnow = Instantiate(snow, SpawnLocations[0].transform.position, SpawnLocations[0].rotation) as Rigidbody;
        rigidSnow1 = Instantiate(snow, SpawnLocations[1].transform.position, SpawnLocations[1].rotation) as Rigidbody;
        rigidSnow2 = Instantiate(snow, SpawnLocations[2].transform.position, SpawnLocations[2].rotation) as Rigidbody;
        rigidSnow3 = Instantiate(snow, SpawnLocations[3].transform.position, SpawnLocations[3].rotation) as Rigidbody;
        */
       /* Instantiate(snow, SpawnLocations.position, SpawnLocations.rotation);
        Debug.Log("HEllo");
        */
    }
 	void OnTriggerEnter(Collider other){
       // if (other.tag == "Player")
        //{
            Debug.Log("HEllo");
            Rigidbody rigidSnow;
            Rigidbody rigidSnow1;
            Rigidbody rigidSnow2;
            Rigidbody rigidSnow3;
            rigidSnow = Instantiate(snow, SpawnLocations[0].transform.position, SpawnLocations[0].rotation) as Rigidbody;
            rigidSnow1 = Instantiate(snow, SpawnLocations[1].transform.position, SpawnLocations[1].rotation) as Rigidbody;
            rigidSnow2 = Instantiate(snow, SpawnLocations[2].transform.position, SpawnLocations[2].rotation) as Rigidbody;
            rigidSnow3 = Instantiate(snow, SpawnLocations[3].transform.position, SpawnLocations[3].rotation) as Rigidbody;
        }

}
