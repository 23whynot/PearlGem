using CodeBase.Gameplay.Balls.Player;
using CodeBase.Gameplay.Controllers.LevelEnd;
using CodeBase.Gameplay.Factory;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.FirePoint
{
    public class DirectionalArc : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float initialSpeed = 50f;
        [SerializeField] private int bonusBallCount = 2;

        [Header("Параметри траекторіі")] [SerializeField]
        private ProjectileTrajectory projectileTrajectory;

        [SerializeField] private float horizontalAdjustmentSpeed = 60f;
        [SerializeField] private float verticalAdjustmentSpeed = 30f;

        private GameObject _currentBall;
        private bool _firstPress = true;
        private bool _inputAllowed = true;
        private float _horizontalAngleOffset;
        private float _verticalAngleOffset;

        private ISphereFactory _sphereFactory;
        private IInputService _inputService;
        private IBallCountController _ballCountController;
        private ILevelEndController _levelEndController;

        [Inject]
        public void Construct(ISphereFactory sphereFactory, IInputService inputService,
            IBallCountController ballCountController, ILevelEndController levelEndController)
        {
            _levelEndController = levelEndController;
            _ballCountController = ballCountController;
            _sphereFactory = sphereFactory;
            _inputService = inputService;
        }

        private void Awake()
        {
            _ballCountController.InitBallCount(bonusBallCount);
            _sphereFactory.Init();
        }

        private void Start()
        {
            SpawnBall();
            UpdateTrajectory();

            _levelEndController.OnLevelEnded += StopInput;
            _ballCountController.OnBallsEnd += StopInput;
            _inputService.OnRelease += LaunchBall;
        }

        private void Update()
        {
            if (!_inputAllowed)
                return;

            if (!_inputService.IsHolding())
                return;

            if (_firstPress)
            {
                _verticalAngleOffset = 10f;
                _firstPress = false;
            }
            else
            {
                _verticalAngleOffset =
                    Mathf.Clamp(
                        _verticalAngleOffset + _inputService.GetVertical() * verticalAdjustmentSpeed * Time.deltaTime,
                        -45f, 45f);
            }

            _horizontalAngleOffset += _inputService.GetHorizontal() * horizontalAdjustmentSpeed * Time.deltaTime;

            projectileTrajectory.DrawTrajectory(_horizontalAngleOffset, _verticalAngleOffset);
        }

        private void OnDestroy()
        {
            _levelEndController.OnLevelEnded -= StopInput;
            _ballCountController.OnBallsEnd -= StopInput;
            _inputService.OnRelease -= LaunchBall;
        }

        private void LaunchBall()
        {
            if (!_inputAllowed) 
                return;
            _ballCountController.OnShoot();

            Rigidbody rb = _currentBall.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity =
                projectileTrajectory.CalculateLaunchVelocity(_horizontalAngleOffset, _verticalAngleOffset);

            _firstPress = true;
            SpawnBall();
        }

        private void UpdateTrajectory()
        {
            projectileTrajectory.SetupTrajectory(spawnPoint, initialSpeed);
            projectileTrajectory.DrawTrajectory(_horizontalAngleOffset, _verticalAngleOffset);
        }

        private void StopInput() => _inputAllowed = false;

        private void SpawnBall() => _currentBall = _sphereFactory.CreatePlayerBall(spawnPoint);
    }
}