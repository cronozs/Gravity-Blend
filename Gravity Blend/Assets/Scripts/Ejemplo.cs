using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            _rb.gravityScale = _rb.gravityScale *-1;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet);
        }
    }


}
