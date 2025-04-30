using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 100f;
    
    public float damage = 10.0f;

    private Rigidbody2D rb;
    private GameObject player;
    public Stats stats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, 3f);
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

}
