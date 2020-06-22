using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidades
{
    public static class ObjectGroup
    {
        public static void LeerTmx(TmxObjectGroup objectGroup, Entity defaultCollidable)
        {

            foreach(var obj in objectGroup.Objects) 
            {
                var properties = obj.Properties;

                if (properties != null)
                {
                    CrearSolidos(obj , properties, defaultCollidable);
                }
                
            }
        }

        public static void CrearSolidos(TmxObject obj, Dictionary<string,string> properties, Entity defaultCollidable)
        {

            if(properties["Collidable"] == "true")
            {
                defaultCollidable.AddComponent(new BoxCollider(obj.X,obj.Y,obj.Width,obj.Height));
            }
        }



    }
}
