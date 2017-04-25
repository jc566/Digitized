/*
 * Modified by Joseph Choi
 * This script is to handle "picking up" items
 * and placing an image in the UI to mimic
 * an item inside a inventory.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class VRInvPickup : MonoBehaviour, IGvrGazeResponder
{
    private Vector3 startingPosition;

   
    public Sprite invIcon; //what image will be placed inside the inventory

    public GameObject[] children; //list of the children on the inventory parent
    
    

    void Start()
    {


        startingPosition = transform.localPosition;
        SetGazedAt(false);
    }

    void LateUpdate()
    {
        GvrViewer.Instance.UpdateState();
        if (GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        
    }

    public void Reset()
    {
        transform.localPosition = startingPosition;

    }
    //Print a message to make sure it is working
    public void printMessage()
    {
        Debug.Log("FUCKING KILL ME");
    }
    //Activate the image in the FloorUI
    public void activateInvImage()
    {
        

        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");

        int InventorySize = inventory.transform.GetChildCount(); //get the size of the inventory
        children = new GameObject[InventorySize]; //instantiate the array now

        //first populate the list of children. They should all be empty at first
        for (int i = 0; i < InventorySize;i++)
        {
            children[i] = inventory.transform.GetChild(i).gameObject;

            Debug.Log(children[i].GetComponent<Image>().sprite);
            

        }

        //now go through the list and replace each item that is null with the item we just picked up
        for (int i = 0; i <InventorySize;i++)
        {
            //Debug.Log(children[i].GetComponent<Image>().sprite);
            if (children[i].GetComponent<Image>().sprite == null)
            {
                Debug.Log("YOUR IMAGES ARE EMPTY");

                children[i].GetComponent<Image>().sprite = invIcon;
                break;
            }
        }
        //GameObject[] childObjs = inventory.transform.GetChild(i).gameObject;
        
        //GameObject childObjs = inventory.transform.GetChild(1).gameObject;
        //childObjs.GetComponent<Image>().sprite = invIcon;
        //Debug.Log(childObjs);
        Destroy(gameObject);
    }

    //Add to your player inventory
    public void addToInventory()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //reference the player
        player.GetComponent<InventoryScript>().gotBoots();

    }

    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetGazedAt(false);
    }
   
    /// Called when the viewer's trigger is used, between OnGazeEnter and OnPointerExit.
    public void OnGazeTrigger()
    {
        
        activateInvImage();
    }

    #endregion
}
