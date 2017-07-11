using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    [SerializeField]
    private GameObject mundoObjet;
    private Mundo mundo;
    public delegate void Funcion(int numero);
    public Funcion win;

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
        PlayerPrefs.SetInt("Score", 0);
    }
    public void Win(int score)
    {
        win(score);
        mundo.ChangeScene("Win");
    }
}
