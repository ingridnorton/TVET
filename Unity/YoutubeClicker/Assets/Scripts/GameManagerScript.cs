using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance;
    public Text moneyIndicator;

   
    //How much money do we have
    public float moneyCurrent;
    public int level1Current;


    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		moneyIndicator.text = "" + moneyCurrent;
        Debug.Log(Time.deltaTime);
        moneyCurrent += 0.0165f*level1Current;
	}

    public void GetMoney()
    {
        Debug.Log("gijigf");
        moneyCurrent += 1;
    }

    public void GetLevel1()
    {
        if (moneyCurrent >= 10)
         {
            level1Current += 1;
            moneyCurrent -= 10;
        }
        
    }


}
