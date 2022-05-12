using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    private InputMaster _inputMaster = null;
    private InputAction _mousePosition = null;

    private Vector2 _midScreenPoint = Vector2.zero;

    private Transform _thisObjectTransform = null;

    private void Awake()
    {
        _thisObjectTransform = transform;

        _inputMaster = new InputMaster();
        _mousePosition = _inputMaster.Player.Mouseposition;

        _midScreenPoint = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        Vector2 newPos = _mousePosition.ReadValue<Vector2>() - _midScreenPoint;

        _thisObjectTransform.localPosition = newPos / _midScreenPoint / new Vector2(1.5f, 2f);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }
}
