using UnityEngine;

public class PlayerAreaFollowing : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.MovePosition(player.position);
    }
}
