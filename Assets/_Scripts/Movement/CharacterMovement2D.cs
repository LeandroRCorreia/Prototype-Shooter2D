using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour, IMovable
{
    [SerializeField] private float maxSpeedX;
    private Rigidbody2D rb;

    public Vector2 Direction {get; private set;}

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input)
    {
        input.y = 0;
        Direction = input;

    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(Direction.x * maxSpeedX * Time.deltaTime, rb.velocity.y);

    }

}   
