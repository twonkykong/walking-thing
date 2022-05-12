using UnityEngine;

public class LineTargetsFollowing : MonoBehaviour
{
    [SerializeField] private Transform firstTarget;
    [SerializeField] private Transform secondTarget;

    private LineRenderer _lineRenderer = null;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3[] positions = new Vector3[2] { firstTarget.position, secondTarget.position };
        _lineRenderer.SetPositions(positions);
    }
}
