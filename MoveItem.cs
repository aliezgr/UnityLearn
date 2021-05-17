using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Transform Canvas;
    public RectTransform View;
    public RectTransform Content;
     [SerializeField]Transform oldParent;
    public int AutoID;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldParent = transform.parent;
        transform.parent = Canvas;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (View.rect.Contains(Input.mousePosition - View.position))
        {
            Debug.Log("在背包里");
            for (int i = 0; i < Content.childCount; i++)
            {
                RectTransform solt = Content.GetChild(i).GetComponent<RectTransform>();
                if (solt.rect.Contains(Input.mousePosition - solt.position))
                {
                    if (solt.childCount != 0)
                    { 
                        solt.GetChild(0).parent = oldParent;
                        oldParent.GetChild(0).localPosition = Vector3.zero;
                    }
                    transform.parent = solt;
                    transform.localPosition = Vector3.zero;

                    break;
                }
            }
        }
        else
        {
            Debug.Log("在背包外");
            ItemData data = ItemManager.instance.Additem(1002);
            GameObject equip = Resources.Load<GameObject>(data.jsonData.ModelPath);
            var go = Instantiate(equip, null);
            go.GetComponent<ItemInfo>().itemData = data;
            go.GetComponent<ItemInfo>().id = data.autoId;
            Destroy(transform.gameObject);
            //transform.parent = Oldparent;
            //transform.localPosition = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.showInfo(AutoID);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.CloseInfo();
    }
}
