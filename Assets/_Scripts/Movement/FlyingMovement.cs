using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyingMovement : MonoBehaviour, IMovable
{
    private Rigidbody2D rb;

    [Header("Movement Params")]
    [SerializeField] private float maxSpeedX;
    public Vector2 Direction {get; private set;}
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input)
    {

        Direction = input.normalized;

    }

    void FixedUpdate()
    {
        var targetPosition = transform.position + maxSpeedX * Time.fixedDeltaTime * (Vector3)Direction;

        rb.MovePosition(targetPosition);
    }

}
