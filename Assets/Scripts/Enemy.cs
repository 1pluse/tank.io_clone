using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    public Rigidbody2D target;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dirV = target.transform.position - gameObject.transform.position;
        Vector2 NextVec = dirV.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + NextVec);
        rigid.linearVelocity = Vector2.zero;
    }       
    private void LateUpdate()
    {
        Vector2 dirV = target.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dirV.y, dirV.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할
    }
}
