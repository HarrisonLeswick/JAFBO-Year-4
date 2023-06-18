using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : MonoBehaviour
{
    [SerializeField]
   private SpriteRenderer spriteRenderer;

    //list of all ingrediant images in recipe
   public List<Sprite> sprites;

   private int currentItem;

    //assignale wait time, defaulted to 2 seconds
    [SerializeField]
   private float waitTime = 2;

    //need one of these variables to assign a coroutine to in order to use them in script
   private IEnumerator showRecipe;

    //assigning coroutine
    void Start() {

        showRecipe = ShowRecipe();
    }
    

    //checking for player entering trigger
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //activate visual and begin coroutine
            spriteRenderer.gameObject.SetActive(true);
            StartCoroutine(showRecipe);
        }   
    }

    //checking for player leaving trigger
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            //de-activating visual, stopping and resetting coroutine
            spriteRenderer.gameObject.SetActive(false);
            StopAllCoroutines();
            currentItem = 0;
        }
    }

    //empty list of ingredient images
    public void ClearSprites()
    {
        sprites.Clear();
    }

    //ad to list of ingrediant images (for use in other scripts t set up ball based on selected recipe recipe)
    public void AddSprite(Sprite sprite)
    {
        sprites.Add(sprite);
    }

    //coroutine for cycling through the ingrediant images of the current recipe
    IEnumerator ShowRecipe()
    {
        //hehe an acceptable use for a while(true)
        while(true)
        {
            //index out of range check
            if(currentItem >= sprites.Count)
            {
                currentItem = 0;
            }
            //assigning the image to the ingrediant
            spriteRenderer.sprite = sprites[currentItem];
            //moving to the next ingredient in the list
            currentItem++;
            //waiting for the alloted amount of time
            yield return new WaitForSeconds(waitTime);
            //repeat forever

        }
    }


}
