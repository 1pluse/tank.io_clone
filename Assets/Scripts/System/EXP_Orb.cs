using Unity.AppUI.Core;
using UnityEngine;

public class EXP_Orb : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float EXP;
    [SerializeField] Rigidbody2D target;
    [SerializeField] float EXP_Orb_Speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (target == null)
            return;
        if (!GameManager.instance.Ui_Manager.GameFreeze)
        {
            Vector2 dirV;
            dirV = target.position - rigid.position;
            Vector2 NextVec = dirV.normalized * EXP_Orb_Speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + NextVec);
            rigid.linearVelocity = Vector2.zero;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.player.CurrentExp += EXP;
            Destroy(gameObject);
        }
    }
}
