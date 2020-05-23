using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        string tag = col.gameObject.tag;
        if (tag == "Bird" || tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }  
        
        if (tag == "Enemy")
        {
            gameController.CheckGameEnd(col.gameObject);
            Destroy(col.gameObject);
        } 
    }
}
