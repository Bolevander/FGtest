using System.Collections.Generic;
using UnityEngine;

public sealed class ParticleSystemMediator
{
    private readonly List<ParticleSystem> _particleSystems = new List<ParticleSystem>();

    public void AddSystem(ParticleSystem particleSystem)
    {
        _particleSystems.Add(particleSystem);
    }
    
    public void ReplayParticles()
    {
        for (int i = 0; i < _particleSystems.Count; i++)
        {
            _particleSystems[i].Stop();
            _particleSystems[i].Clear();
            _particleSystems[i].Play();
        }
    }
}