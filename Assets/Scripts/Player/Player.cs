using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Vector2 InputVec;
    int MaxExp_Increase;
    public float CurrentHp;
    public float MaxHp;
    public int Level;
    public float CurrentExp;
    public float MaxExp;

    
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
        this.CurrentExp = 0;
    }

    private void Update()
    {
        if (GameManager.instance.Ui_Manager.GameFreeze)
            return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할 수도 있음
        HpManager();
        healthbar.SliderControll(this.CurrentHp, this.MaxHp);
        ExpManager();
        expbar.SliderControll(this.CurrentExp, this.MaxExp);
    }

    void FixedUpdate()
    {
        if (GameManager.instance.Ui_Manager.GameFreeze)
            return;
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

    void HpManager()
    {
        if (this.CurrentHp <= 0)
            Destroy(gameObject);
    }

    void ExpManager()
    {
        if (CurrentExp >= MaxExp)
        {
            CurrentExp -= CurrentExp;
            Level++;
            MaxExp_Increase += 15;
            MaxExp += Level * MaxExp_Increase;
            GameManager.instance.Ui_Manager.SkillChooseBackGround.SetActive(true);
        }
    }
}
