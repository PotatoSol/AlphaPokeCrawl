using UnityEngine;

public class BasicCondition : MonoBehaviour {

    public PokemonController conUser;
    public BasicCondition(PokemonController inputUser){
        conUser = inputUser;
    }

    public bool CheckCondition(){
        return false;
    }
}