using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SliderControll(float Current, float Max)
    {
        slider.value = Current / Max;
    }
}
