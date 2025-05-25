using Unity.AppUI.Core;
using UnityEngine;

public class PlayerBaseSkill : MonoBehaviour
{
    public float Dashdistance;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void OnDash()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePosition - transform.position).normalized;
        dir.z = 0;
        dir.Normalize();
        rigid.position = (Vector3)rigid.position + dir * Dashdistance;
    }
}
