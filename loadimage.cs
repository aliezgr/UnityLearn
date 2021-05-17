using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class loadimage : MonoBehaviour
{
    public Image IMG;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = Resources.Load<Sprite>("testimage");
        IMG.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
