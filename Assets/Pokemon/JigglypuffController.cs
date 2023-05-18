using UnityEngine;
using PokeCrawl;
using System;
using System.Collections.Generic;

//**ALERT** HARD COPIED FROM BULBASAUR - MAKE NECESSARY ADJUSTMENTS

public class JigglypuffController : PokemonController{

    public Sprite northTackleSprite, northeastTackleSprite, eastTackleSprite, southeastTackleSprite, southTackleSprite, southwestTackleSprite, westTackleSprite, northwestTackleSprite;

    public JigglypuffController(){

    }

    public override void DoSetUp(){
        CommandList = new List<BasicCommand>(); //I do not know why, but theres a null object added if i do not do this.  
        base.DoSetUp();
        PokeTypes.Add(PokeType.Grass);
        AdjacentCondition newAdjCondition = new AdjacentCondition(this);
        newAdjCondition.CheckCondition();//simply gets the first pokemon in the list that's close...might need to fix this
        TackleMove newTackleMove = new TackleMove();
        newTackleMove.MoveUser = this;
        newTackleMove.MoveTarget = newAdjCondition.conTarget;
        newAdjCondition.conMove = newTackleMove;
        BasicCommand TackleAdjacentPokemonCommand = new BasicCommand(this, newAdjCondition, newTackleMove);
        CommandList.Add(TackleAdjacentPokemonCommand);
    }

    void Start(){
        DoSetUp();

        InvokeRepeating("GoThroughCommands", 1f, 0.5f);
    }

    //need some method to do an animation
}