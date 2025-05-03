using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    public Vector2 InputVec;
    [SerializeField] bool isLookAt = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (isLookAt == false) return;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Plane plane = new Plane(Vector2.up, Vector2.up);

        //if(plane.Raycast(ray, out float distance))
        //{
        //    Vector3 direction = ray.GetPoint(distance) - transform.position;
        //    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0 ,direction.z));
        //}
        if (!isLookAt) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // �Ǵ� angle������ ����� ���� ����
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
}
