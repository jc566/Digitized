/*
 * Created by Joseph Choi
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimalsMiniGame : MonoBehaviour
{

    public GameObject cat;
    public GameObject beaver;
    public GameObject whale;

    public GameObject[] animalsList;
    public List<GameObject> playerChoices;
    public GameObject[] listToCompare = new GameObject[3];
    
    public bool runMiniGame = false;

    public GameObject caveDoor;
    public AudioClip caveDoorOpening;
    
    // Use this for initialization
    void Start()
    {
      
        //randomAnimalSelector();
        //createVariables();

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("createVariables", 1f);

        if(runMiniGame == true)
        {
            createVariables();
        }
        
            checkLists(listToCompare);
        

		//Delete the Cave Door if it goes too high 
		if (caveDoor.transform.position.y > 4.20f) 
		{
			Destroy (caveDoor);
		}
        

    }
    public IEnumerator toggleLights(int index, GameObject[] savedList)
    {

        for (index = 0; index < savedList.Length; index++)
        {

            savedList[index].GetComponentInChildren<Collider>().enabled = false;

        }

        for (index = 0;index < savedList.Length;index++)
        {
            yield return new WaitForSeconds(.5f);
           
            savedList[index].GetComponentInChildren<Light>().enabled = true;

            yield return new WaitForSeconds(.5f);

            savedList[index].GetComponentInChildren<Light>().enabled = false;
        }

        yield return new WaitForSeconds(1.0f);

        for (index = 0; index < savedList.Length; index++)
        {
            
            savedList[index].GetComponentInChildren<Collider>().enabled = true;
       
        }
        /*
        savedList[index].GetComponentInChildren<Light>().enabled = false;
        savedList[index + 1].GetComponentInChildren<Light>().enabled = false;
        savedList[index + 2].GetComponentInChildren<Light>().enabled = false;

        yield return new WaitForSeconds(.5f);
        savedList[index+1].GetComponentInChildren<Light>().enabled = false;
        savedList[index+2].GetComponentInChildren<Light>().enabled = false;
        savedList[index].GetComponentInChildren<Light>().enabled = true;

        yield return new WaitForSeconds(.5f);
        if (savedList[index].GetComponentInChildren<Light>().enabled == true)
        {
            savedList[index].GetComponentInChildren<Light>().enabled = false;
        }
        savedList[index].GetComponentInChildren<Light>().enabled = false;
        savedList[index+2].GetComponentInChildren<Light>().enabled = false;
        savedList[index + 1].GetComponentInChildren<Light>().enabled = true;


        yield return new WaitForSeconds(.5f);


        if (savedList[index + 1].GetComponentInChildren<Light>().enabled == true)
        {
            savedList[index + 1].GetComponentInChildren<Light>().enabled = false;
        }
        savedList[index].GetComponentInChildren<Light>().enabled = false;
        savedList[index+1].GetComponentInChildren<Light>().enabled = false;
        savedList[index + 2].GetComponentInChildren<Light>().enabled = true;


        yield return new WaitForSeconds(.5f);

        savedList[index + 2].GetComponentInChildren<Light>().enabled = false;
        savedList[index].GetComponentInChildren<Light>().enabled = false;
        savedList[index + 1].GetComponentInChildren<Light>().enabled = false;
        */
    }
    //create the needed variables
    public void createVariables()
    {
       
        animalsList = new GameObject[3];
        animalsList[0] = cat;
        animalsList[1] = beaver;
        animalsList[2] = whale;


        playerChoices = new List<GameObject>();

        runMiniGame = false;
        randomAnimalSelector();
    }

    //randomly choose animals to light up for player to follow sequence
    public void randomAnimalSelector()
    {

        GameObject[] randomOrderSaved = new GameObject[3];
        //gernerate random pattern
        for (int i = 0; i < animalsList.Length; i++)
        {
            GameObject temp = animalsList[i];
            int randomIndex = Random.Range(i, animalsList.Length);
            animalsList[i] = animalsList[randomIndex];
            animalsList[randomIndex] = temp;
        }

        //store the order we created 
        randomOrderSaved = animalsList;
        //save the random list into a global list
        listToCompare = randomOrderSaved;
        //run the next function, send the order to it
        animalLightShow(randomOrderSaved);
        
    }

    //Light up the animals for the player to know what to do
    public void animalLightShow(GameObject[] savedList)
    {
        int index = 0; //index to reference each item in the list
        StartCoroutine(toggleLights(index, savedList));//Show the Player the Order they must match
        
        


    }
    //check to see if the playerChoice list is the same as the saved List
    public void checkLists(GameObject[] savedList)
    {

        //GameObject[] playerPicks = playerChoices.ToArray();
        GameObject[] playerPicks = new GameObject[3];
        playerPicks = playerChoices.ToArray();

        int matchCount = 0; //the player must match all 3
        for(int i = 0; i < savedList.Length;i++) //check the order to see if same
        {
            if(playerPicks[i] == savedList[i])
            {
                matchCount++; //if it is a match in order, then add to count
            }
        }
        //When not all 3 are matching, reset
        if(matchCount != 3)
        {
            Debug.Log("Its NOT a Match");
            
            runMiniGame = true;
        }
        else //if we are here, that means its the same order
        {
            Debug.Log("its a Match");
            //Open the Rock Door to get the snow boots + play sound effect
          
            caveDoor.GetComponent<PlaySoundEffects>().playSound = true;
			caveDoor.transform.Translate(Vector3.up * 1.0f * Time.deltaTime);
        }
    }

    
}
