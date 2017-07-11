using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour {
    private int puntaje;
    [SerializeField]
    private Text puntajeText;

	void Start () {
        puntaje = Random.Range(0, 100);
        puntajeText.text = "" + puntaje;
	}
	
	public int getPuntaje()
    {
        return puntaje;
    }
}
