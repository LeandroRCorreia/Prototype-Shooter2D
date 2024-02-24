using UnityEngine;

public class EnemyIAController : MonoBehaviour
{   

    [Header("Movement Params")]
    [Space]
    [SerializeField] private IMovable movable;

    [Header("Rotational Rifle Params")]
    [SerializeField] private RotationalShooter rotationalShooter;
    [SerializeField] private float timeBeetweenShoots = 0.25f;
    private float lastShootTime = 0f;
    private float NextShootTime => lastShootTime + timeBeetweenShoots;

    private Vector3 PlayerPosition => PlayerController.PlayerReference.transform.position;

    void Awake()
    {
        movable = GetComponent<IMovable>();

    }

    void Update()
    {
        UpdateMovementIA();
        UpdateWeaponBehaviours();
    }


    #region MovementIA

    private void UpdateMovementIA() 
    {
        if (movable != null)
        {
            UpdateMovementDirX();
            UpdateMovementDirY();

        }

    }

    private void UpdateMovementDirX()
    {
        var playerDir = (PlayerPosition - transform.position).normalized;
        if(Mathf.Abs(playerDir.x) > 0.5f)
        {
            movable.SetInput(new Vector2(playerDir.x, 0));

        }

    }

    private void UpdateMovementDirY()
    {
        
    }

    #endregion

    private void UpdateWeaponBehaviours()
    {
        rotationalShooter.ProcessRotate(Vector3.forward, PlayerController.PlayerReference.transform.position);
        if (Time.time >= NextShootTime)
        {
            lastShootTime = Time.time;
            rotationalShooter.ShootProjectile();

        }
    }

}
