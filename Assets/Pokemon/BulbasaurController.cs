using UnityEngine;
using PokeCrawl;
using System;
using System.Collections.Generic;

public class BulbasaurController : PokemonController{

    [Header("TackleSprites")]
    public Sprite northTackleSprite, northeastTackleSprite, eastTackleSprite, southeastTackleSprite, southTackleSprite, southwestTackleSprite, westTackleSprite, northwestTackleSprite;

    public BulbasaurController(){

    }

    public override void DoSetUp(){
        base.DoSetUp();
        PokeTypes.Add(PokeType.Grass);
        AdjacentCondition newAdjCondition = new AdjacentCondition(this);
        newAdjCondition.CheckCondition();//simply gets the first pokemon in the list that's close...might need to fix this
        TackleMove newTackleMove = new TackleMove();
        newTackleMove.MoveUser = this;
        newTackleMove.MoveTarget = newAdjCondition.conTarget;
        newAdjCondition.conMove = newTackleMove;
        BasicCommand TackleAdjacentPokemonCommand = new BasicCommand(this, newAdjCondition, newTackleMove);
        Debug.Log("CommandList count:");//delete
        Debug.Log(CommandList.Count);//delete
        Debug.Log("Adding to command list...."); //delete
        CommandList.Add(TackleAdjacentPokemonCommand);
        Debug.Log(CommandList[0]);
        Debug.Log(TackleAdjacentPokemonCommand);
    }

    void Start(){
        DoSetUp();

        InvokeRepeating("GoThroughCommands", 1f, 0.5f);
    }

    //need some method to do an animation
}