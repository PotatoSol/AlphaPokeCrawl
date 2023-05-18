using UnityEngine;

public class BasicCondition : ScriptableObject {

    public PokemonController conUser;
    public BasicCondition(PokemonController inputUser){
        conUser = inputUser;
    }

    public virtual bool CheckCondition(){
        return false;
    }
}