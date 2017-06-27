using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

    public void Dead()
    {
        print("asdad");
        Destroy(gameObject);
    }
}
