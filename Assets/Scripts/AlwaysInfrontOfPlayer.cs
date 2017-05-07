using UnityEngine;
using System.Collections;

public class AlwaysInfrontOfPlayer : MonoBehaviour {
	public GameObject player;


	public Camera CameraTarget;


	public Transform sunrise;
	public Transform sunset;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.LookAt (CameraTarget);
		//this.transform.LookAt (transform.position + CameraTarget.transform.rotation * Vector3.forward,
		//	CameraTarget.transform.rotation * Vector3.up);

	}

}
