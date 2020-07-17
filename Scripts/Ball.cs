using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _increaseTimer = 0f;
    private Rigidbody2D _rigidbody;
    public float _direction = 1f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2 (_speed*_direction, 0);
        StartCoroutine(speedIncrease());    
    }

    private void OnTriggerEnter2D(Collider2D other){
        float distanceFromCenter;
        if (other.GetComponent<Player>() != other.GetComponent<Bot>())
        {
            _direction*=-1;
            distanceFromCenter = this.transform.position.y-other.transform.position.y;
            _rigidbody.velocity = new Vector2 (_speed*_direction, distanceFromCenter*_speed);
            
        }
        else
        {
            distanceFromCenter =  other.transform.position.x-this.transform.position.x;
            _rigidbody.velocity = new Vector2 (_rigidbody.velocity.x, -_rigidbody.velocity.y);
        }
    }

    private IEnumerator speedIncrease()
    {
        while (_increaseTimer != 0)
        {
            _speed =  _speed+1;
            yield return new WaitForSeconds(_increaseTimer);
        }
    } 
}