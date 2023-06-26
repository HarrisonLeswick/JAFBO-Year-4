using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour
{
    [SerializeField]
    private Image render;

    [SerializeField]
    private List<Sprite> sprites;

    private int lockedIngredient;
    

    private SelectionButtons buttons;

    private void Start() {
        buttons = gameObject.GetComponent<SelectionButtons>();
    }

    public void AddIngredient(Sprite image)
    {
        sprites.Add(image);
        buttons.SetMaxSelections(sprites.Count);
    }

    public void ClearIngredients()
    {
        sprites.Clear();
        buttons.SetMaxSelections(sprites.Count);
    }

    public void UpdateSprite()
    {
        if(!transform.GetComponentInChildren<LockIn>().locked)
        {
            render.sprite  = sprites[buttons.currentSelection];
        }
        
    }

    public void SetLockedIngredient()
    {
        lockedIngredient = buttons.currentSelection;
    }

    public void IngredientUnlock()
    {
        buttons.currentSelection = lockedIngredient;
    }
}




//MAKE IT SO IF CHOICE IS LOCKED YOU CAN'T MOVE SELECTIONS ANYMORE
