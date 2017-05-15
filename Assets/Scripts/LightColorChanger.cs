using UnityEngine;
using System.Collections;

public class LightColorChanger : MonoBehaviour {
	public Light waypointLight;

	// Use this for initialization
	void Start () {
		waypointLight = this.gameObject.GetComponentInChildren<Light> ();

		InvokeRepeating ("changeColors", 1.0f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (randomColor);
	}

	void changeColors()
	{
		Color randomColor = new Color (Random.value, Random.value, .1f);
		waypointLight.color = randomColor;
		Debug.Log (waypointLight.color);
	}
}
