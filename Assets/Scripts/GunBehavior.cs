﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {
    public Transform[] Horses;
    public Transform PivotPoint;
    public Transform MuzzlePoint;
    public GameObject Projectile;
    public float RotationSpeed;
    public float TimeDelay;

    Vector3 _direction;
    Quaternion _lookRotation;
    float _delayTimer;
    int _currentTarget;
    bool _projectileActive = false;
    GameObject _activeProjectile;
    int _horseMask;
    bool _gameRunning = true;

	// Use this for initialization
	void Start () {
        _delayTimer = TimeDelay;
        _horseMask = LayerMask.GetMask("Horse");
	}
	
	// Update is called once per frame
	void Update () {
        if (!_gameRunning)
        {
            return;
        }

        _delayTimer += Time.deltaTime;
        if (_delayTimer >= TimeDelay && _projectileActive == true)
        {
            _delayTimer -= TimeDelay;
            _currentTarget = Mathf.FloorToInt(Random.Range(0, 7));
            _projectileActive = false;  
        }

        // Find the direction pointing from our position to the target
        _direction = (Horses[_currentTarget].GetComponent<Renderer>().bounds.center - MuzzlePoint.position).normalized;

        // Calculate the rotation
        _lookRotation = Quaternion.LookRotation(_direction);

        // Pivot around parent object
        PivotPoint.rotation = Quaternion.Lerp(PivotPoint.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        Debug.DrawLine(MuzzlePoint.position, Horses[_currentTarget].GetComponent<Renderer>().bounds.center);

        //Raycast
        RaycastHit rHit;
        Physics.Raycast(MuzzlePoint.position, _direction, out rHit, 2000.0f, _horseMask);

        if (rHit.transform == Horses[_currentTarget] && !_projectileActive && PivotPoint.rotation == _lookRotation)
        {
            _activeProjectile = Instantiate(Projectile, MuzzlePoint.position, Quaternion.identity);
            if (_activeProjectile.GetComponent<ProjectileScript>() == null) { Debug.Log("No projectile script on Projectile."); }
            else { _activeProjectile.GetComponent<ProjectileScript>().Fire(Horses[_currentTarget]); }
            _projectileActive = true;
        }
    }
    public void StopGame()
    {
        _gameRunning = false;
    }
}
