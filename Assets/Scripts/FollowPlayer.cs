using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 4.0f;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }
}
