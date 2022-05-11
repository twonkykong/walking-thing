using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class LegsMovement : MonoBehaviour
{
    [SerializeField] private Transform leftLeg = null, rightLeg = null;

    [SerializeField] private float distanceLimit = 15f, legLandingDistance = 0.2f, legLandingDuration = 0.3f, legRotationDuration = 0.3f;

    private InputMaster _inputMaster = null;
    private InputAction _mousePosition = null;

    private Camera _mainCamera = null;

    private Transform _thisObjectTransform = null;

    private int _layermask = 1 << 6;

    private void Awake()
    {
        _thisObjectTransform = transform;

        _inputMaster = new InputMaster();

        _inputMaster.Player.Leftleg.performed += _ => MoveLeg(leftLeg);
        _inputMaster.Player.Rightleg.performed += _ => MoveLeg(rightLeg);

        _mousePosition = _inputMaster.Player.Mouseposition;

        _mainCamera = Camera.main;
    }

    private RaycastHit ScreenToWorldRaycast()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition.ReadValue<Vector2>());
        Physics.Raycast(ray, out RaycastHit hit, _layermask);

        return hit;
    }

    private void MoveLeg(Transform leg)
    {
        RaycastHit hit = ScreenToWorldRaycast();

        Vector3 worldPoint = hit.point;
        Vector3 normal = hit.normal;

        if (Vector3.Distance(_thisObjectTransform.position, worldPoint) <= distanceLimit)
        {
            leg.position = worldPoint + leg.up * legLandingDistance;
            leg.up = normal;

            float endYPosValue = leg.localPosition.y - legLandingDistance;
            Vector3 randomRotation = new Vector3(leg.localEulerAngles.x, leg.localEulerAngles.y * Random.Range(-45, 45), leg.localEulerAngles.z);

            leg.DOLocalMoveY(endYPosValue, legLandingDuration).OnComplete(() =>
                leg.DOLocalRotate(randomRotation, legRotationDuration));
        }
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
