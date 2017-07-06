using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColission : MonoBehaviour {
    private PlayerState playerState;
    private Rigidbody2D rgb;

	void Awake () {
       playerState = GetComponent<PlayerState>();
       rgb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        print(rgb.velocity.y);
        print(transform.rotation.z);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Kill")
        {
            playerState.Dead();
        }
        else if (coll.gameObject.tag == "Win" && rgb.velocity.y < -0.3f || transform.rotation.z < -0.1f || transform.rotation.z > 0.1f)
        {
            playerState.Dead();
        }
        else if (coll.gameObject.tag == "Win")
        {
            playerState.Win();
        }
    }
}
