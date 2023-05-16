using PokeCrawl;
public class Move
{
    public string Name { get; set; }
    public float Power { get; set; }
    public float Accuracy { get; set; } //despite being a float, keep values from 0-100, to 2 decimal places
    public PokeType ThisMoveType { get; set;}

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

    public bool CheckRequirements(){ //method for running the checks to see if this move is doable
        return false; //if the move is doable, return true - this is an empty base class so always return false since it should never work
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
