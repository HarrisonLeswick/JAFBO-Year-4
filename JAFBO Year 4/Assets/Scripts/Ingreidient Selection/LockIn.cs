using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockIn : MonoBehaviour
{
    [SerializeField]
    private Sprite lockedSprite;

    [SerializeField]
    private Sprite unlockedSprite;

    public bool locked = false;

    public void LockUnlock()
    {
        locked = !locked;
        if(locked)
        {
            gameObject.GetComponent<Image>().sprite = lockedSprite;
            transform.GetComponentInParent<IngredientDisplay>().SetLockedIngredient();
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = unlockedSprite;
            transform.GetComponentInParent<IngredientDisplay>().IngredientUnlock();
        }
    }
}
