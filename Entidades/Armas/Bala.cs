using Microsoft.Xna.Framework;
using Nez;

namespace Entidades
{
    public class Bala : Component, IUpdatable
    {
        public Vector2 _velocity;

        public float tipo;

        public ProjectileMover _mover;

        public override void OnAddedToEntity()
        {
            _mover = Entity.GetComponent<ProjectileMover>();
        }

        public void Update()
        {
            _mover.Move(_velocity * Time.DeltaTime);
        }
    }
}
