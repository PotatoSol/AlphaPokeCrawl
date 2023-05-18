using UnityEngine;

public class AdjacentCondition : BasicCondition
{
    public PokemonController conTarget; // Conditional target


    public Move conMove; // The move that is being checked

    public AdjacentCondition(PokemonController inputUser) : base(inputUser){
        conUser = inputUser;
    }

    public void SetTarget(PokemonController inputTarget){
        conTarget = inputTarget;
    }

    public override bool CheckCondition(){
        PokemonController[] allPokemon = FindObjectsOfType<PokemonController>();
        foreach (PokemonController aPokemon in allPokemon){
            if (aPokemon != conUser && conUser.GetDistanceTo(aPokemon) <= 1.9f){
                conTarget = aPokemon;
                return true;
            }
        }
        return false; // Returns false if it iterates through all available pokemon and doesn't find one close
    }
}
