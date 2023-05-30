using UnityEngine;
using System;
using PokeCrawl;

public class TackleMove : Move
{
    public TackleMove() 
    {
        Name = "Tackle";
        Power = 40f;
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
        double distanceBetween = Math.Sqrt(Math.Pow(user.GetCoords()[0] - target.GetCoords()[0], 2) + Math.Pow(user.GetCoords()[1] - target.GetCoords()[1], 2));
        if (distanceBetween < Range){
            Debug.Log("Within distance!");
            return true;
        } else { 
            Debug.Log("Too far!");
            return false; 
        }
    }

    public override float CalculateDamage(){
        float LEVEL = MoveUser._level;
        float POWER = Power;
        float ATTACK = MoveUser._attack;
        float DEFENSE = MoveTarget._defense;
        float CRITICAL;
        System.Random rng = new System.Random();
        if(rng.NextDouble() > .9){
            CRITICAL = 1.5f;
        } else { CRITICAL = 1.0f; }
        float RANDOM = (float) (rng.NextDouble() * (1.0 - 0.85) + 0.85);
        float CalcPower = (((((((2 * LEVEL) / 5 ) + 2 ) * POWER * (ATTACK / DEFENSE)) / 50) + 2) * CRITICAL * RANDOM );

        //RANDOM = Random multiplier between .85 and 1, rounded down to nearest int
        return CalcPower;
    }

    public override void DoMove(){
        //Do the move
        float storeDamage = CalculateDamage();
        Debug.Log(storeDamage);
        MoveTarget._health -= storeDamage;
        //Time.timeScale = 0;
    }
}
