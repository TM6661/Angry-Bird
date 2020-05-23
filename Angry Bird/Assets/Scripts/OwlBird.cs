using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    public CircleCollider2D _areaCollider;
    public PointEffector2D _pointEffector;
    public bool _hasExplode = false;
    public GameObject explotion;
    public Vector3 collisionPosition;

    private void OnCollisionEnter2D(Collision2D col)
    {
        collisionPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (!_hasExplode)
        {
            InstatiateExplotion();
            _areaCollider.enabled = true;
            _pointEffector.enabled = true;
            _hasExplode = true;
        }
    }

    private void InstatiateExplotion()
    {
        Instantiate(explotion, collisionPosition, Quaternion.identity);
    }
}
