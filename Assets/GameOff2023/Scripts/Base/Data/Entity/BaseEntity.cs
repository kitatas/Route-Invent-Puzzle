namespace GameOff2023.Base.Data.Entity
{
    public abstract class BaseEntity<T>
    {
        public T value { get; private set; }

        public void Set(T t) => value = t;
    }
}