using Unity.AppUI.Core;
using UnityEngine;

public class EXP_Orb : MonoBehaviour
{
    Rigidbody2D rigid;
    public float EXP;
    [SerializeField] float EXP_Orb_Speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()   
    {
        if (!GameManager.instance.GameFreeze)
        {
            Vector2 dirV;
            dirV = (Vector2)GameManager.instance.player.transform.position - rigid.position;
            Vector2 NextVec = dirV.normalized * EXP_Orb_Speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + NextVec);
            rigid.linearVelocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.playerStats.CurrentExp += (EXP * GameManager.instance.playerStats.Exp_CollectAmount);
            Destroy(gameObject);
        }
    }
}
