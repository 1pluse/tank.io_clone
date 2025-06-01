using UnityEngine;

public class Relocation_Tile : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        if (GameManager.instance.player != null)
        {
            Vector2 playerPos = GameManager.instance.player.transform.position;
            Vector2 myPos = transform.position;

            if (transform.tag == "Ground")
            {
                float diffX = playerPos.x - myPos.x;
                float diffY = playerPos.y - myPos.y;
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);
                if (diffX > diffY)
                {
                    transform.Translate(Vector2.right * dirX * 50);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector2.up * dirY * 50);
                }
            }
        }
    }
}   
