using UnityEngine;

public class AreaFollowing : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.MovePosition(player.position);
    }
}
