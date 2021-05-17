 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController cc;
    public float force;
    public float Speed;
    public float TurnSpeed;
    public float Health;
    Vector3 vel;
    public Animator ani;
    public bool isTurnEnd;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //vel.z = 0;
        cc.Move(vel * Time.deltaTime);
        vel.y += cc.isGrounded ? 0f : Physics.gravity.y * 10f * Time.deltaTime;
       
        
        AttackCheck();
    }

    public virtual void Move(float inputX)
    {
        ani.SetFloat("Speed", Mathf.Abs(inputX));
        vel.x = inputX * Speed;
        if (inputX > 0)
        {
            Turn(Vector3.right);
        }
        else if (inputX < 0)
        {
            Turn(Vector3.left);
        }
    }

    public  void Move(float inputX,float inputZ)
    {
        ani.SetFloat("Speed", inputX == 0 ? Mathf.Abs(inputZ) : Mathf.Abs(inputX));

        vel.x = inputX * Speed;

        vel.z = inputZ * Speed;

        

        



        //Vector3 r = transform.right;
        //Vector3 fwd = transform.forward;
        //Vector3 f = new Vector3(fwd.x, 0, fwd.z);
        //Vector3 move = f *inputX  + r*inputZ ;
        //transform.position += move * Speed * Time.deltaTime;


    }

    public void Jump(float inputX)
    {
        vel.y = 0;
        vel.y = force;
    }

    public void Turn(Vector3 lookDir)
    {
        Quaternion factToQuat = Quaternion.LookRotation(lookDir);
        Quaternion Slerp = Quaternion.Slerp(transform.rotation, factToQuat, TurnSpeed * Time.deltaTime);
        transform.rotation = Slerp;
        if (factToQuat == Slerp)
        {
            isTurnEnd = true;
        }
        else
        {
            isTurnEnd = false;
        }
    }

    public void AttackCheck()
    {
        float dist = cc.height / 2;
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, new Vector3(0.4f, 0.2f, 0.4f), Vector3.down, out hit, Quaternion.identity, 0.6f))
        {
            Debug.LogError(hit.collider.name);
            if (hit.transform != transform && hit.collider.GetComponent<Character>())
            {
                hit.collider.GetComponent<Character>().TakeDamage(this,20);
            }
        }
    }

    public void TakeDamage(Character other, float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Died();
        }
    }

    public void Died()
    {
        ItemData data=  ItemManager.instance.Additem(1002);
        GameObject equip = Resources.Load<GameObject>(data.jsonData.ModelPath);
      
        equip.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) ;
        var go = Instantiate(equip,null);
        go.GetComponent<ItemInfo>().itemData = data;
        go.GetComponent<ItemInfo>().id = data.autoId;
        Debug.Log(data.jsonData.ModelPath);
        Destroy(gameObject);
    }

    public void Pull(bool isPull)
    {
        Debug.Log("arms"+isPull);
        ani.SetBool("Pull",isPull);
    }

    

}
