using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehavior : MonoBehaviour
{
    public Animator toAnimate;
    public string conditionNameFromAnimator;
    public float idleTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            waitTime = 0;
            toAnimate.SetBool(conditionNameFromAnimator, false);
        }
        
        if (waitTime > idleTime)
        {
                toAnimate.SetBool(conditionNameFromAnimator,true);
                waitTime = 0;
        }
        else
        {
             waitTime += Time.deltaTime;
        }
        
    }
}
