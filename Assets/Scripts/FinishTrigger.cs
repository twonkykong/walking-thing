using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private SpeedrunTimer _timer = null;
    private Transform _player = null;
    private Bounds _bounds = new Bounds();

    private void Start()
    {
        _timer = FindObjectOfType<SpeedrunTimer>();
        _player = FindObjectOfType<Player>().transform;

        _bounds = GetComponent<Collider>().bounds;
    }

    private void Update()
    {
        if (_bounds.Contains(_player.position))
        {
            _timer.StopTimer();
            Destroy(gameObject);
        }
    }
}
