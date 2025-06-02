using UnityEngine;

public class CursorController : MonoBehaviour
{
    public enum CursorType { Basic, Choose, Attack}
    public CursorType type;
    [SerializeField] Texture2D Basic;
    [SerializeField] Texture2D Choose;
    [SerializeField] Texture2D Attack;
    public bool AttackMoment;
    public bool ChooseMoment;
    private void Update()
    {
        if(ChooseMoment)
            type = CursorType.Choose;
        else if(AttackMoment)
            type = CursorType.Attack;
        else
            type = CursorType.Basic;
    }
    private void LateUpdate()
    {
        switch (type)
        {
            case CursorType.Basic:
                Cursor.SetCursor(Basic, new Vector2(0, 0), CursorMode.Auto);
                break;
            case CursorType.Choose:
                Cursor.SetCursor(Choose,new Vector2(0,0),CursorMode.Auto);
                break;
            case CursorType.Attack:
                Cursor.SetCursor(Attack, new Vector2(0, 0), CursorMode.Auto);
                break;
        }
    }
}
