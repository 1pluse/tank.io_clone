using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoveControll : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 InputVec;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.instance.GameFreeze)
            return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // 또는 angle만으로 충분할 수도 있음
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GameFreeze)
            return;
        Vector2 moveVec = InputVec * Time.fixedDeltaTime * GameManager.instance.playerStats.Speed;
        rigid.MovePosition(rigid.position + moveVec);
    }
        
    void OnMove(InputValue inputValue)
    {
        InputVec = inputValue.Get<Vector2>();
    }
}
