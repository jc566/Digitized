using UnityEngine;
using System.Collections;

public class PickupSpin : MonoBehaviour {
	
	/* Update is called once per frame */
	void Update () {
        /* Every frame rotates the transform of the object (pickup item) around y-axis */
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime,Space.World);
	}
}
