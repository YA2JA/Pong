using UnityEngine;
public class Player : BordLimmit
{
    private void Update()
    {
        if (Input.GetMouseButton(0)){
            float targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            transform.position = new Vector2 (transform.position.x, targetPos);
        }
    }
}