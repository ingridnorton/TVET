using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("gfjdsiogjo");
        GameManagerScript.instance.GetMoney();

    }
}