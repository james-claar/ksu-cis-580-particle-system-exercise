

using Microsoft.Xna.Framework;

namespace ParticleSystemExercise;

public interface IParticleEmitter
{
    public Vector2 Position { get; }

    public Vector2 Velocity { get; }
}
