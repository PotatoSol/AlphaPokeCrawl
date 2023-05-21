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


    //Todo: Research Hashmaps more and recreate this using hashmaps.
    public float GetDamageModifier(){
        float returnMod = 1.0f;
        if(MoveUser == null || MoveTarget == null || ThisMoveType == null){
            return returnMod;
        }
        if(MoveUser.PokeTypes.Contains(ThisMoveType)){
            returnMod *= 2.0f;
        }

        foreach (PokeType targetType in MoveTarget.PokeTypes){
            //NORMAL TYPE MOVES
            if(ThisMoveType == PokeType.Normal){
                if(targetType == PokeType.Ghost){
                    return 0;
                } else if(targetType == PokeType.Rock || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                }
            }

            //FIRE TYPE MOVES
            if(ThisMoveType == PokeType.Fire){
                if(targetType == PokeType.Grass || targetType == PokeType.Ice || targetType == PokeType.Bug || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                } else if(targetType == PokeType.Fire || targetType == PokeType.Water || targetType == PokeType.Rock || targetType == PokeType.Dragon){
                    returnMod *= 2.0f;
                }
            }

            //WATER TYPE MOVES
            if(ThisMoveType == PokeType.Water){
                if(targetType == PokeType.Water || targetType == PokeType.Grass || targetType == PokeType.Dragon){
                    returnMod *= 0.5f;
                } else if(targetType == PokeType.Fire || targetType == PokeType.Ground || targetType == PokeType.Rock){
                    returnMod *= 2.0f;
                }
            }

            //GRASS TYPE MOVES
            if(ThisMoveType == PokeType.Grass){
                if(targetType == PokeType.Fire || targetType == PokeType.Grass || targetType == PokeType.Poison || targetType == PokeType.Flying || targetType == PokeType.Bug || targetType == PokeType.Dragon || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                } else if(targetType == PokeType.Water || targetType == PokeType.Ground || targetType == PokeType.Rock){
                    returnMod == 2.0f;
                }
            }

            //ELECTRIC TYPE MOVES
            if(ThisMoveType == PokeType.Electric){
                if(targetType == PokeType.Ground){
                    return 0;
                } else if(targetType == PokeType.Grass || targetType == PokeType.Electric || targetType == PokeType.Dragon){
                    returnMod *= 0.5f;
                } else if(targetType == PokeType.Water || targetType == PokeType.Flying){
                    returnMod *= 2.0f;
                }
            }

            //ICE TYPE MOVES
            if(ThisMoveType == PokeType.Ice){
                if(targetType == PokeType.Fire || targetType == PokeType.Water || targetType == PokeType.Ice || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Grass || targetType == PokeType.Ground || targetType == PokeType.Flying || targetType == PokeType.Dragon){
                    returnMod *= 2.0f;
                }
            }

            //FIGHTING TYPE MOVES
            if(ThisMoveType == PokeType.Fighting){
                if(targetType == PokeType.Ghost){
                    return 0;
                } else if(targetType == PokeType.Poison || targetType == PokeType.Flying || targetType == PokeType.Psychic || targetType == PokeType.Bug || targetType == PokeType.Fairy){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Normal || targetType == PokeType.Ice || targetType == PokeType.Rock || targetType == PokeType.Dark || targetType == PokeType.Steel){
                    returnMod *= 2.0f;
                }
            }

            //POISON TYPE MOVES
            if(ThisMoveType == PokeType.Poison){
                if(targetType == PokeType.Steel){
                    return 0;
                } else if(targetType == PokeType.Poison || targetType == PokeType.Ground || targetType == PokeType.Rock || targetType == PokeType.Ghost){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Grass || targetType == PokeType.Fairy){
                    returnMod *= 2.0f;
                }
            }

            //GROUND TYPE MOVES
            if(ThisMoveType == PokeType.Ground){
                if(targetType == PokeType.Flying){
                    return 0;
                } else if (targetType == PokeType.Grass || targetType == PokeType.Bug){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Fire || targetType == PokeType.Electric || targetType == PokeType.Poison || targetType == PokeType.Rock || targetType == PokeType.Steel){
                    returnMod *= 2.0f;
                }
            }

            //FLYING TYPE MOVES
            if(ThisMoveType == PokeType.Flying){
                if(targetType == PokeType.Electric || targetType == PokeType.Rock || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Grass || targetType == PokeType.Fighting || targetType == PokeType.Bug){
                    returnMod *= 2.0f;
                }
            }

            //PSYCHIC TYPE MOVES
            if(ThisMoveType == PokeType.Psychic){
                if(targetType == PokeType.Dark){
                    return 0.f;
                } else if(targetType == PokeType.Psychic || targetType == PokeType.Steel){
                    returnMod *= 0.5f;
                } else if(targetType == PokeType.Fighting || targetType == PokeType.Poison){
                    returnMod *= 2.0f;
                }
            }

            //BUG TYPE MOVES
            if(ThisMoveType == PokeType.Bug){
                if(targetType == PokeType.Fire || targetType == PokeType.Fighting || targetType == PokeType.Poison || targetType == PokeType.Flying || targetType == PokeType.Ghost || targetType == PokeType.Steel || targetType == PokeType.Fairy){
                    returnMod *= 0.5f;
                } else if (targetType == PokeType.Grass || targetType == PokeType.Psychic || targetType == PokeType.Dark){
                    returnMod *= 2.0f;
                } 
            }

            //ROCK TYPE MOVES
            
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
