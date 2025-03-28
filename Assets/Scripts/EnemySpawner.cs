using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]
   private GameObject enemy;

    [SerializeField]
    private GameObject bossEnemy;
    void Start()
    {
        float SpawnInterval = Random.Range(1.0f, 5.0f);
        float bossInterval = Random.Range(30.0f, 60.0f);

        StartCoroutine(spawnEnemy(SpawnInterval, enemy));
        StartCoroutine(spawnBossEnemy(bossInterval, bossEnemy));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-16.9f, 16.9f), Random.Range(-5f, 5f), 0), Quaternion.identity);
            
            float nextInterval =  Random.Range(1.0f, 5.0f);
            }
        

       
    }

    private IEnumerator spawnBossEnemy(float interval, GameObject bossEnemy)
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            GameObject boss = Instantiate(bossEnemy, new Vector3(Random.Range(-16.9f, 16.9f), Random.Range(-5f, 5f), 0), Quaternion.identity);

            float bossNextInterval =  Random.Range(20.0f, 40.0f);
        }
    }
}
