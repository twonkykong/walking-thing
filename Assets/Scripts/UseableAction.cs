using UnityEngine;
using UnityEngine.Events;

public class UseableAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private string actionLabel = "do action";
    [SerializeField] private bool isOneTimeAction;
    [SerializeField] private bool isDeletingAfterUsing;
    [SerializeField] private float activationDistance = 2f;

    private UseableActionInvoker _invoker = null;
    private Transform _player = null;
    private Transform _thisObjectTransform = null;
    private bool _isActive = true;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    private void Start()
    {
        _invoker = FindObjectOfType<UseableActionInvoker>();
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (!_isActive)
        {
            if (Vector3.Distance(_thisObjectTransform.position, _player.position) > activationDistance)
            {
                _invoker.ClearAction(this);
                _isActive = true;
            }
            return;
        }

        if (Vector3.Distance(_thisObjectTransform.position, _player.position) <= activationDistance)
        {
            _invoker.SetAction(this, actionLabel, _thisObjectTransform);
            _isActive = false;
        }
    }

    public void Use()
    {
        action.Invoke();
        _isActive = false;
        _invoker.ClearAction(this);
        if (isOneTimeAction)
        {
            if (isDeletingAfterUsing) Destroy(gameObject);
            enabled = false;
        }
    }
}
