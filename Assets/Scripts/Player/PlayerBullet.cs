using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float BulletSpeed;
    [SerializeField] float LifeTime;
    public float Damage;
    float time;
    Rigidbody2D rigid;
    [SerializeField] GameObject Effect;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (MousePosition - transform.position).normalized;
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
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(Damage);
            Instantiate(Effect, transform.position, Quaternion.identity);
            
        }
    }
}
