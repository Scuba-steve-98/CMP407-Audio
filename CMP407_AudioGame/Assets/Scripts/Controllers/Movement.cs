using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController cc;
    AudioController audioController;

    enum MOVE_STATE
    {
        WALKING,
        RUNNUNG,
        JUMPING
    }

    //float jumpStaminaLoss;
    //float runStaminaLoss;
    //float stamina;
    float jumpVelocity;
    float walkMax;
    float runMultiplier;
    float jumpHeight;
    float lateralMovement;
    float stepLength = 0.0f;
    float runStepLengthMultiplier = 0.6f;

    bool wasAirborneLastFrame = false;
    bool isNearDungeon = false;
    bool isOnWater = false;
    bool isShallow = true;
    bool isInDungeon = false;

    string lastWalkAudio = "";

    Vector3 spawnPos;
    Vector3 moveDirection;

    MOVE_STATE moveState;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioController = FindObjectOfType<AudioController>();
        walkMax = 7f;
        lateralMovement = 5.5f;
        runMultiplier = 2f;
        moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        jumpHeight = 2.1f;
        jumpVelocity = 0f;
        moveState = MOVE_STATE.WALKING;
        //MusicController m = FindObjectOfType<MusicController>();
        //m.Play("Default");
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection *= 0.0f;
        moveDirection += gameObject.transform.forward * walkMax * Input.GetAxis("Vertical");
        moveDirection += gameObject.transform.right * lateralMovement * Input.GetAxis("Horizontal");

        if (stepLength < 0.1f && isOnWater && ((moveDirection.x > 0 && moveDirection.z > 0) || (moveDirection.x > 0 || moveDirection.z > 0)) && isShallow)
        {
            int q = Random.Range(1, 5);
            audioController.PlayOneShot("WaterExit" + q, Random.Range(0.4f, 0.6f));
        }


        if (moveDirection.x == 0 && moveDirection.z == 0)
        {
            stepLength = 0;
        }

        if (moveDirection.magnitude > 7)
            moveDirection /= 1.3f;


        if (Input.GetKey(KeyCode.LeftShift) && cc.isGrounded)
        {
            moveDirection *= runMultiplier;
            moveState = MOVE_STATE.RUNNUNG;
            stepLength += moveDirection.magnitude * Time.deltaTime * runStepLengthMultiplier;
        }  
        else
        {
            if (cc.isGrounded)
                moveState = MOVE_STATE.WALKING;
            stepLength += moveDirection.magnitude * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            //Mathf.Sqrt(height * -2f * gravity);
            moveState = MOVE_STATE.JUMPING;
            jumpVelocity = Mathf.Sqrt(-2f * jumpHeight * -9.81f);
        }     

        if (!cc.isGrounded)
        {
            wasAirborneLastFrame = true;
            if (moveDirection.y <= 0)
                jumpVelocity -= 9.8f * 1.75f * Time.deltaTime;
            else
                jumpVelocity -= 9.8f * Time.deltaTime;
            stepLength = 0;
        }
        else if (cc.isGrounded && wasAirborneLastFrame)
        {
            wasAirborneLastFrame = false;
            //Debug.Log("landed");

            int q = Random.Range(1, 3);
            if (isInDungeon)
            {
                audioController.PlayOneShot("Jump" + q, Random.Range(0.7f, 0.8f));
            }
            else
            {
                audioController.PlayOneShot("Jump" + q, Random.Range(0.45f, 0.55f));
            }
        }

        moveDirection.y = jumpVelocity;
        cc.Move(moveDirection * Time.deltaTime);

        //if (gameObject.transform.position.y < 3.92f && !isNearDungeon)
        //    transform.position = new Vector3(-5.39f, 9.14f, 15.32f);

        if (stepLength > 1.75f)
        {
            if (moveState == MOVE_STATE.WALKING && !isOnWater)
            {
                int q = Random.Range(1, 7);
                lastWalkAudio = "Walk" + q;
                audioController.PlayOneShot(lastWalkAudio, Random.Range(0.5f, 0.6f));
            }
            else if (moveState == MOVE_STATE.RUNNUNG && !isOnWater)
            {
                int q = Random.Range(1, 6);
                lastWalkAudio = "Run" + q;
                audioController.PlayOneShot(lastWalkAudio, Random.Range(0.5f, 0.65f));
            }
            else if (isOnWater)
            {
                if (isShallow)
                {
                    int q = Random.Range(1, 5);
                    lastWalkAudio = "WaterWalk" + q;
                    audioController.PlayOneShot(lastWalkAudio, Random.Range(0.4f, 0.5f));
                }
                else if (!isShallow)
                {
                    int q = Random.Range(1, 4);
                    lastWalkAudio = "DeepWater" + q;
                    audioController.PlayOneShot(lastWalkAudio, Random.Range(0.4f, 0.5f));
                }
            }
            else if (isInDungeon)
            {
                int q = Random.Range(1, 3);
                lastWalkAudio = "Dungeon" + q;
                audioController.PlayOneShot(lastWalkAudio, Random.Range(0.4f, 0.5f));
            }
            stepLength = 0f;
        }

        if ((moveState != MOVE_STATE.JUMPING && moveDirection.x == 0 && moveDirection.z == 0) || !cc.isGrounded)
        {
            audioController.Stop(lastWalkAudio);
        }

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

    public void setInWater(bool water)
    {
        isOnWater = water;
    }

    public void setWaterStart(Vector3 pos)
    {
        spawnPos = pos;
    }

    public void updateDepthInWater(float water)
    {
        float depth = gameObject.transform.position.y - water;
        if (depth < 0.10f)
        {
            isShallow = false;
        }
        else if (depth > 0.10f)
        {
            isShallow = true;
        }

        if (depth < -0.3f)
        {
            gameObject.transform.position = spawnPos;
        }
    }

    public void setInDungeon(bool dungeon)
    {
        isInDungeon = dungeon;
    }
}