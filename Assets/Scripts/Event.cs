using System.Collections.Generic;
public class Event<TSubscriber> : IEvent<TSubscriber>
{
    public delegate void EventCall(TSubscriber subscriber);
    EventCall call;
    List<TSubscriber> subscribers = new List<TSubscriber>();
    public Event(EventCall call)
    {
        this.call = call;
    }
    public void Subscribe(TSubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }
    public void Call()
    {
        foreach(var subscriber in subscribers)
        {
            call(subscriber);
        }
    }
}
