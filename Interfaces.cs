/**
 * Description: Interfaces for base classes.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

public interface IEventListener
{
	void OnEventRaised();
}

public interface IEvent
{
	void Broadcast(UnityEngine.GameObject gameObject);
	void Subscribe(IEventListener listener);
	void UnSubscribe(IEventListener listener);
}

public interface IEventListener<T>
{
	void OnEventRaised(T parameter);
}

public interface IEvent<T>
{
	void Broadcast(UnityEngine.GameObject gameObject, T parameter);
	void Subscribe(IEventListener<T> listener);
	void UnSubscribe(IEventListener<T> listener);
}

public interface IEventListener<T, U>
{
	void OnEventRaised(T parameter1, U parameter2);
}

public interface IEvent<T, U>
{
	void Broadcast(UnityEngine.GameObject gameObject, T parameter1, U parameter2);
	void Subscribe(IEventListener<T, U> listener);
	void UnSubscribe(IEventListener<T, U> listener);
}
