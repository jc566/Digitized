/*
 * Created by Joseph Choi
 * This script is to handle interacting with the animal
 * statue mini game.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
[RequireComponent(typeof(Collider))]
public class AnimalStatues : MonoBehaviour, IGvrGazeResponder
{
    private Vector3 startingPosition;

    public GameObject miniGameRef;
    public AnimalsMiniGame miniGameScript;
    public List<GameObject> arrayRef = new List<GameObject>();
    

    // public Transform target;

    void Start()
    {

        miniGameRef = GameObject.FindGameObjectWithTag("AnimalMiniGame");
        miniGameScript = miniGameRef.GetComponent<AnimalsMiniGame>();
        startingPosition = transform.localPosition;
        SetGazedAt(false);
    }

    void LateUpdate()
    {

        arrayRef = miniGameScript.playerChoices;

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
        //Debug.Log(arrayRef);
        if(arrayRef.Count < 3)
        {
            arrayRef.Add(this.gameObject);
        }
        

        


    }
    //Activate the image in the FloorUI
  

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
        printMessage();
        
    }

    #endregion
}
