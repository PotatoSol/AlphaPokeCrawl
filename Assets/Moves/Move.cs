using PokeCrawl;
public class Move
{
    public string Name { get; set; }
    public float Power { get; set; }
    public float Accuracy { get; set; } //despite being a float, keep values from 0-100, to 2 decimal places
    public PokeType ThisMoveType { get; set;}

    public float Range { get; set; }

    public PokemonController MoveTarget { get; set;}

    public PokemonController MoveUser { get; set;}


    public Move(){
        Name = "Struggle";
        Power = 1f;
        Accuracy = 100f;
        ThisMoveType = PokeType.Normal;
    }

    public Move(string name, float power, float accuracy, PokeType thisMoveType)
    {
        Name = name;
        Power = power;
        Accuracy = accuracy;
        ThisMoveType = thisMoveType;
    }

    public float GetDamageModifier(){
        float returnMod = 1.0f;
        if(MoveUser == null || MoveTarget == null || ThisMoveType == null){
            return returnMod;
        }
        if(MoveUser.PokeTypes.Contains(ThisMoveType)){
            returnMod *= 2.0f;
        }

        //Each If statement is separate so that it the target can have multiple types
        //There has to be a better way to do this, but whatever itll work
        //NORMAL TYPE MOVES
        if(ThisMoveType == PokeType.Normal){
            if(MoveTarget.PokeTypes.Contains(PokeType.Ghost)){
                return 0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Rock)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Steel)){
                returnMod *= 0.5f;
            }
        }

        //FIRE TYPE MOVES
        if(ThisMoveType == PokeType.Fire){
            if(MoveTarget.PokeTypes.Contains(PokeType.Fire)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Water)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Grass)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Ice)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Bug)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Rock)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Dragon)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Steel)){
                returnMod *= 2.0f;
            }
        }

        //WATER TYPE MOVES
        if(ThisMoveType == PokeType.Water){
            if(MoveTarget.PokeTypes.Contains(PokeType.Fire)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Water)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Grass)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Ground)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Rock)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Dragon)){
                returnMod *= 0.5f;
            }
        }

        //GRASS TYPE MOVES
        if(ThisMoveType == PokeType.Grass){
            if(MoveTarget.PokeTypes.Contains(PokeType.Fire)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Water)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Poison)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Ground)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Flying)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Bug)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Rock)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Dragon)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Steel)){
                returnMod *= 0.5f;
            }
        }

        //ELECTRIC TYPE MOVES
        if(ThisMoveType == PokeType.Electric){
            if(MoveTarget.PokeTypes.Contains(PokeType.Water)){
                returnMod *= 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Grass)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Electric)){
                returnMod *= 0.5f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Ground)){
                return 0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Flying)){
                return 2.0f;
            }
            if(MoveTarget.PokeTypes.Contains(PokeType.Dragon)){
                return 0.5f;
            }
        }



        
        return returnMod; 
    }

    public virtual bool CheckRequirements(){ //method for running the checks to see if this move is doable
        return false; //if the move is doable, return true - this is an empty base class so always return false since it should never work
    }

    public virtual void DoMove(){
        //empty method to be overloaded
    }
    /*
    public virtual void DoMove(PokemonController attacker, PokemonController defender)
    {
        // Default move behavior goes here
        int damage = CalculateDamage(attacker, defender);
        defender.TakeDamage(damage);
        PP--;
    }

    protected int CalculateDamage(PokemonController attacker, PokemonController defender)
    {
        // Calculate damage based on the attacker's stats, the move's power, and the defender's defenses
        return Power * attacker.Attack / defender.Defense;
    }
    */
    // Methods to handle odd effects can be added here
}
