using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script handles chacking if player is near object generating location and will generate the visual of the held object
//for the player to see they are holding it
public class GiveItem : MonoBehaviour
{
    
    private bool playerInRange;

    [SerializeField]
    private GameObject itemToGive;
    
    //should probably get a singleton setup for referencing player later
    [SerializeField]
    private GameObject player;
    void Update()
    {
        //E to interact, changable later if needed
        if(Input.GetKeyDown(KeyCode.E))
        {
            //if player is near dirt drawer (or watever they are grabbing items from)
            if(playerInRange)
            {
                //if player already holding item do nothing
                if(!player.GetComponent<HoldItem>().GetHoldingItem())
                {
                    //if hands empty then create visual ofheld item as child of player and set holding item state to true
                    CreateItem();
                    Debug.Log("Item Given");
                    player.GetComponent<HoldItem>().SetHoldingItem(true);
                }
            }
            
        }
        
    }

    //updates the bool tracking if player in trigger
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    //generate very simple item visual prefab
    public void CreateItem()
    {
        Instantiate(itemToGive, player.transform);
    }
}
