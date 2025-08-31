using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Features.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + offset, Time.deltaTime * speed);
        }

        [SerializeField] private Transform _target;
        public Vector3 offset;
        public float speed = 20;
    }
}
