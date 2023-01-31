public interface IEvent<THandler>
{
    void Subscribe(THandler handler);
}
