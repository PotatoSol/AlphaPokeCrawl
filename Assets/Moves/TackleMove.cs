using UnityEngine;
using System;
using PokeCrawl;

public class TackleMove : Move
{
    //a move should have methods to return damage done, what animation to use, if the move is valid to use, etc
    public float Range { get; set; }
    public PokemonController MoveUser { get; set;}
    public PokemonController MoveTarget { get; set;}

    public TackleMove() 
    {
        Name = "Tackle";
        Power = 10f;
        Accuracy = 100f;
        ThisMoveType = PokeType.Normal;
        Range = 1.9f;
    }

    //overridden method that all moves should have
    public override bool CheckRequirements(){ 

        if(MoveUser == null){
            Debug.Log("NO MOVEUSER");
            return false;
        }
        if(MoveTarget == null){
            Debug.Log("NO MOVETARGET");
            return false;
        }
        //check the distance, then check if the target.....is....
        if(!CheckDistance(MoveUser, MoveTarget)){ //if it's too far then leave
            return false;
        }
        DoMove();

        return true;
    }

    public bool CheckDistance(PokemonController user, PokemonController target){
        if (Math.Sqrt(Math.Pow(user.GetCoords()[0] - target.GetCoords()[0], 2) + Math.Pow(user.GetCoords()[1] - target.GetCoords()[1], 2)) < Range){
            return true;
        } else { return false; }
    }


    public float CalculateDamage(){
        //
        float CalcPower = Power;
        if(MoveUser.PokeTypes.Contains((PokeType) this.ThisMoveType)){
            //do something
        }
        return 1.0f;
    }

    public override void DoMove(){
        //Do the move
        CalculateDamage();
    }
}
