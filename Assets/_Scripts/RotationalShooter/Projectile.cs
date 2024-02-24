using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float lifeTime = 10f;



    private float startSpawnTime;
    public Vector3 Direction {get; set;}

    private float EndLifeTime => startSpawnTime + lifeTime;
    
    void Start()
    {
        startSpawnTime = Time.time;
    }

    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * Direction;
        if(Time.time >= EndLifeTime)
        {
            Destroy(gameObject);

        }
    }





}
