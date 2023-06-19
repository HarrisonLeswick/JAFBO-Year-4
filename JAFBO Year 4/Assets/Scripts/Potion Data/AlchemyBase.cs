using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//these are some fun classes that i'm grouping under this namespace
namespace Alchemy
{
    //ingredients will be a liquid, solid, or magic, ignore the last one
    [Serializable]
    public enum IngredientSubclass
    {
        Liquid,
        Solid,
        Magic, 
        nullINGRED
    }

    //basically how fast the cauldron will boil in units per second
    //vi has not defined anything for me beyond Easy
    [Serializable]
    public enum PotionDifficulty
    {
        Easy = 3,

    }


    //actual ingredients
    //any item in the game that can go in a potion will be one of these
    [Serializable]
    public class Ingredients
    {
        //eg: "Milk" "Salt" "PoisonIvy"
        public string iD;
        //liquid, solid, or magic
        public IngredientSubclass subclass;
        //we're gonna do the filepath instead of the sprite itself for EVIL REASONS LATER dw bout it
        //hint: loading
        public string spriteFilePath;
    }

    [Serializable]
    public class Recipe
    {
        public string commonPotionName;
        public string accessKey;

        public Ingredients liquid;
        public Ingredients solid;
        public Ingredients magic;

        public PotionDifficulty boilRate;

        public List<IngredientSubclass> ingredientOrder;

        //we need to add more shit (obviously)
        //this is unfortunately just the beginning
        //but if we want to *make* a potion that just exists, this is where we will start 
        
    }
}




