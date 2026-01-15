using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public void Rotate(float direction)
    {
        Vector3 rotation = transform.eulerAngles;

        if (direction < 0)
            rotation.y = -180;
        else
            rotation.y = 0;

        transform.eulerAngles = rotation;
    }
}
