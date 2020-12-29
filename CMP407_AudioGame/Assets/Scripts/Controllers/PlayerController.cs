using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    AudioController audioController;

    Vector3 spawnPos;
    Vector3 moveDirection;

    enum MOVE_STATE
    {
        WALKING,
        RUNNING,
        JUMPING,
        FALLING,
        STATIONARY
    }

    MOVE_STATE moveState;

    float walkMax;
    float runMultiplier;
    float jumpHeight;
    float lateralMovement;
    float stepLength;
    float runStepLengthMultiplier;
    float gravity;

    bool wasAirborneLastFrame = false;
    bool isOnWater = false;
    bool isShallow = true;
    bool isInDungeon = false;

    string lastWalkAudio = "";


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioController = FindObjectOfType<AudioController>();

        walkMax = 7f;
        lateralMovement = 5.5f;
        runMultiplier = 2f;
        moveDirection = new Vector3(0, 0, 0);
        jumpHeight = 2.1f;
        gravity = -9.81f;
        stepLength = 0;
        runStepLengthMultiplier = 0.2f;

        moveState = MOVE_STATE.STATIONARY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && characterController.isGrounded)
        {
            moveState = MOVE_STATE.STATIONARY;
        }
        else if (!characterController.isGrounded && moveState != MOVE_STATE.JUMPING)
        {
            moveState = MOVE_STATE.FALLING;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            moveState = MOVE_STATE.JUMPING;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && characterController.isGrounded && ((Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0) || ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))))
        {
            moveState = MOVE_STATE.RUNNING;
        }
        else if (!Input.GetKeyDown(KeyCode.LeftShift) && characterController.isGrounded && ((Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0) || ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))))
        {
            moveState = MOVE_STATE.WALKING;
        }

        switch (moveState)
        {
            case MOVE_STATE.WALKING:
                moveDirection = (gameObject.transform.forward * walkMax * Input.GetAxis("Vertical")) + (gameObject.transform.right * lateralMovement * Input.GetAxis("Horizontal")) + gameObject.transform.up * gravity;
                
                if (stepLength == 0 && isOnWater && isShallow)
                {
                    int q = Random.Range(1, 5);
                    audioController.PlayOneShot("WaterExit" + q, Random.Range(0.4f, 0.6f));
                }

                stepLength += Mathf.Sqrt((Mathf.Pow(moveDirection.x, 2) + Mathf.Pow(moveDirection.z, 2))) * Time.deltaTime;
                break;

            case MOVE_STATE.RUNNING:
                moveDirection = (gameObject.transform.forward * walkMax * runMultiplier * Input.GetAxis("Vertical")) + (gameObject.transform.right * lateralMovement * Input.GetAxis("Horizontal")) + gameObject.transform.up * gravity;

                if (stepLength == 0 && isOnWater && isShallow)
                {
                    int q = Random.Range(1, 5);
                    audioController.PlayOneShot("WaterExit" + q, Random.Range(0.4f, 0.6f));
                }

                stepLength += Mathf.Sqrt((Mathf.Pow(moveDirection.x, 2) + Mathf.Pow(moveDirection.z, 2))) * Time.deltaTime * runStepLengthMultiplier;
                break;

            case MOVE_STATE.JUMPING:
                if (!wasAirborneLastFrame)
                {
                    moveDirection.y = Mathf.Sqrt(-2f * jumpHeight * -9.81f);
                }
                else
                {
                    if (moveDirection.y <= 0)
                    {
                        moveDirection.y -= 9.81f * 1.75f * Time.deltaTime;
                    }
                    else
                        moveDirection.y -= 9.81f * Time.deltaTime;
                }
                stepLength = 0;
                break;

            case MOVE_STATE.FALLING:
                if (moveDirection.y <= 0)
                {
                    moveDirection.y -= 9.81f * 1.75f * Time.deltaTime;
                }
                else
                    moveDirection.y -= 9.81f * Time.deltaTime;

                stepLength = 0;
                break;

            case MOVE_STATE.STATIONARY:
                moveDirection *= 0f;
                moveDirection.y = gravity;
                stepLength = 0;
                audioController.Stop(lastWalkAudio);
                break;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (!characterController.isGrounded)
        {
            wasAirborneLastFrame = true;
        }
        else if (characterController.isGrounded && wasAirborneLastFrame)
        {
            wasAirborneLastFrame = false;

            int q = Random.Range(1, 3);
            if (isInDungeon)
            {
                audioController.PlayOneShot("Jump" + q, Random.Range(0.7f, 0.8f));
            }
            else
            {
                audioController.PlayOneShot("Jump" + q, Random.Range(0.45f, 0.55f));
            }
            moveDirection.y = gravity;
        }

        //Debug.Log("MoveState: " + moveState + " StepLength: " + stepLength + " isOnWater: " + isOnWater);
        if (stepLength > 0.9f)
        {
            if (moveState == MOVE_STATE.WALKING && !isOnWater)
            {
                int q = Random.Range(1, 7);
                lastWalkAudio = "Walk" + q;
                audioController.PlayOneShot(lastWalkAudio, Random.Range(0.5f, 0.6f));
            }
            else if (moveState == MOVE_STATE.RUNNING && !isOnWater)
            {
                Debug.Log("Run");
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
                    lastWalkAudio = "DeepWalk" + q;
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
