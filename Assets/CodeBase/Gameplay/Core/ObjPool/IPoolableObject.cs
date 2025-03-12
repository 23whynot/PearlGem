namespace CodeBase.Gameplay.Core.ObjPool
{
    public interface IPoolableObject
    {
        public bool IsActive {get; }
        public void Activate();
        public void Deactivate();
    }
}