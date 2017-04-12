using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {
    public GameObject Gun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GoalMet(GameObject winner)
    {
        //Put up UI to alert that someone won

        //Stop gun from firing
        Gun.GetComponent<GunBehavior>().StopGame();
    }
}
