using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] PlayerSettings playerSettings;

    Rigidbody rb;

    private Vector3 startPosition;

    private float touchPosX;
    
    private bool isTouch;
    
    public bool cloneControl;

    [SerializeField] Animator animator;

    #endregion

    #region Singleton
    public static PlayerMovement instance;

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }


    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            animator.SetTrigger("Start");
            cloneControl = true;
            Movement();
        }
        if (GameManager.instance.isGameFinish)
        {
            if (PlayerCollisionControl.instance.isFail)
            {
                animator.SetTrigger("Fail");
            }
            else
            {
                animator.SetTrigger("Finish");
            }
        }
        //if (GameManager.instance.isReset)
        //{
        //    transform.position = startPosition;
        //    animator.SetTrigger("Reset");
        //}
    }

    private void Movement()
    {

        transform.position += Vector3.forward * playerSettings.forwardSpeed * Time.fixedDeltaTime;
        touchPosX += Input.GetAxis("Mouse X") * playerSettings.swerweSpeed * Time.fixedDeltaTime;

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);

        var playerPos = transform.position + new Vector3(touchPosX, 0, 0);

        transform.position = new Vector3
                (
                    Mathf.Clamp(transform.position.x, playerSettings.minXPos, playerSettings.maxXPos),
                    transform.position.y,
                    transform.position.z
                );
    }
}
