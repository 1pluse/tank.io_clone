using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float LifeTime;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        direction.z = 0;
        direction.Normalize();
        rigid.linearVelocity = direction * BulletSpeed;
    }

    private void Update()
    {
        float time = 0;
        time += Time.deltaTime;
        if (time >= LifeTime) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
