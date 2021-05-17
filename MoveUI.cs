using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public GameObject bag;
    public Transform Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void BAG()
    {
        if (bag.active == true)

        {
            bag.SetActive(false);
        }
        else
        {
            bag.SetActive(true);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = Canvas;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
