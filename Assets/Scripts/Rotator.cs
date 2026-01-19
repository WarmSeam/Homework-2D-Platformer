using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Quaternion _faceLeft;
    private Quaternion _faceRight;

    private void Awake()
    {
        _faceRight = Quaternion.Euler(0, 0, 0);
        _faceLeft = Quaternion.Euler(0, 180, 0);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.x < transform.position.x)
            transform.rotation = _faceLeft;
        else if(direction.x > transform.position.x)
            transform.rotation = _faceRight;
    }
}
