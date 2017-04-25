using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject camera;
    public GameObject floorUI; //reference to floor ui to toggle on/off
    private float rotationY;


    // Use this for initialization
    void Start()
    {
        floorUI = GameObject.Find("flooruiCamobject"); //make reference to the floor ui on game start
    }

    // Update is called once per frame
    void Update()
    {

        rotationY = camera.transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(90, rotationY, 0);

        //if above 40 then hide UI
        if (camera.transform.localEulerAngles.x < 40.0f)
        {
            //Debug.Log("Not visible");
            floorUI.GetComponentInChildren<Canvas>().enabled = false;

        }
        //if below 40 then show UI
        if (camera.transform.localEulerAngles.x > 40.0f)
        {

            //Debug.Log ("Visible");
            floorUI.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
}
