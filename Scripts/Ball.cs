using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _increaseIntensity = 0f;
    private Rigidbody2D _rigidbody;
    private float _timer;
    private float _direction = 1f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _timer = 1/_increaseIntensity;
        _rigidbody.velocity = new Vector2 (_speed*_direction, _rigidbody.velocity.y);
        StartCoroutine(speedIncrease());    
    }
    private void OnTriggerEnter2D(Collider2D other){
        float distanceFromCenter;
        if (other.tag == "Vertical")
        {
            distanceFromCenter = this.transform.position.y-other.transform.position.y;
            _rigidbody.velocity = new Vector2 (-_rigidbody.velocity.x, distanceFromCenter*10);
            _direction*=-1;
        }
        else if (other.tag == "Horizontal")
        {
            distanceFromCenter =  other.transform.position.x-this.transform.position.x;
            _rigidbody.velocity = new Vector2 (_speed*_direction, -_rigidbody.velocity.y);
        }
    }
    private IEnumerator speedIncrease()
    {
        while (true)
        {
            _speed =  _speed+1;
            _timer = 1/_increaseIntensity; 
            yield return new WaitForSeconds(_timer);
        }
    } 
}