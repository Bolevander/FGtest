using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator),
    typeof(ParticleSystem),
    typeof(AudioSource))]
public sealed class CustomButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _pressedAnimationName = "Pressed";
    
    private Animator _animator;
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayAnimator();
        PlayParticles();
        PlayAudio();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayAnimator()
    {
        _animator.StopPlayback();
        _animator.Play(_pressedAnimationName);
    }
    
    private void PlayParticles()
    {
        _particleSystem.Stop();
        _particleSystem.Clear();
        _particleSystem.Play();
    }
    
    private void PlayAudio()
    {
        _audioSource.Stop();
        _audioSource.time = 5f;
        _audioSource.Play();
    }
}