using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLimit : MonoBehaviour
{
    [SerializeField] float offsetZ;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private GameObject targetGameObject;
    Vector3 vel;
    void Start()
    {
        targetGameObject = FindObjectOfType<Ejemplo>().gameObject;
    }

    void Update()
    {

        if (targetGameObject)
        {
            var targetPosition = new Vector3(
                     Mathf.Clamp(targetGameObject.transform.position.x, minX, maxX),
                     Mathf.Clamp(targetGameObject.transform.position.y,minY, maxY),
                     offsetZ
                );

            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref vel, 0.25f);

        }

    }

}
