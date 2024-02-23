using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement2D : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float maxSpeedX;
    private float directionX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(float horizontal)
    {

        directionX = horizontal;
        

    }


    void FixedUpdate()
    {

        rb.velocity = new Vector2(directionX * maxSpeedX * Time.fixedDeltaTime, rb.velocity.y);


    }

}   
