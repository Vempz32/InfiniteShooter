using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    private float speedX, speedY;

    private Vector2 mousePos;
    private float fireTimer;

    // Gun variables
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;

    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    Rigidbody2D rb;

    private Camera camera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void FixedUpdate()
    {
       
        speedX = Input.GetAxis("Horizontal") * moveSpeed;
        speedY = Input.GetAxis("Vertical") * moveSpeed;

        
        rb.linearVelocity = new Vector2(speedX, speedY);

       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Handle shooting
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
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
}
