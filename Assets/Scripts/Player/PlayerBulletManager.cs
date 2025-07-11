using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public GameObject Bullet;
    public float FireCoolTime;
    float time;

    private void Update()
    {
        if (GameManager.instance.Ui_Manager.GameFreeze)
            return;
            time += Time.deltaTime;
        if (time > FireCoolTime)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
