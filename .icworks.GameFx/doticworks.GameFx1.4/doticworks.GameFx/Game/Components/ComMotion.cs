using System;
using System.ComponentModel;
using System.Reflection.Emit;

namespace doticworks.GameFx.Game.Components
{
    public class ComMotion:ComEvent
    {
        public float vx;
        public float vy;
        public float ax;
        public float ay;
        public float a_friction = 0;
        
        public ComMotion()
        {
            OnUpdate = (delta) =>
            {
                vx += ax * delta;
                vy += ay * delta;
                if (vx > a_friction * delta) vx = vx - a_friction * delta;
                if (vx < a_friction * delta&&vx>0) vx = 0;
                if (vx > -a_friction * delta&&vx<0) vx = 0;
                if (vx < -a_friction * delta) vx = vx + a_friction * delta;
                if (vy > a_friction * delta) vy = vy - a_friction * delta;
                if (vy < a_friction * delta&&vy>0) vy = 0;
                if (vy > -a_friction * delta&&vy<0) vy = 0;
                if (vy < -a_friction * delta) vy = vy + a_friction * delta;
                Owner.x += vx * delta;
                Owner.y += vy * delta;
            };
        }
    }
}