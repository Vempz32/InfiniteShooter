using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 4.0f;

    [SerializeField] private EnemyStats enemyStats;
    
    private GameObject player;
    [SerializeField] private GameObject speedUp;
    [SerializeField] private GameObject fireRateBoost;
 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        player.transform.position, Speed * Time.deltaTime);

        
    }

    private void OnTriggerEnter2D(Collider2D other)  
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);  
            Bullet bulletScript = other.GetComponent<Bullet>();

            if(bulletScript != null)
            {
                float playerDamage = bulletScript.damage;
                TakeDamage(playerDamage);
            }

            if(enemyStats.health <= 0)
            {
                Destroy(gameObject);
                DropPowerUp();
            }
        }
        
    }
    
    private void TakeDamage(float damageAmount)
    {
        enemyStats.health -= damageAmount;

    }
    
    private void DropPowerUp()
    {
        float randomValue = Random.Range(0f, 1f);
        float Threshold = 0.9f;

        if(randomValue > Threshold)
        {
            Debug.Log("PowerupDropped");
            Instantiate(speedUp, transform.position, Quaternion.identity);
        }

    } 
}
