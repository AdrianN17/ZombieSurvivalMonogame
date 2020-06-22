using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proyectil : Component, IUpdatable
    {
        public Vector2 Velocity;

        ProjectileMover _mover;

        public override void OnAddedToEntity() {

            Velocity = new Vector2(100,0);

            _mover = Entity.GetComponent<ProjectileMover>();
        }

        public void Update()
        {
            _mover.Move(Velocity * Time.DeltaTime);
        }
    }
}
