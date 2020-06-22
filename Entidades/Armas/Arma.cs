using Nez;
using System;
using System.Collections;
using System.Collections.Generic;
using ZombieSurvival.CustomLibs;

namespace Entidades
{
    public class Arma
    {
        public List<ArmaDetalles> armas;
        private TimerLib _timer;
        private Entity _entity;

        public Arma(Entity entity)
        {
            _timer = new TimerLib();

            armas = new List<ArmaDetalles>();

            armas.Add(new ArmaDetalles(7, 7, 0, 49, 1000, 1, 1));
            armas.Add(new ArmaDetalles(30, 30, 0, 90, 900, 0.5f, 0.5f));
            armas.Add(new ArmaDetalles(60, 60, 0, 120, 1500, 1.5f, 0.25f));

            _entity = entity;

        }

        public void Update(float dt)
        {
            _timer.Update(dt);
        }

        public void shoot(int armaIndex)
        {
            var intervalo = armas[armaIndex].intervalo;

            _timer.Add(delegate ()
            {
                Console.WriteLine("xd");

            }, intervalo, "disparando", true);
        }

        public void stopShoot()
        {
            _timer.Cancel("disparando");
        }



        
    }
}
