using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class FeetMovement : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;

    [SerializeField] private bool isAlternating;

    [SerializeField] private float distanceLimit = 15f;
    [SerializeField] private float footLandingDistance = 0.2f;
    [SerializeField] private float footLandingDuration = 0.3f;
    [SerializeField] private float footRotationDuration = 0.3f;
    [SerializeField] private float footRotationAngle = 30f;

    private InputMaster _inputMaster = null;
    private InputAction _mousePosition = null;

    private Camera _mainCamera = null;

    private Transform _thisObjectTransform = null;
    private Transform _currentFoot = null;

    private void Awake()
    {
        _thisObjectTransform = transform;

        _inputMaster = new InputMaster();

        _inputMaster.Player.Leftfoot.performed += _ => MoveFoot(leftFoot);
        _inputMaster.Player.Rightfoot.performed += _ => MoveFoot(rightFoot);

        _mousePosition = _inputMaster.Player.Mouseposition;

        _mainCamera = Camera.main;

        _currentFoot = leftFoot;
    }

    private RaycastHit ScreenToWorldRaycast()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition.ReadValue<Vector2>());
        Physics.Raycast(ray, out RaycastHit hit);

        return hit;
    }

    private void MoveFoot(Transform foot)
    {
        RaycastHit hit = ScreenToWorldRaycast();

        Vector3 worldPoint = hit.point;
        Vector3 normal = hit.normal;
        Transform body = hit.transform;

        if (isAlternating) foot = _currentFoot;

        if (Vector3.Distance(_thisObjectTransform.position, worldPoint) <= distanceLimit)
        {
            foot.up = normal;
            foot.position = worldPoint + foot.up * footLandingDistance;
            //foot.SetParent(body);

            Vector3 randomRotation = Vector3.up * Random.Range(-footRotationAngle, footRotationAngle);
            //Vector3 newPos = foot.position - foot.up * footLandingDistance;

            foot.Rotate(randomRotation, Space.Self);
            foot.DOLocalMove(worldPoint, footLandingDuration);

            if (isAlternating) _currentFoot = (foot == leftFoot ? rightFoot : leftFoot);
        }
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Player.Leftfoot.performed -= _ => MoveFoot(leftFoot);
        _inputMaster.Player.Rightfoot.performed -= _ => MoveFoot(rightFoot);

        _inputMaster.Disable();
    }
}
