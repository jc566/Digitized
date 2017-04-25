using UnityEngine;
using System.Collections;

public class AnimalGameTrigger : MonoBehaviour {

    public GameObject MiniGame;//reference to the animal mini game

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            MiniGame.GetComponent<AnimalsMiniGame>().runMiniGame = true;
        }
    }
}
