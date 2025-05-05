using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float LifeTime;
    float time;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        rigid.linearVelocity = direction * BulletSpeed;
    }

    private void Update()
    {
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
