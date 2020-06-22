using Nez;
using System;

namespace Entidades
{
    public class Colisionador : Component, ITriggerListener
    {
        void ITriggerListener.OnTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine("OnTriggerEnter: {0}", other.Entity.Name);
        }

        void ITriggerListener.OnTriggerExit(Collider other, Collider local)
        {
            Console.WriteLine("OnTriggerEnter: {0}", other.Entity.Name);
        }
    }
}
