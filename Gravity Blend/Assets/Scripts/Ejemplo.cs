using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private bool canChangeGravity = true;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            gameObject.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && canChangeGravity)
        {
            _sp.flipY = !_sp.flipY;
            _rb.gravityScale = _rb.gravityScale *-1;
            canChangeGravity = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            canChangeGravity = true;
        }
    }
}
