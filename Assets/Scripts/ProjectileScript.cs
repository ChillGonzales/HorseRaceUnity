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
        _target = target.GetComponent<Renderer>().bounds.center;
    }
    IEnumerator Death()
    {
        _particles = Instantiate(DeathParticle);
        _particles.transform.SetParent(gameObject.transform);
        _particles.Play();
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
