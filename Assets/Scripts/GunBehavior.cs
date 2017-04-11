using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {
    public Transform[] Horses;
    public Transform PivotPoint;
    public Transform MuzzlePoint;
    public GameObject Projectile;
    public float ProjectileSpeed;
    public float RotationSpeed;
    public float TimeDelay;

    Vector3 _direction;
    Quaternion _lookRotation;
    float _delayTimer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _delayTimer += Time.deltaTime;
        if (_delayTimer >= TimeDelay)
        {
            _delayTimer -= TimeDelay;
            int randInt = Mathf.FloorToInt(Random.Range(0, 7));
            // Find the direction pointing from our position to the target
            _direction = (Horses[randInt].position - PivotPoint.position).normalized;
        }

        // Calculate the rotation
        _lookRotation = Quaternion.LookRotation(_direction);

        // Pivot around parent object
        PivotPoint.rotation = Quaternion.Slerp(PivotPoint.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        // Fire at whatever horse we were looking at

    }
    void Fire(Transform target, float deltaTime)
    {
        var proj = GameObject.Instantiate<GameObject>(Projectile, MuzzlePoint);
        proj.transform.position = Vector3.Lerp(proj.transform.position, target.position, deltaTime * ProjectileSpeed);
    }
}
