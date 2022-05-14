using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private bool isOneTimeAction;
    [SerializeField] private float activationDistance = 3f;

    private Bounds _bounds = new Bounds();
    private Transform _player = null;
    private Transform _thisObjectTransform = null;
    private bool _isActive = true;

    private void Awake()
    {
        _bounds = GetComponent<Collider>().bounds;
        _thisObjectTransform = transform;
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (!_isActive)
        {
            if (Vector3.Distance(_thisObjectTransform.position, _player.position) >= activationDistance)
            {
                _isActive = true;
            }
        }
        if (_bounds.Contains(_player.position))
        {
            action.Invoke();
            if (isOneTimeAction) Destroy(gameObject);
            _isActive = false;
        }
    }
}
