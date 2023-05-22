using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaipoints : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private WayPointManager manager;

    private Vector2 _position;

    private void Awake()
    {
        _position = manager.NextPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, _position) > 0.1f)
        {
            var direction = _position - (Vector2)this.transform.position;
            this.transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            _position = manager.NextPos();

        }
    }
}
