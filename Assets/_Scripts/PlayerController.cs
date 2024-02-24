using UnityEngine;

[RequireComponent(typeof(CharacterMovement2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private RotationalShooter rifleController;
    private CharacterMovement2D characterMovement;
    public static PlayerController PlayerReference {get; private set;}

    void Awake()
    {
        if(PlayerReference == null)
        {
            PlayerReference = this;
        }
        else
        {
            Destroy(gameObject);
        }

        characterMovement = GetComponent<CharacterMovement2D>();
    }

    void Update()
    {
        UpdateWeaponBehaviour();
        UpdateCharacterMovementBehaviour();
        
    }

    private void UpdateWeaponBehaviour()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rifleController.ShootProjectile();
        }
        
        var mouseScreenPosition = Input.mousePosition;
        var worldSpaceMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        rifleController.ProcessRotate(Vector3.forward, worldSpaceMousePosition);
    }

    private void UpdateCharacterMovementBehaviour()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        characterMovement.SetInput(new Vector2(horizontal, 0));
    }

    void OnDrawGizmos()
    {
        var mouseScreenPosition = Input.mousePosition;
        var worldSpaceMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Gizmos.DrawWireSphere(worldSpaceMousePosition, 6);

    }

}
