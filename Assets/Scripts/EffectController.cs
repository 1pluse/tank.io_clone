using UnityEngine;

public class EffectController : MonoBehaviour
{
    public float LifeTime;
    float time = 0;

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if(time > LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
