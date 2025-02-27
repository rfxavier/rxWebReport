using System;

namespace rxWebReport.Domain
{
    public abstract class Entity
    {
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public bool Active { get; protected set; } = true;
    }
}