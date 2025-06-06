using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float AttackDistance;
    public float MaxHp;
    float CurrentHp;
    Transform target;
    Rigidbody2D rigid;

    [SerializeField] SliderManager healthbar;

    public bool AttackState;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<SliderManager>();
    }

    private void Start()
    {
        CurrentHp = MaxHp;
        healthbar.HealthControll(CurrentHp, MaxHp);
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        healthbar.HealthControll(CurrentHp,MaxHp);
    }
    private void FixedUpdate()
    {
        float currentDistance = Vector2.Distance(target.position, transform.position);
        if (currentDistance <= AttackDistance)
        {
            AttackState = true;
        }
        else
        {
            AttackState = false;
        }

        if (AttackState)
            return;
        Vector2 dirV = target.position - gameObject.transform.position;
        Vector2 NextVec = dirV.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + NextVec);
        rigid.linearVelocity = Vector2.zero;
    }       
    private void LateUpdate()
    {
        Vector2 dirV = target.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dirV.y, dirV.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할
    }

    public void TakeDamage(float damage)
    {
        CurrentHp -= damage;
        if(CurrentHp <= 0) 
            Destroy(gameObject);
    }
}
