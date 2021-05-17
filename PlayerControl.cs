using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerCharacter playerCharacter;
    int JumpConut =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter.cc.isGrounded == true)
        {
            JumpConut = 1;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            if (JumpConut == 1)
            {
                playerCharacter.Jump(x);
                JumpConut--;
                return;
            }
        }
        if (x != 0 || z != 0)
        {
            Vector3 dir = new Vector3(x, 0, z);
            playerCharacter.Turn(dir);
        }
        playerCharacter.Move(x,z);
        //playerCharacter.Move(y);

        if (Input.GetKeyDown(KeyCode.F))
        {
            
            playerCharacter.CatchBox();
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            playerCharacter.GetEquip();

        }
    }
}
