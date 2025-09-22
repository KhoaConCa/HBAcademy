using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Features.Camera
{
    /// <summary>
    /// CameraFollow - Make the camera follow the target.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        #region --- Unity Methods ---

        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + offset, Time.deltaTime * speed);
        }

        #endregion

        #region --- Fields ---

        [SerializeField] private Transform _target;
        public Vector3 offset;
        public float speed = 20;

        #endregion
    }
}
