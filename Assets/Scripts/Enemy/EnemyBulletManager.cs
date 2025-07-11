using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float FireCoolTime;
    float time;
    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (!enemy.AttackState)  
            return;
        if (!GameManager.instance.Ui_Manager.GameFreeze)
        {
            time += Time.deltaTime;
            if (time > FireCoolTime)
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
                time = 0;
            }
        }
    }
}
