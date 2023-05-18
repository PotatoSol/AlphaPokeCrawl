using System.Collections;
using System.Collections.Generic;
using PokeCrawl;
using UnityEngine;

public class PokemonController : MonoBehaviour
{
    private float _attack = .1f;
    private float _defense = .1f;
    private float _health = 10f;
    private float _speed = 0.25f;
    private float _x, _y;

    public PokemonController aggressionTarget; //lock onto a target

    private int directionAsInt = 0; //0 is north, 1 is northeast, 2 is east, etc.

    [SerializeField]
    private Animator animator; 

    //some variable for PowerPoints should be here, too lazy to implement right now
    public List<PokeType> PokeTypes = new List<PokeType>();

    //private Move[] PossibleMoveList; //List of POSSIBLE moves used by the CURRENT pokemon instance
    [SerializeField]
    public List<BasicCommand> CommandList = new List<BasicCommand>(); //List of POSSIBLE commands usable by the CURRENT pokemon
    //private Command[] Commands; //List of player-programmed commands assigned to this pokemon 

    private Owner pokeOwner = Owner.Wild;

    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Direction _currentDirection = Direction.South;

    [SerializeField]
    private CharacterState _currentCharacterState = CharacterState.Idle;

    // Sprites for each direction
    [Header("Sprites")]
    public Sprite northSprite, northeastSprite, eastSprite, southeastSprite, southSprite, southwestSprite, westSprite, northwestSprite;

    private void Walk(Direction movement){ //handles player MOVEMENT - pokemon 'moves' will be called abilities
        _currentDirection = movement;
        switch(movement){
            case Direction.North:
                _y += 1f * _speed;
                break;
            case Direction.NorthEast:
                _x += 1f * _speed;
                _y += 1f * _speed;
                break;
            case Direction.East:
                _x += 1f * _speed;
                break;
            case Direction.SouthEast:
                _y += -1f * _speed;
                _x += 1f * _speed;
                break;
            case Direction.South: 
                _y += -1f * _speed;
                break;
            case Direction.SouthWest: 
                _y += -1f * _speed;
                _x += -1f * _speed;
                break;
            case Direction.West:
                _x += -1f * _speed;
                break;
            case Direction.NorthWest:
                _y += 1f * _speed;
                _x += -1f * _speed;
                break;
            default:
                break;
        }

        // Set the new position of the player
        transform.position = new Vector2(_x, _y);

        // Update the sprite based on the current direction
        UpdateSprite();
    }

    private void RandomlyChooseDirectionToMove() //unnecessary now
    {
        // Randomly select a direction
        int randomNumber = Random.Range(0,8);
        directionAsInt = randomNumber;
        Direction newDirection = (Direction)randomNumber;

        Walk(newDirection);
    }

    //Handles updating the sprite based on what state the character is currently in
    private void UpdateSprite(){
        if (_currentCharacterState == CharacterState.Idle){
            UpdateIdleSprite(_currentDirection);
        }
    }

    private void UseMove(Move inputMove){
        if(inputMove.CheckRequirements()){
            //
        }
        //else
    }

