using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColission : MonoBehaviour {
    private PlayerState playerState;
    private Rigidbody2D rgb;
    private float rotacionCollision;
    private float velocityCollision;

	void Awake () {
       playerState = GetComponent<PlayerState>();
       rgb = GetComponent<Rigidbody2D>();
       rotacionCollision = 0.1f;
       velocityCollision = 0.3f;
	}
	
	void Update () {
        //print(rgb.velocity.y);
        //print(transform.rotation.z);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Kill")
        {
            playerState.Dead();
        }
        else if (coll.gameObject.tag == "Win" && rgb.velocity.y < -velocityCollision || transform.rotation.z < -rotacionCollision || transform.rotation.z > rotacionCollision)
        {
            playerState.Dead();
        }
        else if (coll.gameObject.tag == "Win")
        {
            playerState.Win(coll.gameObject.GetComponent<Puntaje>().getPuntaje());
        }
    }
}
