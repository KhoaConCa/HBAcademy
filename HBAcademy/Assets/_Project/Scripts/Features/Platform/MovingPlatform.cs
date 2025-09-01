using UnityEngine;

namespace Vox.Features.Platform
{
    /// <summary>
    /// MovingPlatform - A Platform can move Up/Down or Left/Right.<br/>
    /// Developer: Dương Nhật Khoa - created on: 01/09/2025.
    /// </summary>
    public class MovingPlatform : MonoBehaviour
    {
        #region --- Unity Methods ---

        private void Start()
        {
            transform.position = _aPoint.position;
            _target = _bPoint.position;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _aPoint.position) < 0.1f)
            {
                _target = _bPoint.position;
            }
            else if (Vector3.Distance(transform.position, _bPoint.position) < 0.1f)
            {
                _target = _aPoint.position;
            }
        }

        #endregion

        #region --- Methods ---

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.collider.transform.SetParent(transform);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.collider.transform.SetParent(null);
            }
        }

        #endregion

        #region --- Fields ---

        [SerializeField] private Transform _aPoint, _bPoint;
        [SerializeField] private float _speed;

        private Vector3 _target;

        #endregion
    }
}
