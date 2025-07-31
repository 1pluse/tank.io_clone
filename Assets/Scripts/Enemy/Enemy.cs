using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float AttackDistance;
    public float EXP;
    float CurrentHp;
    public float MaxHp;
    Rigidbody2D rigid;
    Vector2 dirV;

    [SerializeField] GameObject Exp_Orb;
    public bool AttackState;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.CurrentHp = this.MaxHp;
    }

    private void Update()
    {
        if (GameManager.instance.GameFreeze)
            return;
        AttackStateCheck();
        dirV = (Vector2)GameManager.instance.player.transform.position - rigid.position;
            if (CurrentHp <= 0)
            {
                EXP_Orb _Exp_Orb = Exp_Orb.GetComponent<EXP_Orb>();
                _Exp_Orb.EXP = EXP;
                Instantiate(_Exp_Orb.gameObject, transform.position, Quaternion.identity);;
                gameObject.SetActive(false);
            }
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.GameFreeze)
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
        this.CurrentHp = this.MaxHp;
    }

    void AttackStateCheck()
    {
        float currentDistance = Vector2.Distance((Vector2)GameManager.instance.player.transform.position, transform.position);
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
    