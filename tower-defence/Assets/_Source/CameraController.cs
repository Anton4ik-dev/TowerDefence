using DG.Tweening;
using UnityEngine;

namespace _Source
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float endAngel;
        private Quaternion _startRotation;
        private bool _isRotate;

        private void Start()
        {
            _startRotation = transform.rotation;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isRotate == false)
                {
                    transform.DORotate(new Vector3(0, endAngel, 0), speed);
                    _isRotate = true;
                }
                else
                {
                    transform.DORotateQuaternion(_startRotation, speed);
                    _isRotate = false;
                }
            }
        }
    }
}
