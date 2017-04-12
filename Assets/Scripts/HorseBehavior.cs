using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseBehavior : MonoBehaviour {
    public Color Color;
    public float MovementSpeed;
    public Transform Goal;

    GameObject _gameManager;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color;
        _gameManager = GameObject.FindGameObjectsWithTag("Manager")[0];
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Hit()
    {
        transform.Translate(MovementSpeed, 0, 0, Space.World);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == Goal)
        {
            Debug.Log("Goal met!");
            _gameManager.GetComponent<GameManagement>().GoalMet(gameObject);
        }
    }
}
