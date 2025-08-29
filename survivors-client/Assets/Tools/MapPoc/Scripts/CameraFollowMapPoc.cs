using UnityEngine;

namespace Tools.MapPoc.Scripts
{
    public class CameraFollowMapPoc : MonoBehaviour
    {
        [SerializeField] private float smoothTime = 0.2f;
        [SerializeField] private Vector3 offset = new(0, 4f, 0);
        private Vector3 _velocity = Vector3.zero;
        private Transform _target;
        private Transform _camera;

        public Transform Target
        {
            set => _target = value;
        }

        private void Start()
        {
            _camera = Camera.main!.transform;
        }

        private void LateUpdate()
        {
            if (!_target)
                return;

            var targetPosition = _target.position + offset;
            _camera.position = Vector3.SmoothDamp(_camera.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}