using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy;

//this script goes on the player and basically handles the mini-inventory of the players hands
public class HoldItem : MonoBehaviour
{
    //used for discarding item. Simple bool to store if an item is held
    private bool holdingItem;

    //stores what ingredient type is being held
    public IngredientSubclass itemType;

    //used to show the sprite above the players head
    public SpriteRenderer itemSprite;
    public Sprite[] images;


    void Update()
    {
        //discards an item when R is pressed
         if(Input.GetKeyDown(KeyCode.R))
        {
            //makes sure we are holding and item and if we are calls discard
            if(GetHoldingItem()){
                DiscardItem();
                Debug.Log("Discard");
            }
        }
    }

    //retrieves the Ingredient subclass variable fo whatever item called it
    public void SetHoldingItem(IngredientSubclass item)
    {
        //changes what ingredient type we are holding to the one grabbed
        itemType = item;
 
        holdingItem = true;

        //changes the sprite of the ingredient based on what type of item we picked up
        if(itemType == IngredientSubclass.Liquid){
            itemSprite.sprite = images[0];
        }
        else if(itemType == IngredientSubclass.Solid){
            itemSprite.sprite = images[1];
        }
        else if(itemType == IngredientSubclass.Magic){
            itemSprite.sprite = images[2];
        }
        //if no ingredient removes the sprite
        else if(itemType == IngredientSubclass.nullINGRED){
            itemSprite.sprite = null;
        }
    }


    public bool GetHoldingItem()
    {
        return holdingItem;
    }

    //can be called by clicking R
    public void DiscardItem(){
        //sets no item held, sets the type of item to nothing and sets the image to blank
        holdingItem = false;
        itemType = IngredientSubclass.nullINGRED;
        itemSprite.sprite = null;
    }
}
