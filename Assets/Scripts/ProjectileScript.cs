using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public float MovementSpeed;
    public float TimeAlive;
    public ParticleSystem DeathParticle;

    bool _firing;
    float _aliveTimer = 0.0f;
    Vector3 _target;
    Transform _targetTransform;
    ParticleSystem _particles;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (_firing)
        {
            transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * MovementSpeed);

            _aliveTimer += Time.deltaTime;
            if (_aliveTimer >= TimeAlive)
            {
                StartCoroutine(Death());
            }
        }
	}
    public void Fire(Transform target)
    {
        _firing = true;
        var center = target.GetComponent<Renderer>().bounds.center;
        _target = new Vector3(center.x, center.y, center.z);
                              
        _targetTransform = target;  
    }
    IEnumerator Death()
    {
        _particles = Instantiate(DeathParticle, gameObject.transform);
        _particles.Play();
        gameObject.GetComponent<Renderer>().enabled = false;
        _targetTransform.parent.GetComponent<TargetBehavior>().Hit();
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
