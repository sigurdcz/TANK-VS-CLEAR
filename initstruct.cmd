@echo off

:: Base directory
set BASE_DIR=%~dp0

:: Function to create a directory and add a file with content
:CreateDirAndFile
if not exist %1 mkdir %1
echo %~2 > %1\%3.cs
exit /b

:: Create directory structure and files with content
call :CreateDirAndFile "%BASE_DIR%Modules\GameSettings\Model" "public class SettingsModel { }" "SettingsModel"
call :CreateDirAndFile "%BASE_DIR%Modules\GameSettings\View" "using UnityEngine;

public class SettingsView : MonoBehaviour
{
    public void ToggleSound(bool isOn)
    {
        // Update UI based on sound settings
    }
}" "SettingsView"
call :CreateDirAndFile "%BASE_DIR%Modules\GameSettings\Controller" "using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public SettingsModel settingsModel;
    public SettingsView settingsView;

    void Start()
    {
        settingsModel = new SettingsModel();
        settingsView = FindObjectOfType<SettingsView>();

        EventBus.Subscribe<SoundToggleEvent>(OnSoundToggle);
    }

    private void OnSoundToggle(object eventArgs)
    {
        settingsModel.isSoundOn = !settingsModel.isSoundOn;
        settingsView.ToggleSound(settingsModel.isSoundOn);
    }
}" "SettingsController"

call :CreateDirAndFile "%BASE_DIR%Modules\Round\Model" "public class RoundModel { public int currentRound = 1; public int maxRounds = 3; }" "RoundModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Round\View" "using UnityEngine;

public class RoundEndView : MonoBehaviour
{
    public GameObject roundEndMenu;

    public void ShowRoundEnd()
    {
        roundEndMenu.SetActive(true);
        Time.timeScale = 0;
    }
}" "RoundEndView"
call :CreateDirAndFile "%BASE_DIR%Modules\Round\Controller" "using UnityEngine;

public class RoundController : MonoBehaviour
{
    public RoundModel roundModel;
    public RoundEndView roundEndView;

    void Start()
    {
        roundModel = new RoundModel();
        roundEndView = FindObjectOfType<RoundEndView>();
        EventBus.Subscribe<RoundEndEvent>(OnRoundEndEvent);
    }

    private void OnRoundEndEvent(object eventArgs)
    {
        roundEndView.ShowRoundEnd();
    }
}" "RoundController"

call :CreateDirAndFile "%BASE_DIR%Modules\Match\Model" "public class MatchModel { public int player1Wins = 0; public int player2Wins = 0; }" "MatchModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Match\View" "using UnityEngine;

public class MatchEndView : MonoBehaviour
{
    public GameObject matchEndMenu;

    public void ShowMatchEnd()
    {
        matchEndMenu.SetActive(true);
        Time.timeScale = 0;
    }
}" "MatchEndView"
call :CreateDirAndFile "%BASE_DIR%Modules\Match\Controller" "using UnityEngine;

public class MatchController : MonoBehaviour
{
    public MatchModel matchModel;
    public MatchEndView matchEndView;

    void Start()
    {
        matchModel = new MatchModel();
        matchEndView = FindObjectOfType<MatchEndView>();
        EventBus.Subscribe<MatchEndEvent>(OnMatchEndEvent);
    }

    private void OnMatchEndEvent(object eventArgs)
    {
        matchEndView.ShowMatchEnd();
    }
}" "MatchController"

call :CreateDirAndFile "%BASE_DIR%Modules\Tank\Model" "public class TankModel { }" "TankModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Tank\View" "using UnityEngine;

public class TankView : MonoBehaviour { }" "TankView"
call :CreateDirAndFile "%BASE_DIR%Modules\Tank\Controller" "using UnityEngine;

public class TankController : MonoBehaviour, IInitializable
{
    public TankModel tankModel;
    public TankView tankView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        tankModel = new TankModel();
        tankView = FindObjectOfType<TankView>();
    }

    public void Heal()
    {
        EventBus.Publish(new HealEvent(this));
    }

    public void AddShield()
    {
        // Add shield logic
    }

    public void EnableMultiShot()
    {
        // Enable multi-shot logic
    }
}" "TankController"

call :CreateDirAndFile "%BASE_DIR%Modules\Cannon\Model" "public class CannonModel { public float rotationSpeed = 45f; }" "CannonModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Cannon\View" "using UnityEngine;

