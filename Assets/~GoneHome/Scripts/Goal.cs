using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events; 

public class Goal : MonoBehaviour
{
    public UnityEvent onGoal;
    void OnTriggerEnter(Collider other)
    {
        //Check if onGoal event exists
        if (onGoal != null)
        {
            //Invoke event
            onGoal.Invoke();
        }
    }
}
