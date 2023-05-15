using UnityEngine;
using System;

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
        Type = Type.Normal;
        Range = 1.9f;
    }

    //overloaded method that all moves should have
    public bool CheckRequirements(PokemonController InputUser, PokemonController InputTarget){ 
        
        if(!CheckDistance(InputUser, InputTarget)){ //if it's too far then leave
            return false;
        }
        MoveUser = InputUser;
        MoveTarget = InputTarget;
        DoMove();
    }

    public bool CheckDistance(PokemonController user, PokemonController target){
        if( Math.sqrt(((user.GetCoords()[0] - target.GetCoords()[0])^2) + (user.GetCoords[1] - target.GetCoords[1])^2 ) < Range) {
            return true;
        }
        else return false;
    }

    public float CalculateDamage(){
        //
        float CalcPower = Power;
        if(MoveUser.Type == this.Type){

        }
    }

    public void DoMove(){
        //Do the move
        CalculateDamage();
    }
}
