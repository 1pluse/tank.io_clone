using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] bool Enemy;

    private void Awake()
    {
        if(Enemy)
        target = transform.parent.parent;
    }
    public void HealthControll(float Current, float Max)
    {
        slider.value = Current / Max;
    }

    public void EXPControll(float Current, float Max)
    {
        slider.value = Current/Max;
    }
    private void Update()
    {
        if (Enemy)
        {
            target = transform.parent.parent;
            transform.rotation = Camera.main.transform.rotation;
            transform.position = target.position + offset;
        }
    }
}
