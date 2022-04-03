using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureDeathBehavior : MonoBehaviour
{
    public PlayController playController;
    public Animator toAnimate;
    public string conditionNameFromAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toAnimate.SetBool(conditionNameFromAnimator, playController.currentState == PlayController.States.GameOver && !playController.didHumanWin);
    }
}
