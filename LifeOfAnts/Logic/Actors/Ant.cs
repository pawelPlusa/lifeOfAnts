using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public abstract class Ant:Actor
    {
        public Ant(Cell cell)
            : base(cell) { }

        public abstract void GenerateAnts(ref HiveMap map);
        public virtual bool WaspAlert()
        {
            throw new NotImplementedException();
        }

        public virtual void GetDirection(Object whatIsInAOI)
        {

        }

    };
}
