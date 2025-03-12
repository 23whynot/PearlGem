using CodeBase.Gameplay.Balls.Player;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.FirePoint
{
    public class ProjectileTrajectory : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private int resolution = 100;

        private Transform _spawnPoint;
        private float _initialSpeed;
        private Vector3[] _pointsCache;

        private IInputService _inputService;
        private IBallCountController _ballCountController;
        private bool _isDrawingTrajectory = true;

        [Inject]
        public void Construct(IInputService inputService, IBallCountController ballCountController)
        {
            _ballCountController = ballCountController;
            _inputService = inputService;
        }

        private void Start()
        {
            _ballCountController.OnBallsEnd += StopDrawTrajectory;
            _inputService.OnRelease += DisableTrajectory;
            SetTrajectoryVisibility(false);
        }

        private void Update()
        {
            if (_isDrawingTrajectory)
                SetTrajectoryVisibility(_inputService.IsHolding());
        }
        
        private void OnDestroy()
        {
            _ballCountController.OnBallsEnd -= StopDrawTrajectory;
            _inputService.OnRelease -= DisableTrajectory;
        }

        private void StopDrawTrajectory() => _isDrawingTrajectory = false;

        public void SetupTrajectory(Transform spawn, float speed)
        {
            _spawnPoint = spawn;
            _initialSpeed = speed;
            SetTrajectoryVisibility(false);
        }

        public void DrawTrajectory(float horizontalAngleOffset, float verticalAngleOffset)
        {
            SetTrajectoryVisibility(true);

            if (IsCacheInvalid())
                _pointsCache = new Vector3[resolution];

            TrajectoryCalculator.FillTrajectoryPoints
            (_spawnPoint.position, CalculateLaunchVelocity(horizontalAngleOffset, verticalAngleOffset),
                _pointsCache, 2f);

            UpdateLineRenderer(_pointsCache);
        }

        private void UpdateLineRenderer(Vector3[] pointsCache)
        {
            lineRenderer.positionCount = pointsCache.Length;
            lineRenderer.SetPositions(pointsCache);
        }

        public Vector3 CalculateLaunchVelocity(float horizontalAngle, float verticalAngle)
        {
            float verticalRad = Mathf.Deg2Rad * verticalAngle;
            float horizontalRad = Mathf.Deg2Rad * horizontalAngle;

            Vector3 direction = new Vector3(
                Mathf.Cos(verticalRad) * Mathf.Sin(horizontalRad),
                Mathf.Sin(verticalRad),
                Mathf.Cos(verticalRad) * Mathf.Cos(horizontalRad)
            );

            return direction.normalized * _initialSpeed;
        }

        private bool IsCacheInvalid() => _pointsCache == null || _pointsCache.Length != resolution;

        private void DisableTrajectory() => SetTrajectoryVisibility(false);

        private void SetTrajectoryVisibility(bool visible) => lineRenderer.enabled = visible;
    }
}