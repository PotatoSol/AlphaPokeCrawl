using UnityEngine;

public class AdjacentCondition : BasicCondition{
    public PokemonController conTarget; //conditional target
    public PokemonController conUser; //conditional user

    public Move conMove; //the move that is being checked
    public AdjacentCondition(PokemonController inputUser){
        SetUser(inputUser);
    }

    public void SetUser(PokemonController inputUser){
        conUser = inputUser;
    }

    public void SetTarget(PokemonController inputTarget){
        conTarget = inputTarget;
    }

    public bool CheckCondition(){
        PokemonController[] allPokemon = FindObjectsOfType<PokemonController>();
        foreach (PokemonController aPokemon in allPokemon){
            if(aPokemon != conUser && conUser.GetDistanceTo(aPokemon) <= 1.9f){
                conTarget = aPokemon;
                return true;
            }
        }
        return false; //returns false if iterates through all available pokemon and doens't find one close
    }

}