public class CannonView : MonoBehaviour
{
    public Transform barrel;

    public void Rotate(float angle)
    {
        barrel.localRotation = Quaternion.Euler(0, 0, angle);
    }
}" "CannonView"
call :CreateDirAndFile "%BASE_DIR%Modules\Cannon\Controller" "using UnityEngine;

public class CannonController : MonoBehaviour, IInitializable
{
    public CannonModel cannonModel;
    public CannonView cannonView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        cannonModel = new CannonModel();
        cannonView = FindObjectOfType<CannonView>();
    }

    void Update()
    {
        float angle = Mathf.PingPong(Time.time * cannonModel.rotationSpeed, 45) - 22.5f;
        cannonView.Rotate(angle);
    }
}" "CannonController"

call :CreateDirAndFile "%BASE_DIR%Modules\Shooting\Model" "public class ShootingModel { public float fireForce = 10f; public GameObject projectilePrefab; }" "ShootingModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Shooting\View" "using UnityEngine;

public class ShootingView : MonoBehaviour
{
    public Transform firePoint;

    public void Fire(float force, GameObject projectilePrefab)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}" "ShootingView"
call :CreateDirAndFile "%BASE_DIR%Modules\Shooting\Controller" "using UnityEngine;

public class ShootingController : MonoBehaviour, IInitializable
{
    public ShootingModel shootingModel;
    public ShootingView shootingView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        shootingModel = new ShootingModel();
        shootingView = FindObjectOfType<ShootingView>();
        EventBus.Subscribe<FireEvent>(OnFireEvent);
    }

    private void OnFireEvent(object eventArgs)
    {
        shootingView.Fire(shootingModel.fireForce, shootingModel.projectilePrefab);
    }
}" "ShootingController"

call :CreateDirAndFile "%BASE_DIR%Modules\Health\Model" "public class HealthModel { public int lives = 2; }" "HealthModel"
call :CreateDirAndFile "%BASE_DIR%Modules\Health\View" "using UnityEngine;

public class HealthView : MonoBehaviour
{
    public void UpdateLives(int lives)
    {
        // Update the UI to reflect the new life count
    }
}" "HealthView"
call :CreateDirAndFile "%BASE_DIR%Modules\Health\Controller" "using UnityEngine;

public class HealthController : MonoBehaviour, IInitializable
{
    public HealthModel healthModel;
    public HealthView healthView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        healthModel = new HealthModel();
        healthView = FindObjectOfType<HealthView>();
    }

    public void TakeDamage()
    {
        healthModel.lives--;
        healthView.UpdateLives(healthModel.lives);
        if (healthModel.lives <= 0)
        {
            // Handle tank destruction
        }
    }

    public void Heal()
    {
        healthModel.lives++;
        healthView.UpdateLives(healthModel.lives);
    }
}" "HealthController"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUp\Model" "public class PowerUpModel { public float duration; }" "PowerUpModel"
call :CreateDirAndFile "%BASE_DIR%Modules\PowerUp\View" "using UnityEngine;

public class PowerUpView : MonoBehaviour
{
    void Update()
    {
        // Logic for falling power-up
        transform.Translate(Vector2.down * Time.deltaTime);
    }
}" "PowerUpView"
call :CreateDirAndFile "%BASE_DIR%Modules\PowerUp\Controller" "using UnityEngine;

public class PowerUpController : MonoBehaviour, IInitializable
{
    public PowerUpModel powerUpModel;
    public PowerUpView powerUpView;
    public GameObject powerUpPrefab;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        powerUpModel = new PowerUpModel();
        powerUpView = FindObjectOfType<PowerUpView>();
        EventBus.Subscribe<PowerUpSpawnEvent>(OnPowerUpSpawnEvent);
    }

    private void OnPowerUpSpawnEvent(object eventArgs)
    {
        // Logic to spawn a power-up
        Instantiate(powerUpPrefab, GetRandomSpawnPosition(), Quaternion.identity);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        // Return a random position within the game bounds
        float x = Random.Range(-8f, 8f);
        float y = 6f; // Spawn from the top of the screen
        return new Vector2(x, y);
    }
}" "PowerUpController"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Model" "public class PowerUpApplierModel { }" "PowerUpApplierModel"
call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\View" "using UnityEngine;

