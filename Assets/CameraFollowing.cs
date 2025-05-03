using NUnit.Framework.Constraints;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform PlayerPosition;

    private void LateUpdate()
    {
        transform.position = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y,-5);
    }
}
