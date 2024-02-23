using UnityEngine;

[RequireComponent(typeof(CharacterMovement2D))]
public class PlayerController : MonoBehaviour
{

    CharacterMovement2D characterMovement;


    [Header("Weapon Data Params")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform riflePivot;
    [SerializeField] private Projectile projectileToShoot;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement2D>();
    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        UpdateGunBehaviour();

        characterMovement.SetInput(horizontal);
    }

    private void UpdateGunBehaviour()
    {
        Debug.Log(muzzle.position);
        ProcessRotateRifle();
        if (Input.GetMouseButtonDown(0))
        {
            SpawnShoot();
        }
    }

    private void ProcessRotateRifle()
    {
        var mouseScreenPosition = Input.mousePosition;
        var worldSpaceMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        var toMouseScreenPosition = worldSpaceMousePosition - riflePivot.position;

        ProcessRotateWeapon(toMouseScreenPosition);
    }

    private void ProcessRotateWeapon(Vector3 rotateToThisVector)
    {
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, rotateToThisVector);

        if(lookRotation != riflePivot.rotation) riflePivot.rotation = lookRotation;
    }

    private void SpawnShoot()
    {
        var projectile = Instantiate(projectileToShoot);
        projectile.transform.position = muzzle.position;
        projectile.Direction = riflePivot.up;

    }

    void OnDrawGizmos()
    {
        var mouseScreenPosition = Input.mousePosition;
        var worldSpaceMousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Gizmos.DrawWireSphere(worldSpaceMousePosition, 6);

    }

}
