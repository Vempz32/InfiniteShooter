using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private float speedX, speedY;

    private Vector2 mousePos;
    private float fireTimer;

    // Gun variables
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;

    Rigidbody2D rb;
    private Camera camera;

    [SerializeField] private Stats stats;
    [SerializeField] private GameManager gameManager;

    private Coroutine regenRoutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        Debug.Log(stats.health);
    }

    void FixedUpdate()
    {
        speedX = Input.GetAxis("Horizontal") * stats.movementSpeed;
        speedY = Input.GetAxis("Vertical") * stats.movementSpeed;;

        rb.linearVelocity = new Vector2(speedX, speedY);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Handle shooting
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = stats.fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
      
        PreventLeavingScreen();
    }

    private void Shoot()
    {
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
    }

    private void PreventLeavingScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        Vector2 worldBottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 worldTopRight = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 0));

        // Restrict the player's movement on the left and right
        if (screenPosition.x < 0 && rb.linearVelocity.x < 0 || screenPosition.x > camera.pixelWidth && rb.linearVelocity.x > 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); 
        }

        // Restrict the player's movement on the top and bottom
        if (screenPosition.y < 0 && rb.linearVelocity.y < 0 || screenPosition.y > camera.pixelHeight && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyScript = other.GetComponent<EnemyStats>();

            
            if(enemyScript != null)
            {
                float enemyDamage = enemyScript.damage;
                TakeDamage(enemyDamage);
            }
        }
        // if the players health is 0 hide it 
        if(stats.health <= 0)
        {
            gameObject.SetActive(false);

            //Destroying enemy once game ends
            if(other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }

            // stopping the game
            Time.timeScale = 0f;
            gameManager.GameOverScreen();
        }

        if(other.gameObject.CompareTag("LootBox"))
        {
            gameManager.LootBoxScreenOn();
            Destroy(other.gameObject);
        }
    }
    private void TakeDamage(float damageAmount)
    {
        stats.health -= damageAmount;
         Debug.Log("Player took damage! Health: " + stats.health);
    }
    public void StartHealthRegen()
    {
        if (regenRoutine == null)
        {
            regenRoutine = StartCoroutine(RegenHealth());
        }
    }

    private IEnumerator RegenHealth()
    {
        while(stats.health < stats.maxHealth)
        {
            stats.health += stats.healthRegen * Time.deltaTime;
            stats.health = Mathf.Min(stats.health, stats.maxHealth);
            yield return null;
        }
        regenRoutine = null;
    }
}
