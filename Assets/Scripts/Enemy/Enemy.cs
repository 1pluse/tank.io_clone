using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float AttackDistance;
    public float EXP;    
    public float MaxHp;
    float CurrentHp;
    Rigidbody2D target;
    Rigidbody2D rigid;
    Vector2 dirV;

    [SerializeField] GameObject Exp_Orb;
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
        if (GameManager.instance.Ui_Manager.GameFreeze)
            return;
        healthbar.SliderControll(this.CurrentHp,this.MaxHp);
        AttackStateCheck();
        dirV = target.position - rigid.position;
            if (CurrentHp <= 0)
            {                
                Instantiate(Exp_Orb.gameObject, transform.position, Quaternion.identity);
                EXP_Orb _Exp_Orb = Exp_Orb.GetComponent<EXP_Orb>();
                _Exp_Orb.EXP = EXP;
                gameObject.SetActive(false);
            }
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.Ui_Manager.GameFreeze)
            return;
        if (AttackState || target == null)
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
