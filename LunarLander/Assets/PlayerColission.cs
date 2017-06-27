using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColission : MonoBehaviour {
    private PlayerState playerState;

	void Awake () {
       playerState = GetComponent<PlayerState>();
	}
	
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Kill")
        {
            playerState.Dead();
        }
    }
}
