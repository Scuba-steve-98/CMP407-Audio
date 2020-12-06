using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController cc;

    enum MOVE_STATE
    {
        WALKING,
        RUNNUNG,
        JUMPING
    }

    float jumpStaminaLoss;
    float runStaminaLoss;
    float stamina;
    float jumpVelocity;
    float walkMax;
    float runMultiplier;
    float jumpHeight;
    float lateralMovement;
    float depthInWater;

    bool wasAirborneLastFrame = false;
    bool isNearDungeon = false;
    bool isNearMountains = false;
    bool isOnWater = false;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        walkMax = 7f;// 0.03f;
        lateralMovement = 5.5f;
        runMultiplier = 2f;
        moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        jumpHeight = 2.1f;
        jumpVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection *= 0.0f;
        moveDirection += gameObject.transform.forward * walkMax * Input.GetAxis("Vertical");
        moveDirection += gameObject.transform.right * lateralMovement * Input.GetAxis("Horizontal");

        if (moveDirection.magnitude > 7)
            moveDirection /= 1.3f;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= runMultiplier;
        }  

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            //Mathf.Sqrt(height * -2f * gravity);
            jumpVelocity = Mathf.Sqrt(-2f * jumpHeight * -9.81f);
        }          

        if (!cc.isGrounded)
        {
            wasAirborneLastFrame = true;
            if (moveDirection.y <= 0)
                jumpVelocity -= 9.8f * 1.75f * Time.deltaTime;
            else
                jumpVelocity -= 9.8f * Time.deltaTime;
        }
        else if (cc.isGrounded && wasAirborneLastFrame)
        {
            wasAirborneLastFrame = false;
            Debug.Log("landed");
            //Play landing Audio--------------------------------------------------------------------------------
        }

        moveDirection.y = jumpVelocity;
        cc.Move(moveDirection * Time.deltaTime);

        if (gameObject.transform.position.y < 3.92f && !isNearDungeon)
            transform.position = new Vector3(-5.39f, 9.14f, 15.32f);


        if(isNearDungeon)
        {
            Debug.Log("Near Dungeon");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
        }
    }
}