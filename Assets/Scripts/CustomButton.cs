using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator),
    typeof(ParticleSystem),
    typeof(AudioSource))]
public sealed class CustomButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _pressedAnimationName = "Pressed";
    
    private Animator _animator;
    private AudioSource _audioSource;
    private ParticleSystemMediator _particleSystemMediator;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayAnimator();
        ReplayParticles();
        PlayAudio();
    }

    public void Initialize(ParticleSystemMediator particleSystemMediator)
    {
        _animator = GetComponent<Animator>();
        var localParticleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        _particleSystemMediator = particleSystemMediator;
        _particleSystemMediator.AddSystem(localParticleSystem);
    }

    private void PlayAnimator()
    {
        _animator.StopPlayback();
        _animator.Play(_pressedAnimationName);
    }
    
    private void ReplayParticles()
    {
        _particleSystemMediator.ReplayParticles();
    }
    
    private void PlayAudio()
    {
        _audioSource.Stop();
        _audioSource.time = 5f;
        _audioSource.Play();
    }
}