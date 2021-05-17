using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public Transform BoxGo;
    public Transform boxPos;
    public override void Update()
    {
        base.Update();
    }

    public void CatchBox()
    {
        if (BoxGo == null)
        {
            float dist = cc.radius;
            RaycastHit hit;
            Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * (dist + 1), Color.red, 10);


            if (Physics.Raycast(transform.position + transform.up * 0.5f, transform.forward, out hit, dist + 1))
            {
                Debug.LogError(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("GrabBox"))
                {
                    BoxGo = hit.transform;
                    BoxGo.SetParent(boxPos);
                    BoxGo.localPosition = Vector3.zero;
                    BoxGo.localRotation = Quaternion.identity;
                    BoxGo.GetComponent<Rigidbody>().isKinematic = true;
                    Pull(true);
                }
            }
        }
        else if (isTurnEnd == false)
        {
            BoxGo.SetParent(null);
            BoxGo.GetComponent<Rigidbody>().isKinematic = false;
            BoxGo = null;
            Pull(false);
        }
    }

    public void GetEquip()
    {
        float dist = cc.radius;
        RaycastHit hit;
        Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * (dist + 1), Color.red, 10);
        Collider[] colliders = Physics.OverlapSphere(transform.position,1);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(1);
            if (colliders[i].CompareTag("Equip"))
            {
                ItemData INFO = colliders[i].GetComponent<ItemInfo>().itemData;
                Debug.Log(colliders[i].GetComponent<ItemInfo>().itemData.jsonData.name);
                UIManager.Instance.AddItem(INFO);
                Destroy(colliders[i].gameObject);
            }
        }
        
    }
}
