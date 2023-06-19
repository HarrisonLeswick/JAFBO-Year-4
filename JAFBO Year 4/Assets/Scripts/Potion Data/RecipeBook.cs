using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy;

public class RecipeBook : MonoBehaviour
{
    public Recipe currentRecipe;
    public Cauldron c;

    // Start is called before the first frame update
    void Start()
    {

        //we are gonna move this out of Start, actually
        //we'll worry about that later tho


        //assigning the caudron drain rates to the values for the potion
        c.drainRates = new float[] { 5, 10, (int)currentRecipe.boilRate, 5 };
        //assigning the order to the cauldron
        c.order = currentRecipe.ingredientOrder;


        //okay
        //then what we're gonna do is assign the sprite of the three ingredients to the saved ones in the recipe
        //i probably could've done this myself but i wanted food, get rekt
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
