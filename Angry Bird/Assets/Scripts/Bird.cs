using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public enum BirdState { Idle, Thrown, HitSomething }
    public GameObject Parent;
    public Rigidbody2D Rigidbody;
    public CircleCollider2D circleCollider;
    public UnityAction OnBirdDestroyed = delegate {};
    public UnityAction<Bird> OnBirdShot = delegate {};
    private BirdState _state;
    public BirdState State { get { return _state; } }

    private float _minVelocity = 0.05f;
    private bool _flagDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        circleCollider.enabled = false;
        _state = BirdState.Idle;
    }

    private void FixedUpdate() 
    {
        if (_state == BirdState.Idle && Rigidbody.velocity.sqrMagnitude >= _minVelocity && !_flagDestroy)
        {
            _state = BirdState.Thrown;
        }

        if ((_state == BirdState.Thrown || _state == BirdState.HitSomething) && Rigidbody.velocity.sqrMagnitude < _minVelocity && !_flagDestroy)
        {
            //hancurkan gameobject setelah  2 detik, jika kecepatan kurang dari batas minimum
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2f));
            
        }
    }

    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    private void OnDestroy() 
    {
        if (_state == BirdState.Thrown || _state == BirdState.HitSomething) 
            OnBirdDestroyed();    
    }

    public void Shoot(Vector2 velocity, float distance, float speed)
    {
        circleCollider.enabled = true;
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody.velocity = velocity * speed * distance;
        OnBirdShot(this);
    }
    
    private void OnCollisionEnter2D(Collision2D col) 
    {
        _state = BirdState.HitSomething;
    }

    public virtual void OnTap()
    {
        //do nothing 
    }
}
