using UnityEngine;
public class Player : MonoBehaviour
{
    private Vector3 _targetPos;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        _targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2 (transform.position.x, _targetPos.y);
    }
}