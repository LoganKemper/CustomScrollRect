using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomScrollRect : ScrollRect
{
    [SerializeField] private bool preventScrolling;
    [SerializeField] private bool preventDragging;

    private int _activePointerId = -1;

    protected override void Start()
    {
        // Elastic on touchscreen, clamped otherwise
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        movementType = MovementType.Elastic;
#else
        movementType = MovementType.Clamped;
#endif
    }

    public override void OnScroll(PointerEventData data)
    {
        // Only scroll if scrolling is allowed
        if (!preventScrolling)
        {
            base.OnScroll(data);

            // Reset dragging velocity when scrolling with the scroll wheel
            velocity = Vector2.zero;
        }
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        // Switch the cached active pointer ID to the latest pointer
        _activePointerId = eventData.pointerId;
        base.OnInitializePotentialDrag(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        // Only let the active pointer drag
        if (!preventDragging && eventData.pointerId == _activePointerId)
        {
            base.OnBeginDrag(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        // Only let the active pointer drag
        if (eventData.pointerId == _activePointerId)
        {
            base.OnDrag(eventData);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        // If the active pointer has ended its drag, reset the active pointer ID
        if (eventData.pointerId == _activePointerId)
        {
            base.OnEndDrag(eventData);
            _activePointerId = -1;
        }
    }
}
