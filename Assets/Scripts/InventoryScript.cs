using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

    public bool haveWhip = false;
    public bool haveBoots = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gotWhip()
    {
        haveWhip = true;
    }
    public void gotBoots()
    {
        haveBoots = true;
    }
}
