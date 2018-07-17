/**
 * Description: Interfaces for base classes.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

public interface IEventListener<T>
{
	void OnEventRaised( T parameter );
}

public interface IEvent<T>
{
	void Broadcast( UnityEngine.GameObject gameObject, T parameter );
	void Subscribe( IEventListener<T> listener );
	void UnSubscribe( IEventListener<T> listener );
}
