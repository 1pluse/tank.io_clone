using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
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
