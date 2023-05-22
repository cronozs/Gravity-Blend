using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private GameObject points;
    private GameObject[] accesos;

    // Start is called before the first frame update
    void Start()
    {
        accesos = points.GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(accesos);
        
    }

    void Recorrido()
    {
        
    }

    IEnumerator Mover(Transform point)
    {
        yield return null;
    }
}
