using UnityEngine;
using System.Collections;

public class waypointsToggle : MonoBehaviour {
    public GameObject player;
    public bool setActiveTrue = false;

    public Waypoint[] connectedWaypoints;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        connectedWaypoints = this.gameObject.GetComponent<VRWaypoint>().connectedWaypoints;
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(gameObject.transform.position);
	if(player.transform.position == this.gameObject.transform.position)
        {
            foreach(Waypoint i in connectedWaypoints)
            {
                i.gameObject.GetComponent<waypointsToggle>().setActiveTrue = true;
                Debug.Log(i.gameObject);
            }
        }
       
	}
}
