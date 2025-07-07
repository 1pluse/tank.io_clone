using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Vector2 InputVec;
    public float CurrentHp;
    public float MaxHp;
    public int Level;
    public float CurrentExp;
    public float MaxExp;

    
    [SerializeField] bool isLookAt = true;
    [SerializeField] SliderManager healthbar;
    [SerializeField] SliderManager expbar;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        healthbar = GameObject.Find("PlayerHp").GetComponentInChildren<SliderManager>();
        expbar  = GameObject.Find("PlayerExp").GetComponentInChildren<SliderManager>();
    }
    private void Start()
    {
        this.CurrentHp = this.MaxHp;
    }

    private void Update()
    {
        if (!isLookAt) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할 수도 있음
        healthbar.HealthControll(this.CurrentHp, this.MaxHp);
        expbar.EXPControll(this.CurrentExp , this.MaxExp);
    }


    void FixedUpdate()
    {
        Vector2 moveVec = InputVec * Time.fixedDeltaTime * Speed;
        rigid.MovePosition(rigid.position + moveVec);   
    }
        
    void OnMove(InputValue inputValue)
    {
        InputVec = inputValue.Get<Vector2>();
    }

    public void TakeDamage(float damage)
    {
        this.CurrentHp -= damage;
    }
}
