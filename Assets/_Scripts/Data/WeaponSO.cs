using UnityEngine;

[CreateAssetMenu(menuName = "Prototype_Arrow_And_Enemy/WeaponSO")]
public class WeaponSO : ScriptableObject
{

    [SerializeField] private Projectile projectileToShoot;
    [SerializeField] private float maxAngleDegress = 60;
    [SerializeField] private Sprite sprite;
    [SerializeField] [Range(0.1f, 5f)] private float cadencyTime = 1f;

    public Projectile ProjectileToShoot
    {
        get { return projectileToShoot; }
    }

    public float MaxAngleDegrees
    {
        get { return maxAngleDegress; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
    }

    public float CadencyTime
    {
        get {return cadencyTime;}
    }

}
