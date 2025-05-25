using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    Rigidbody2D rigid;
    Enemy enemy;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        rigid.MovePosition(transform.parent.position);
    }
}
