using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 100f;



    public float damage = 10.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;  
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    
}
