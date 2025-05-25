using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public GameObject Bullet;
    public float FireCoolTime;
    float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > FireCoolTime)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
