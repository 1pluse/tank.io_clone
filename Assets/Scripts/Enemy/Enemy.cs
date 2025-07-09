using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float AttackDistance;
    public float MaxHp;
    float CurrentHp;
    Rigidbody2D target;
    Rigidbody2D rigid;
    Vector2 dirV;

    [SerializeField] GameObject EXP_Orb;
    [SerializeField] SliderManager healthbar;

    public bool AttackState;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<SliderManager>();
    }

    private void Start()
    {
        this.CurrentHp = this.MaxHp;
    }

    private void Update()
    {
        healthbar.SliderControll(this.CurrentHp,this.MaxHp);
        AttackStateCheck();
        dirV = target.position - rigid.position;
        if (CurrentHp <= 0)
        {
            Instantiate(EXP_Orb, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        if (target == null)
            return;
        if (AttackState)
            return;
            Vector2 NextVec = dirV.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + NextVec);
            rigid.linearVelocity = Vector2.zero;
    }       

    private void LateUpdate()
    {
        float angle = Mathf.Atan2(dirV.y, dirV.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할
    }

    public void TakeDamage(float damage)
    {
        CurrentHp -= damage;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        this.CurrentHp = this.MaxHp;
    }

    void AttackStateCheck()
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
    }
}
