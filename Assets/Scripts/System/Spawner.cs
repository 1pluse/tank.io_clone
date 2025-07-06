using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    float time;
    public float Spawntime;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > Spawntime) {
            time = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.poolManager.Get(Random.Range(0,2));
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
    }
}
