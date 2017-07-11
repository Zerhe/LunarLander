using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour {
    private Rigidbody2D rgb;
    private SpriteRenderer rend;
    [SerializeField]
    private Sprite spriteInmovil;
    [SerializeField]
    private Sprite spriteAcelerar;
    [SerializeField]
    private Slider sliderFuel;
    [SerializeField]
    private Text velocityHorizontalText;
    [SerializeField]
    private Text velocityVerticalText;
    private float vel;
    private float velRot;
    private int fuel;
    private float limiteRotacion;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Start ()
    {
        vel = 20f;
        velRot = 2f;
        fuel = 500;
        limiteRotacion = 0.70f;
        ImpulsoInicial();
    }

    void FixedUpdate()
    {
        Acelerar();
        Rotar();
    }
    void Update ()
    {
        sliderFuel.value = fuel;
        velocityHorizontalText.text = "Velocity Horizontal: " + rgb.velocity.x * 10;
        velocityVerticalText.text = "Velocity Vertical: " + rgb.velocity.y * 10;
    }
    void ImpulsoInicial()
    {
        float velImpulsoIni = 20;
        rgb.AddRelativeForce(Vector2.right * Time.deltaTime * velImpulsoIni, ForceMode2D.Impulse);
    }
    void Acelerar()
    {
        if (Input.GetButton("Aceleration") && fuel > 0)
        {
            fuel--;
            rgb.AddRelativeForce(Vector2.up * Time.deltaTime * vel, ForceMode2D.Force);
            rend.sprite = spriteAcelerar;
        }
        else
            rend.sprite = spriteInmovil;
    }
    void Rotar()
    {
        if (Input.GetButton("RotarDer") && transform.rotation.z > -limiteRotacion)
        {
            rgb.AddTorque(-velRot);
        }
        else if (Input.GetButton("RotarIzq") && transform.rotation.z < limiteRotacion)
        {
            rgb.AddTorque(velRot);
        }
        else
        {
            rgb.angularVelocity = 0;
        }
    }
}
