using UnityEngine;
using UnityEngine.Assertions;

public class RotationalShooter : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private Collider2D userWeaponColl;
    [SerializeField] private Transform weaponRotationalPivot;
    [SerializeField] private Transform shootMuzzle;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    private float maxAngleDegress;
    private float lastShootTime = Mathf.NegativeInfinity;
    private Vector3 lastPointToLook;

    [Header("Particles")]
    [SerializeField] private ParticleSystem particleProjectileAmmo;

    private Vector3 UserWeaponCenterCollDirToAimPoint => lastPointToLook - userWeaponColl.bounds.center;
    private float TimeNextShoot => lastShootTime + weaponSO.CadencyTime;


    void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        maxAngleDegress = weaponSO.MaxAngleDegrees;
        weaponSpriteRenderer.sprite = weaponSO.Sprite;
        //TODO: think a more robuste way to get User component
        userWeaponColl = transform.root.GetComponent<Collider2D>();

        Assert.IsNotNull(userWeaponColl, "User Weapon Coll Cannot be null");

    }

    public void ProcessRotateGun(Vector3 pointToLook)
    {
        pointToLook.z = 0;
        if (pointToLook == lastPointToLook) return;

        var toPoint = pointToLook - transform.position;
        lastPointToLook = pointToLook;

        var angleDegrees = Vector3.SignedAngle(transform.right, toPoint, Vector3.forward);
        angleDegrees = Mathf.Clamp(angleDegrees, -maxAngleDegress * 0.5f, maxAngleDegress * 0.5f);

        UpdateGunFacing();

        weaponRotationalPivot.rotation = Quaternion.Euler(0, 0, angleDegrees);
    }

    private void UpdateGunFacing()
    {
        bool shouldFlip =
            (weaponSpriteRenderer.flipX && UserWeaponCenterCollDirToAimPoint.x >= 0)
            || (!weaponSpriteRenderer.flipX && UserWeaponCenterCollDirToAimPoint.x < 0);

        if (shouldFlip)
        {
            weaponSpriteRenderer.flipX = !weaponSpriteRenderer.flipX;

            var newLocalRotationDirByRotation = !weaponSpriteRenderer.flipX
                ? Quaternion.Euler(0, 0, 0)
                : Quaternion.Euler(0, 180, 0);

            shootMuzzle.SetLocalPositionAndRotation(
                new Vector3(shootMuzzle.localPosition.x * -1, shootMuzzle.localPosition.y),
                newLocalRotationDirByRotation
            );
        }
    }

    public void ShootProjectile()
    {
        if(Time.time <= TimeNextShoot) return;

        lastShootTime = Time.time;
        var projectile = Instantiate(weaponSO.ProjectileToShoot);
        projectile.transform.SetPositionAndRotation(shootMuzzle.position, shootMuzzle.rotation);
        projectile.Direction = shootMuzzle.right;
        if(particleProjectileAmmo != null)
        {
            particleProjectileAmmo.Play();

        }
    }
}
