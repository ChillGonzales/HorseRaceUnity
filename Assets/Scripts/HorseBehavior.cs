using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseBehavior : MonoBehaviour {
    public Color Color;
    public float MovementSpeed;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Hit(float displacement)
    {
        transform.Translate(displacement, 0, 0, Space.World);
    }
}
