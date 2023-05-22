using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private int _position;

    public Vector2 NextPos()
    {
        if (_position >= this.transform.childCount)
        {
            _position = 0;
        }
        var position = transform.GetChild(_position).position;
        _position++;
        return position;
    }
}
