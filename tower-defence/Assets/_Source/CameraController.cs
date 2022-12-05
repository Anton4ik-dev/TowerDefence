using System;
using UnityEngine;

namespace _Source
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed;

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                var y = -Input.GetAxis("Mouse X") * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, y,0);
            }
        }
    }
}
