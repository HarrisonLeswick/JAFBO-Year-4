using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy;

//this script handles chacking if player is near object generating location and will generate the visual of the held object
//for the player to see they are holding it
public class GiveItem : MonoBehaviour
{
    //bool for if we can intereact
    private bool playerInRange = false;

    //uses joeys ingredient enums and they are selected in the inspector
    [SerializeField]
    private IngredientSubclass itemType;
    
    //sour player reference to be able to communicate with the held script
    [SerializeField]
    private GameObject player;
    void Update()
    {
        //E to pick up item
        if(Input.GetKeyDown(KeyCode.E))
        {
            //if the player is near the object 
            if(playerInRange)
            {
                //if player already holding item do nothing
                if(!player.GetComponent<HoldItem>().GetHoldingItem())
                {
                    //sends the type of item to the players holditem script
                    Debug.Log("Item Given");
                    player.GetComponent<HoldItem>().SetHoldingItem(itemType);
                }
            }
 
        }
                
    }

    //updates the bool tracking if player in range to true
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    //updates the bool tracking if player in range to false
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
