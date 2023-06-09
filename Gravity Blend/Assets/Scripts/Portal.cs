using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private Canvas end;
    private int _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && gameObject.tag == "NexLevel")
        {
            _scene += 1;
            SceneManager.LoadScene(_scene);
        }
        if (collision.tag == "Player" && gameObject.tag == "End")
        {
            end.gameObject.SetActive(true);
        }
    }
}
