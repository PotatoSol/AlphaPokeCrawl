using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonController : MonoBehaviour
{
    private float _attack = .1f;
    private float _defense = .1f;
    private float _health = 10f;
    private float _speed = 0.25f;
    private float _x, _y;
    public Type[] Types = new Type[]{};

    private Move[] PossibleMoveList; //List of POSSIBLE moves used by the CURRENT pokemon instance
    //private Command[] CommandList; //List of POSSIBLE commands usable by the CURRENt pokemon
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
        Direction newDirection = (Direction)Random.Range(0, 8);
        Walk(newDirection);
    }

    //Handles updating the sprite based on what state the character is currently in
    private void UpdateSprite(){
        if (_currentCharacterState == CharacterState.Idle){
            UpdateIdleSprite(_currentDirection);
        }
    }

    private void UseMove(Move inputMove){
        if(inputMove.CheckRequirements);
    }

    private void UpdateIdleSprite(Direction newDirection) //is there a way to change this so that it can be reused for every animation
    {
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

    public float[] GetCoords(){
        return new float[]{_x, _y};
    }

    //=========================================================
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //assigns spriterenderer based on current object
        _x = transform.position.x; //sets coordinates of current object
        _y = transform.position.y; 
        InvokeRepeating("RandomlyChooseDirectionToMove", 1f, 0.5f); // Invoke RandomlyChooseDirectionToMove() every 0.2 seconds
    }
}
