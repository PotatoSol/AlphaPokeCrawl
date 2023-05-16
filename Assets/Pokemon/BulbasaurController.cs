using UnityEngine;
using PokeCrawl;
using System;
using System.Collections.Generic;

public class BulbasaurController : PokemonController{

    [Header("TackleSprites")]
    public Sprite northTackleSprite, northeastTackleSprite, eastTackleSprite, southeastTackleSprite, southTackleSprite, southwestTackleSprite, westTackleSprite, northwestTackleSprite;

    public BulbasaurController(){
        PokeTypes.Add(PokeType.Grass);
    }
}