using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] SliderManager healthbar;
    [SerializeField] SliderManager expbar;
    private void Awake()
    {
        healthbar = GameObject.Find("PlayerHp").GetComponentInChildren<SliderManager>();
        expbar = GameObject.Find("PlayerExp").GetComponentInChildren<SliderManager>();
    }

    private void Update()
    {
        healthbar.SliderControll(GameManager.instance.playerStats.CurrentHp, GameManager.instance.playerStats.MaxHp);
        expbar.SliderControll(GameManager.instance.playerStats.CurrentExp, GameManager.instance.playerStats.MaxExp);
    }
}
