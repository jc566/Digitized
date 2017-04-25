using UnityEngine;
using System.Collections;

public class animalMiniGameTrigger : MonoBehaviour {
	public GameObject AnimalMiniGame; //reference to Animal Mini Game
	public GameObject player; //reference to the player

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider otherObj)
	{
		if (otherObj.gameObject.tag == "Player") 
		{
			AnimalMiniGame.GetComponent<AnimalsMiniGame> ().runMiniGame = true;

		}
	}
}