    public Direction GetDirectionOfTarget(PokemonController target){ //0 is north, 1 is northeast, 2 is east, etc
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = target.transform.position;
        Vector2 directionVector = targetPosition - currentPosition;

        float angle = Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg;

        // Normalize the angle to a positive value between 0 and 360 degrees
        if (angle < 0)
        {
            angle += 360f;
        }

        // Calculate the direction based on the angle
        float sectorSize = 360f / 8f; // Divide the circle into 8 equal sectors (N, NE, E, SE, S, SW, W, NW)
        int sector = Mathf.RoundToInt(angle / sectorSize);
        Debug.Log("sector: " + sector);
        Direction direction;
        switch (sector)
        {
        case 0:
            direction = Direction.North;
            break;
        case 1:
            direction = Direction.NorthEast;
            break;
        case 2:
            direction = Direction.East;
            break;
        case 3:
            direction = Direction.SouthEast;
            break;
        case 4:
            direction = Direction.South;
            break;
        case 5:
            direction = Direction.SouthWest;
            break;
        case 6:
            direction = Direction.West;
            break;
        case 7:
            direction = Direction.NorthWest;
            break;
        default:
            direction = Direction.North; // Default to North if the angle doesn't fit into any sector
            break;
    }
        Debug.Log("Direction: " + direction);

        return direction;
    }
    public void SetAggressionTarget(PokemonController input){
        aggressionTarget = input;
    }
    private void UpdateIdleSprite(Direction newDirection) //is there a way to change this so that it can be reused for every animation
    {
        animator.SetTrigger("IsIdle");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        switch (newDirection)
        {
            case Direction.North:
                _spriteRenderer.sprite = northSprite;
                break;
            case Direction.NorthEast:
                _spriteRenderer.sprite = northeastSprite;
                break;
            case Direction.East:
                _spriteRenderer.sprite = eastSprite;
                break;
            case Direction.SouthEast:
                _spriteRenderer.sprite = southeastSprite;
                break;
            case Direction.South:
                _spriteRenderer.sprite = southSprite;
                break;
            case Direction.SouthWest:
                _spriteRenderer.sprite = southwestSprite;
                break;
            case Direction.West:
                _spriteRenderer.sprite = westSprite;
                break;
            case Direction.NorthWest:
                _spriteRenderer.sprite = northwestSprite;
                break;
        }
    }

    public void PlayAttackAnimation(){
        Debug.Log("attacking!");
        animator.ResetTrigger("IsIdle");
        switch (GetDirectionOfTarget(aggressionTarget))
        {
            case Direction.North:
                directionAsInt = 0;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("NorthAttackTrigger"); 
                break;
            case Direction.NorthEast:
                directionAsInt = 1;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("NorthEastAttackTrigger");
                break;
            case Direction.East:
                directionAsInt = 2;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("EastAttackTrigger");
                break;
            case Direction.SouthEast:
                directionAsInt = 3;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("SouthEastAttackTrigger");
                break;
            case Direction.South:
                directionAsInt = 4;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("SouthAttackTrigger");
                break;
            case Direction.SouthWest:
                directionAsInt = 5;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("SouthWestAttackTrigger");
                break;
            case Direction.West:
                directionAsInt = 6;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("WestAttackTrigger");
                break;
            case Direction.NorthWest:
                directionAsInt = 7;
                animator.SetTrigger("IsAttacking");
                //animator.SetTrigger("NorthWestAttackTrigger");
                break;
        }
    }

    public float[] GetCoords(){
        Vector3 currentPos = transform.position;
        return new float[]{currentPos.x, currentPos.y};
    }

    public float GetDistanceTo(PokemonController targetPokemon){
        float returnAmount = Mathf.Sqrt(Mathf.Pow(this.GetCoords()[0] - targetPokemon.GetCoords()[0], 2) + Mathf.Pow(this.GetCoords()[1] - targetPokemon.GetCoords()[1], 2));
        return returnAmount;
    }

    public void GoThroughCommands(){
        bool commandDone = false;
        foreach (BasicCommand aCommand in CommandList){
            if(aCommand == null){
                Debug.Log("aCommand is null!");
                return;
            }
            if(aCommand.IsValidCommand()){
                aCommand.DoCommand();
                commandDone = true;
            } 
        }
        if(commandDone == false){
            RandomlyChooseDirectionToMove();
        }
    }

    public virtual void DoSetUp(){
        //to be overloaded 
    }

    //=========================================================
    // Start is called before the first frame update
    void Start()
    {
        this.DoSetUp();
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); //assigns spriterenderer based on current object
        _x = transform.position.x; //sets coordinates of current object
        _y = transform.position.y; 

        animator.SetInteger("Direction", directionAsInt);
        InvokeRepeating("GoThroughCommands", 3f, 1f); // Invoke RandomlyChooseDirectionToMove() every 1.1 seconds
    }

    void Update(){
        animator.SetInteger("Direction", directionAsInt);
        _x = transform.position.x; //sets coordinates of current object
        _y = transform.position.y; 

    }
}
