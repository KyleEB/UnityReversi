using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDanceBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayController playController;
    public Animator toAnimate;
    public string conditionNameFromAnimator;
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        toAnimate.SetBool(conditionNameFromAnimator,playController.didHumanWin);
    }
}
