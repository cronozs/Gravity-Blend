using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    [SerializeField] private Canvas loose;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private bool _canDamage = true;
    private bool canChangeGravity = true;
    public float hp;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
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
            bullet.transform.position = gameObject.transform.position + new Vector3(1, 0, 0);
            bullet.transform.rotation = new Quaternion(0, 0, 90,90);
            Instantiate(bullet);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.gravityScale *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            canChangeGravity = true;
        }

        if(collision.tag == "Enemy" && _canDamage)
        {
            Enemigo damage;
            damage = collision.GetComponent<Enemigo>();
            hp -= damage.damage;
            _canDamage = false;
            Verify();
            StartCoroutine(Delay());
        }

        if (collision.tag == "Kill")
        {
            loose.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Verify()
    {
        if (hp <= 0)
        {
            loose.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
