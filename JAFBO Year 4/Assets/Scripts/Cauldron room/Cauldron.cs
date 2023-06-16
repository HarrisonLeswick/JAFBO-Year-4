using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cauldron : MonoBehaviour
{
    //the trigger that will currently activate the stirring state
    public BoxCollider2D cauldronTrigger;

    //gameobject reference used to affect the energybar
    public GameObject energyBar;

    //variables for sprite switching
    public SpriteRenderer sprite;
    public Sprite[] images;
    private int imgInterval;
    
    //use DontDestroyOnLoad or something like that so that we can initialize some values in Start
    public float energy = 50f;
    public float boilOverPercent = 50f;
    //0/1: simmer/stir energy   2/3: simmer/stir boil
    public float[] drainRates = new float[4];

    //readable bool for if cauldron is simmering or being stirred 
    public bool isSimmering = true;
    //bool for whether to update our meters this frame or not
    bool cauldronIsActive = false;


    
    // Start is called before the first frame update
    void Start()
    {
        //set the cauldron to active
        cauldronIsActive = true;

        //this calculates the interval at which we change the cauldron sprite. i elaborate more on it in the link in AdjustBoilOver()
        imgInterval = 100 / (images.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        //if the cauldron hasn't exploded yet, update your stats
        if (cauldronIsActive)
        {
            UpdateMeters();
        }
    }

    /// <summary>
    /// Updates the player's energy and the cauldron's BoilOver meter
    /// </summary>
    public void UpdateMeters()
    {
        //assuming the potion phase has not ended, we will constantly adjust the player's energy and the potion's boilover every frame

        //switched to simple bool for readability
        if (isSimmering)
        {
            AdjustEnergy(drainRates[0] * Time.deltaTime);//gain energy as you are not stirring
            AdjustBoilOver(drainRates[2] * Time.deltaTime);//the pot gets closer to boiling over as it is being left unattended
            
        }
        else
        {

            AdjustEnergy(-drainRates[1] * Time.deltaTime);//lose energy as you are currently using it to stir
            AdjustBoilOver(-drainRates[3] * Time.deltaTime);//the pot is being stirred so it is calming and the boilover is going down
            
        }
    }

    /// <summary>
    /// Modifies the player's energy
    /// </summary>
    /// <param name="adjustVal">the amount by which the player's energy is being changed</param>
    public void AdjustEnergy(float adjustVal)
    {
        energy += adjustVal;
        energy = (energy <= 100.00) ? energy : 100.00f;//don't let energy be higher than 100
        if(energy <= 0f)
        {
            Debug.Log("no energy!");//redundant, should probably actually have feedback or something else happen here
            energy = 0f;//don't let energy be negative
        }
    }

    /// <summary>
    /// Modifies boilOverPercent.
    /// Will then update the sprite based on the value of boilOverPercent
    /// </summary>
    /// <param name="adjustVal">the amount by which boilOverPercent will be modified</param>
    public void AdjustBoilOver(float adjustVal)
    {
        boilOverPercent += adjustVal;
        boilOverPercent = (boilOverPercent >= 0f) ? boilOverPercent : 0f;//don't let boilover be negative

        //update the sprite now

        //if this reaches 100%, the cauldron has boiled over, so we need to make it explode and stop doing cauldron updates
        if (boilOverPercent >= 100f)
        {
            Debug.Log("KABOOM! your potion has exploded :O (image 4)");//redundant
            //change image to exploded
            sprite.sprite = images[4];
            //the cauldron will no longer update, this is a temp solution for not kicking the player out on a failure
            cauldronIsActive = false;
        }
        else 
        {
            //setting the sprite by doing some silly and goofy math, dw about it lmfao
            //if you are actually worried about it, i explained it in a very passive-aggressive manner here: https://docs.google.com/document/d/16Y_kvmv-cT6F_tFJ95Qupm8Yd1u2093iFchm8Ggx5D8/edit?usp=sharing 
            sprite.sprite = images[(int)(boilOverPercent / imgInterval)];
            //we can probably optimize this later and only update the sprite if there's a change
        }
    }

    /// <summary>
    /// called when the player enters the trigger attached to the cauldron.
    /// sets the state to stirring
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //tells enrgy to start decaying
        energyBar.GetComponent<energyBar>().Stirring();
        //set isSimmering to false because we are stirring
        isSimmering = false;
        Debug.Log("Stirring the potion");//redundant output

    }

    /// <summary>
    /// called when the player exits the trigger attached to the cauldron. 
    /// sets the state to simmering
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        //tells enrgy to start gaining
        energyBar.GetComponent<energyBar>().StopStirring();
        //set isSimmering to true because the cauldron is being left to simmer
        isSimmering = true;
        Debug.Log("Letting the potion simmer");//redundant output
    }
}
