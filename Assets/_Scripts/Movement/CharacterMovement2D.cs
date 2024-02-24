using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour, IMovable
{
    [SerializeField] private float maxSpeedX;
    private Rigidbody2D rb;
    private float directionX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input)
    {
        input.y = 0;
        directionX = input.x;

    }


    void FixedUpdate()
    {

        rb.velocity = new Vector2(directionX * maxSpeedX * Time.deltaTime, rb.velocity.y);


    }

}   
