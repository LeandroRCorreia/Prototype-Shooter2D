using UnityEngine;

public class RotationalShooter : MonoBehaviour
{
    [Header("Weapon Data Params")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform launcherPivot;
    [SerializeField] private Projectile projectileToShoot;

    public void ProcessRotate(Vector3 rotationDir, Vector3 pointToLook)
    {
        var point = pointToLook - launcherPivot.position;
        Quaternion lookRotation = Quaternion.LookRotation(rotationDir, point);

        if(lookRotation != launcherPivot.rotation) launcherPivot.rotation = lookRotation;
    }

    public void ShootProjectile()
    {
        var projectile = Instantiate(projectileToShoot);
        projectile.transform.position = muzzle.position;
        projectile.Direction = launcherPivot.up;

    }

}
