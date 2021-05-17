using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public enum Stage
    {
        Move,
        followPlayer,
        None,
        Jump,
    }

    Character character;
    public Transform Player;
    public Stage stage;
    bool MoveLimit;
    float MoveSpeed;

    float lastCheckstageTime;
    void Start()
    {
        character = GetComponent<Character>();
        MoveLimit = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Time.time > lastCheckstageTime + 1)
        {
            lastCheckstageTime = Time.time;

            int stageNum = Random.Range(0, 3);

            stage = (Stage)stageNum;
        }
        switch (stage)
        {
            case Stage.Move:
                if (MoveLimit)
                {
                    MoveSpeed = Random.Range(-2f, 2f);
                    MoveLimit = false;
                }
                character.Move(MoveSpeed);
                break;
            case Stage.followPlayer:
                float dir = (Player.position.x - transform.position.x);
                if (dir < 0)
                {
                    character.Move(-2);
                }
                else if (dir > 0)
                {
                    character.Move(2);
                }
                else
                {
                    character.Move(0);
                }
                break;
            case Stage.None:

                break;
            case Stage.Jump:


                break;
        }
    }
}
