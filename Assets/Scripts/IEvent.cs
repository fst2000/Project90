public interface IEvent
{
    void Subscribe(EventDelegate method);
}
public delegate void EventDelegate();