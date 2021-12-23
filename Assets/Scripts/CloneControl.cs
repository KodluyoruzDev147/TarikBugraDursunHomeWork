using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneControl : MonoBehaviour
{
    [SerializeField] Animator cloneAnimator;
    [SerializeField] PlayerSettings cloneSettings;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            CloneMovement();
            if (PlayerMovement.instance.cloneControl)
            {
                cloneAnimator.SetTrigger("Start");
            }
        }
        else
        {
            cloneAnimator.SetTrigger("Finish");
        }
    }

    private void CloneMovement() 
    {
        transform.position += Vector3.forward * cloneSettings.forwardSpeed * .01f * Time.fixedDeltaTime;
    }
}
