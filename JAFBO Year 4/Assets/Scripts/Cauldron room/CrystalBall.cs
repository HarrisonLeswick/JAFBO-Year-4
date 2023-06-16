using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : MonoBehaviour
{
    [SerializeField]
   private SpriteRenderer spriteRenderer;

   public List<Sprite> sprites;

   private int currentItem;

    [SerializeField]
   private float waitTime = 2;

   private IEnumerator showRecipe;

    void Start() {

        showRecipe = ShowRecipe();
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.gameObject.SetActive(true);
            StartCoroutine(showRecipe);
        }   
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.gameObject.SetActive(false);
            StopAllCoroutines();
            currentItem = 0;
        }
    }

    public void ClearSprites()
    {
        sprites.Clear();
    }

    public void AddSprite(Sprite sprite)
    {
        sprites.Add(sprite);
    }

    IEnumerator ShowRecipe()
    {
        
        while(true)
        {
            if(currentItem >= sprites.Count)
            {
                currentItem = 0;
            }
            spriteRenderer.sprite = sprites[currentItem];
            currentItem++;
            yield return new WaitForSeconds(waitTime);

        }
    }


}
