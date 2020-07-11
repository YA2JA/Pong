using UnityEngine;

public class BordLimmit : MonoBehaviour
{
    [SerializeField] private AgentSettings _settings = null;
    private Borders _limmit;
    protected virtual void Start()
    {
        float screenBord = _settings.View.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _settings.View.transform.position.z)).y;
        float bordHeight = _settings.Bords.transform.GetComponent<SpriteRenderer>().bounds.extents.y*2;
        float selfHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        _limmit = new Borders (-screenBord + (bordHeight + selfHeight), screenBord - (bordHeight + selfHeight));
    }
    protected virtual void LateUpdate() => transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, _limmit.Top, _limmit.Button));
    protected struct Borders
    {
        public Borders(float top, float button)
        {
            Top = top;
            Button = button;
        }
        public float Top;
        public float Button;
    }
}
