using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

namespace RaveTown.Items
{

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    [SerializeField] protected ItemSlotUI itemSlotUI = null;
    private CanvasGroup canvasGroup = null;
    private Transform originalParent = null;
    private bool isHovering = false;

    public  ItemSlotUI ItemSlotUI => itemSlotUI;
    private void Start() => canvasGroup = GetComponent<CanvasGroup>();
    private void OnDisable()
    {
        if(isHovering)
        {
            //rasie event
            isHovering = false;
        }
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //raise event
            originalParent = transform.parent;
            transform.SetParent(transform.parent.parent);
            canvasGroup.blocksRaycasts = false;
        }
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {

            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        //raise event
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        //raise event
    }
}
}