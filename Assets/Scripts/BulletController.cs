using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Bullet;
    public float FireCoolTime;
    float time;

    private void Update()
    {
        time += Time.deltaTime;
        if(time > FireCoolTime)
        {
            Debug.Log("น฿ป็");
            Instantiate(Bullet,transform.position,Quaternion.identity);
            time = 0;
        }
    }
}
