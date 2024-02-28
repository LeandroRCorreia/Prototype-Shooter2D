using UnityEngine;

[RequireComponent(typeof(CharacterMovement2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private RotationalShooter rifleController;
    private CharacterMovement2D characterMovement;
    private CharacterFacing2D characterFacing;
    private Collider2D coll;
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
        characterFacing = GetComponent<CharacterFacing2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        ProcessWeaponBehaviour();
        ProcessCharacterMovementBehaviour();
        
    }

    private void ProcessWeaponBehaviour()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rifleController.ShootProjectile();
        }

        var mouseScreenPosition = Input.mousePosition;
        var worldSpaceMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        var toMouseDir = (worldSpaceMousePosition - coll.bounds.center).normalized;
        characterFacing.UpdateFacing(toMouseDir.x);

        rifleController.ProcessRotateGun(worldSpaceMousePosition);
    }

    private void ProcessCharacterMovementBehaviour()
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
