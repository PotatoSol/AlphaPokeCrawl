using PokeCrawl;
using UnityEngine;

public class BasicCommand : ScriptableObject {
    //Gambit structure is 
    //IF [CONDITION] THEN [ACTION]

    PokemonController CommandOwner;

    BasicCondition ConditionStatement;

    Move PokemonMove;

    public BasicCommand(PokemonController inputOwner, BasicCondition inputStatement, Move inputMove){
        CommandOwner = inputOwner;
        ConditionStatement = inputStatement;
        PokemonMove = inputMove;
    }

    public string print(){ //debug commands
        return "wpoqmewlkr";
    }
    public bool IsValidCommand(){
        return ConditionStatement.CheckCondition();
    }

    public void DoCommand(){
        Debug.Log("executing DoCommand()");
        PokemonMove.CheckRequirements();
        PokemonMove.DoMove();
    }
}