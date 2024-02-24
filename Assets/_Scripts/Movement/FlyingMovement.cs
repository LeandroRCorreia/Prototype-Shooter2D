using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyingMovement : MonoBehaviour, IMovable
{
    private Rigidbody2D rb;

    [Header("Movement Params")]
    [SerializeField] private float maxSpeedX;

    private Vector3 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input)
    {

        dir = input.normalized;

    }

    void FixedUpdate()
    {
        var targetPosition = transform.position + maxSpeedX * Time.fixedDeltaTime * dir;

        rb.MovePosition(targetPosition);
    }

}
