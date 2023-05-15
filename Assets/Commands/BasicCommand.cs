using UnityEngine;

//this will be passed into the pokemon
//so it must be all encompassing
//therefore we need
//if "enemy" "is" "near" then "tackle"
//[target]
//[operator]
//[value]
//[move]
public class BasicCommand : MonoBehaviour {
    //Gambit structure is 
    //IF [CONDITION] THEN [ACTION]
    //so
    //something like [enemy] is [equality] [check]

    Owner Target;
    Operator CommandOperator;

    public BasicCommand(Owner inputTarget, Operator inputOperator){
        Target = inputTarget;
        CommandOperator = inputOperator;
    }

    public void CheckOperator(Owner inputTarget, Operator inputOperator){
        switch (CommandOperator){
            case Operator.opEqual:
            //do this if ==
            break;
            case Operator.opGreaterThanOrEqualTo:
            //do this if >=
            break;
            case Operator.opLessThanOrEqualTo:
            //do this if <=
            break;
            case Operator.opGreaterThan:
            //do this if >
            break;
            case Operator.opLessThan:
            //do this if <
            break;
            default:
            break;
        }
    }
}