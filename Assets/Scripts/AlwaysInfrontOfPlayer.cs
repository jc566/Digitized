using UnityEngine;
using System.Collections;

public class AlwaysInfrontOfPlayer : MonoBehaviour {

	public GameObject infrontPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = infrontPlayer.transform.position;
	}
}
