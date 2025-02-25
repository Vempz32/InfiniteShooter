using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 100f;

    [Range(1, 10)]
    [SerializeField] private float lifetime = 3f;

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    private void FixedUpdate() {
        rb.linearVelocity = transform.up * speed;
    }

    // To delete when the bullet hits enemy 
    /*private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
    }
*/
}
