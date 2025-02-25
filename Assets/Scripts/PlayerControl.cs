using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    private float speedX, speedY;

    private Vector2 mousePos;

    private float fireTimer;

    //Gun variables
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;

    [Range (0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    Rigidbody2D rb;
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * moveSpeed;
        speedY = Input.GetAxis("Vertical") * moveSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x -
        transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0,0, angle);

        if(Input.GetMouseButton(0)&& fireTimer <= 0f ){
            Shoot();
            fireTimer = fireRate;
        }else{
            fireTimer -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
    }
}