public class PowerUpApplierView : MonoBehaviour
{
    // Methods to visually show power-up effects on the tank
}" "PowerUpApplierView"
call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "using UnityEngine;

public class PowerUpApplierController : MonoBehaviour, IInitializable
{
    public PowerUpApplierModel powerUpApplierModel;
    public PowerUpApplierView powerUpApplierView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        powerUpApplierModel = new PowerUpApplierModel();
        powerUpApplierView = FindObjectOfType<PowerUpApplierView>();
        EventBus.Subscribe<PowerUpApplyEvent>(OnPowerUpApplyEvent);
    }

    private void OnPowerUpApplyEvent(object eventArgs)
    {
        // Logic to apply power-up to the tank
        PowerUpApplyEvent powerUpApplyEvent = (PowerUpApplyEvent)eventArgs;
        TankController tank = powerUpApplyEvent.tank;
        ApplyPowerUp(tank, powerUpApplyEvent.powerUp);
    }

    private void ApplyPowerUp(TankController tank, object powerUp)
    {
        if (powerUp is HealPowerUp)
        {
            tank.Heal();
        }
        else if (powerUp is ShieldPowerUp)
        {
            tank.AddShield();
        }
        else if (powerUp is MultiShotPowerUp)
        {
            tank.EnableMultiShot();
        }
    }
}" "PowerUpApplierController"

call :CreateDirAndFile "%BASE_DIR%Core" "using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, List<Action<object>>> eventListeners = new Dictionary<Type, List<Action<object>>>();

    public static void Subscribe<T>(Action<object> listener)
    {
        var eventType = typeof(T);
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<Action<object>>();
        }
        eventListeners[eventType].Add(listener);
    }

    public static void Unsubscribe<T>(Action<object> listener)
    {
        var eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].Remove(listener);
        }
    }

    public static void Publish<T>(T eventArgs)
    {
        var eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            foreach (var listener in eventListeners[eventType])
            {
                listener(eventArgs);
            }
        }
    }
}" "EventBus"

call :CreateDirAndFile "%BASE_DIR%Core" "using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private List<IInitializable> initializables = new List<IInitializable>();

    void Start()
    {
        InitializeModules();
    }

    private void InitializeModules()
    {
        foreach (var initializable in initializables)
        {
            initializable.Initialize();
        }
    }

    public void RegisterModule(IInitializable module)
    {
        initializables.Add(module);
    }
}" "EntryPoint"

call :CreateDirAndFile "%BASE_DIR%Core" "public interface IInitializable
{
    void Initialize();
}" "IInitializable"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "public class HealPowerUp
{
    // Properties specific to Heal power-up
}

public class ShieldPowerUp
{
    // Properties specific to Shield power-up
}

public class MultiShotPowerUp
{
    // Properties specific to MultiShot power-up
}" "PowerUpClasses"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "using UnityEngine;

public class TankController : MonoBehaviour, IInitializable
{
    public TankModel tankModel;
    public TankView tankView;

    void Start()
    {
        RegisterToEntryPoint();
    }

    private void RegisterToEntryPoint()
    {
        EntryPoint entryPoint = FindObjectOfType<EntryPoint>();
        entryPoint.RegisterModule(this);
    }

    public void Initialize()
    {
        tankModel = new TankModel();
        tankView = FindObjectOfType<TankView>();
    }

    public void Heal()
    {
        EventBus.Publish(new HealEvent(this));
    }

    public void AddShield()
    {
        // Add shield logic
    }

    public void EnableMultiShot()
    {
        // Enable multi-shot logic
    }
}" "TankController"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "public class PowerUpApplyEvent
{
    public TankController tank;
    public object powerUp;

    public PowerUpApplyEvent(TankController tank, object powerUp)
    {
        this.tank = tank;
        this.powerUp = powerUp;
    }
}" "PowerUpApplyEvent"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "public class PowerUpSpawnEvent
{
    // Properties related to power-up spawn event
}" "PowerUpSpawnEvent"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "public class FireEvent
{
    // Properties related to fire event
}" "FireEvent"

call :CreateDirAndFile "%BASE_DIR%Modules\PowerUpApplier\Controller" "public class HealEvent
{
    public TankController Tank;

    public HealEvent(TankController tank)
    {
        Tank = tank;
    }
}" "HealEvent"

echo Hierarchy and files created successfully!
pause
