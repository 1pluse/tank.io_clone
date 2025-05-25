using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float BulletSpeed;
    [SerializeField] float LifeTime;
    float time;
    Rigidbody2D rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Transform plyerPosition = GameManager.instance.player.transform;
        Vector3 direction = (plyerPosition.position - transform.position).normalized;
        direction.z = 0;
        direction.Normalize();
        rigid.linearVelocity = direction * BulletSpeed;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > LifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
