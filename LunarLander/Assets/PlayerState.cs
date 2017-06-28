using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    [SerializeField]
    private GameObject mundoObjet;
    private Mundo mundo;
	void Awake () {
        mundoObjet = GameObject.Find("Mundo");
        mundo = mundoObjet.GetComponent<Mundo>();
	}
	
	void Update () {
	}

    public void Dead()
    {
        print("asda");
        mundo.ChangeScene("Lose");
    }
    public void Win()
    {
        mundo.ChangeScene("Win");
    }
}
