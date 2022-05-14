using System.Collections;
using UnityEngine;
using TMPro;

public class UseableActionInvoker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private TextMeshProUGUI actionHintText;

    [SerializeField] private UseableAction _action = null;
    private Camera _mainCamera = null;
    private Transform _actionTextTransform = null;
    [SerializeField] private Transform _actionObjectTransform = null;
    private Transform _thisObjectTransform = null;

    private InputMaster _inputMaster = null;
    private Coroutine _moveActionTextCoroutine = null;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Player.Useaction.performed += _ => Action();

        _thisObjectTransform = transform;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _actionTextTransform = actionText.transform;
    }

    public void SetAction(UseableAction action, string actionLabel, Transform actionObject)
    {
        _action = action;
        actionText.text = actionLabel;
        _actionObjectTransform = actionObject;
        _moveActionTextCoroutine = StartCoroutine(MoveActionText());

        actionHintText.gameObject.SetActive(true);
        actionText.gameObject.SetActive(true);
    }

    public void ClearAction(UseableAction action)
    {
        if (_action == action)
        {
            _action = null;
            _actionObjectTransform = null;
            StopCoroutine(_moveActionTextCoroutine);

            actionHintText.gameObject.SetActive(false);
            actionText.gameObject.SetActive(false);
        }
    }

    private void Action()
    {
        if (_action == null) return;

        _action.Use();
    }

    private Vector2 CalculateActionTextPosition()
    {
        Vector3 midPos = (_thisObjectTransform.position + _actionObjectTransform.position) / 2;
        Vector3 finalPos = (midPos + _actionObjectTransform.position) / 2;

        Vector2 screenPos = _mainCamera.WorldToScreenPoint(finalPos);

        return screenPos;
    }

    private IEnumerator MoveActionText()
    {
        while (true)
        {
            _actionTextTransform.position = CalculateActionTextPosition();
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDestroy()
    {
        _inputMaster.Player.Useaction.performed -= _ => Action();
        _inputMaster.Disable();
    }
}
