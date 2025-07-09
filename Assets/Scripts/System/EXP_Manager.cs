using UnityEngine;

public class EXP_Manager : MonoBehaviour
{
    public void LevelUp(int Level,float CurrentExp, float MaxExp)
    {
        if (CurrentExp >= MaxExp)
            CurrentExp -= CurrentExp;
        if (CurrentExp == 0)
            Debug.Log("·¹º§ ¾÷");
            Level++;
    }
}
