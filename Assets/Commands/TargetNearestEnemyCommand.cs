using UnityEngine;
using PokeCrawl;
public class TargetNearestEnemyCommand : BasicCommand{

    Owner Target;
    Operator CommandOperator;

    public TargetNearestEnemyCommand(Owner inputTarget, Operator inputOperator) : base(inputTarget, inputOperator){
        Target = inputTarget;
        CommandOperator = inputOperator;
    }

    public void CheckOwner(){

    }
}