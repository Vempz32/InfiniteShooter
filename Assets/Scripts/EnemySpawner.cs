using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]
   private GameObject enemy;

    [SerializeField]
   private float SpawnInterval = 3.5f;
    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnInterval, enemy));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
