using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace doticworks.GameFx.Game.Components
{
    public class ComMotion:ComEvent
    {
        public override void Load(ComponentModel model)
        {
            base.Load(model);
        }

        public float vx;
        public float vy;
        public float ax;
        public float ay;
        public float a_friction = 0;

        public List<ValueTuple<float, float>> forces=new List<ValueTuple<float, float>>();
        
        public ComMotion()
        {
            OnUpdate = (delta) =>
            {
                float tax = ax;
                float tay = ay;
                for (int i = 0; i < forces.Count; i++)
                {
                    tax += forces[i].Item1;
                    tay += forces[i].Item2;
                }
                vx += tax * delta;
                vy += tay * delta;
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