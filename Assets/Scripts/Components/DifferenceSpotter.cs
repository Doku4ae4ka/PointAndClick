using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DifferenceSpotter : MonoBehaviour
{
    private static readonly Vector2 offset = new Vector2(0, 3.5f);

    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private ParticleSystem _particleCircle;
    [SerializeField] private ParticleSystem _particlesMirrored;
    [SerializeField] private ParticleSystem _particleCircleMirrored;
    [SerializeField] private Transform particlesParent;

    [SerializeField] private Transform[] DifferencesView;
    //[SerializeField] private Transform playingArea;
    //[SerializeField] private Transform exampleArea;
    
    private InputManager _inputManager;
    private LevelManager _levelManager;

    public event Action OnAllDifferencesSpotted;

    private bool isGamePaused = false;
    public int score = 0;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        _levelManager = LevelManager.Instance;
    }

    #region Actions
    
    private void OnEnable()
    {
        _inputManager.OnStartTouch += TouchPerfomed;
        _levelManager.OnGamePaused += PauseGame;
        _levelManager.OnGamePaused += HideTouchEffect;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= TouchPerfomed;
        _levelManager.OnGamePaused -= PauseGame;
        _levelManager.OnGamePaused -= HideTouchEffect;
    }
    
    #endregion
    
    private void TouchPerfomed(Vector2 position)
    {
        if (isGamePaused) return;
        
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(position);
        //TryShowTouchEffect(touchPosition);
        
        if (touchPosition.y < 0)
        {
            touchPosition += offset;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 0.01f);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Difference"))
        {
            ShowTouchEffect(touchPosition);
            ShowTouchEffectOnSecondImage(touchPosition);
            GameObject difference = hit.collider.gameObject;
            difference.SetActive(false);
            DifferencesView[score].GetComponent<Image>().color = Color.white;
            score++;
        }
        
        CheckDifferences();
    }
    
    private void CheckDifferences()
    {
        if (score == DifferencesView.Length)
        {
            OnAllDifferencesSpotted?.Invoke();
        }
    }
    
    private void PauseGame(bool isPause) => isGamePaused = isPause;
    
    #region Effects
    
    // private void TryShowTouchEffect(Vector2 touchPosition)
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 0.01f);
    //     if (hit.collider != null && (hit.collider.gameObject.CompareTag("Difference") || hit.collider.gameObject.CompareTag("Background")))
    //     {
    //         ShowTouchEffect(touchPosition);
    //         ShowTouchEffectOnSecondImage(touchPosition);
    //     }
    // }

    private void ShowTouchEffect(Vector2 position)
    {
        PlayParticles(_particles, _particleCircle, position);
    }
    
    private void ShowTouchEffectOnSecondImage(Vector2 originalPosition)
    {
        
        Vector2 mirroredPosition = originalPosition.y >= 0 ? originalPosition - offset : originalPosition + offset;
        PlayParticles(_particlesMirrored, _particleCircleMirrored, mirroredPosition);

    }

    private void PlayParticles(ParticleSystem particleSystem1, ParticleSystem particleSystem2, Vector2 position)
    {
        particleSystem1.transform.position = position;
        particleSystem2.transform.position = position;
        particleSystem2.Play();
        particleSystem1.Play();
    }

    private void HideTouchEffect(bool isPause)
    {
        particlesParent.position = new Vector3(0, 10, 0);
        _particles.gameObject.SetActive(!isPause);
        _particleCircle.gameObject.SetActive(!isPause);
        _particlesMirrored.gameObject.SetActive(!isPause);
        _particleCircleMirrored.gameObject.SetActive(!isPause);
        
    }

    #endregion

}