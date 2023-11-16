using UniRx;

namespace GameOff2023.Base.Domain.UseCase
{
    public abstract class BaseModelUseCase<T>
    {
        private readonly ReactiveProperty<T> _property;

        protected BaseModelUseCase()
        {
            _property = new ReactiveProperty<T>();
        }

        public IReadOnlyReactiveProperty<T> property => _property;

        public T currentValue => property.Value;

        public virtual void Set(T value)
        {
            _property.Value = value;
        }
    }
}