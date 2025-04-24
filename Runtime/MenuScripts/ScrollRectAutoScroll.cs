using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Put this on the object that has the ScrollRect
/// </summary>
[RequireComponent(typeof(ScrollRect))]
public class ScrollRectAutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scrollSpeed = 10f;
    private bool _mouseOver = false;

    private List<Selectable> _mSelectables = new List<Selectable>();
    private ScrollRect _mScrollRect;

    private Vector2 _mNextScrollPosition = Vector2.up;
    void OnEnable()
    {
        if (_mScrollRect)
        {
            _mScrollRect.content.GetComponentsInChildren(_mSelectables);
        }
    }
    void Awake()
    {
        _mScrollRect = GetComponent<ScrollRect>();
    }
    void Start()
    {
        if (_mScrollRect)
        {
            _mScrollRect.content.GetComponentsInChildren(_mSelectables);
        }
        ScrollToSelected(true);
    }
    void Update()
    {
        // Scroll via input.
        InputScroll();
        if (!_mouseOver)
        {
            // Lerp scrolling code.
            _mScrollRect.normalizedPosition = Vector2.Lerp(_mScrollRect.normalizedPosition, _mNextScrollPosition, scrollSpeed * Time.deltaTime);
        }
        else
        {
            _mNextScrollPosition = _mScrollRect.normalizedPosition;
        }
    }
    void InputScroll()
    {
        if (_mSelectables.Count > 0)
        {
            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") || Input.GetButton("Horizontal") ||
                Input.GetButton("Vertical") || Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
            {
                ScrollToSelected(false);
            }
        }
    }
    void ScrollToSelected(bool quickScroll)
    {
        int selectedIndex = -1;
        Selectable selectedElement = EventSystem.current.currentSelectedGameObject ? EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>() : null;

        if (selectedElement)
        {
            selectedIndex = _mSelectables.IndexOf(selectedElement);
        }
        if (selectedIndex > -1)
        {
            if (quickScroll)
            {
                _mScrollRect.normalizedPosition = new Vector2(0, 1 - (selectedIndex / ((float)_mSelectables.Count - 1)));
                _mNextScrollPosition = _mScrollRect.normalizedPosition;
            }
            else
            {
                _mNextScrollPosition = new Vector2(0, 1 - (selectedIndex / ((float)_mSelectables.Count - 1)));
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOver = false;
        ScrollToSelected(false);
    }
}