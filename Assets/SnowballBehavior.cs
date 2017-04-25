using UnityEngine;
using System.Collections;

public class SnowballBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        //Destroy(this.gameObject, 5.0f);
	}
}
