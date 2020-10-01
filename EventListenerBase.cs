/**
 * Description: Base Listens for Messages and routes them via UnityEvents.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class EventListenerBase<U, M>: MonoBehaviour, IEventListener where U : UnityEvent where M : class, IEvent
{
	[SerializeField] private M gameEvent = null;
	[SerializeField] private U response = null;

	private void Start()
	{
		Assert.IsNotNull(gameEvent);
	}

	private void OnEnable()
	{
		EventLogging.Log(LogType.Subscribed, GetType().Name, gameObject, "N/A", $"Listener on {name} subscribed.");
		gameEvent.Subscribe(this);
	}

	private void OnDisable()
	{
		EventLogging.Log(LogType.UnSubscribed, GetType().Name, gameObject, "N/A", $"Listener on {name} unsubscribed.");
		gameEvent.UnSubscribe(this);
	}

	public void OnEventRaised()
	{
		EventLogging.Log(LogType.Received, GetType().Name, gameObject, "N/A", $"Event received by listener on <b>{name}</b> GameObject. UnityEvents attached: <b>{response.GetPersistentEventCount()}</b>");
		response.Invoke();
	}
}

public class EventListenerBase<U, M, T> : MonoBehaviour, IEventListener<T> where U: UnityEvent<T> where M: class, IEvent<T>
{
	[SerializeField] private M gameEvent = null;
	[SerializeField] private U response = null;

	private void Start( )
	{
		Assert.IsNotNull( gameEvent );
	}

	private void OnEnable( )
	{
		EventLogging.Log( LogType.Subscribed, typeof(T).ToString( ), gameObject, GetType( ).Name, $"Listener on {name} subscribed." );
		gameEvent.Subscribe( this );
	}

	private void OnDisable( )
	{
		EventLogging.Log( LogType.UnSubscribed, typeof( T ).ToString( ), gameObject, GetType( ).Name, $"Listener on {name} unsubscribed." );
		gameEvent.UnSubscribe( this );
	}

	public void OnEventRaised( T parameter )
	{
		EventLogging.Log( LogType.Received, parameter.ToString( ), gameObject, GetType( ).Name, $"Event received by listener on <b>{name}</b> GameObject. Value passed: <b>{parameter}</b>. UnityEvents attached: <b>{response.GetPersistentEventCount( )}</b>" );
		response.Invoke( parameter );
	}
}

public class EventListenerBase<U, M, T, V>: MonoBehaviour, IEventListener<T,V> where U : UnityEvent<T,V> where M : class, IEvent<T,V>
{
	[SerializeField] private M gameEvent = null;
	[SerializeField] private U response = null;

	private void Start()
	{
		Assert.IsNotNull(gameEvent);
	}

	private void OnEnable()
	{
		EventLogging.Log(LogType.Subscribed, GetType().Name, gameObject, $"({typeof(T)}, {typeof(V)})", $"Listener on {name} subscribed.");
		gameEvent.Subscribe(this);
	}

	private void OnDisable()
	{
		EventLogging.Log(LogType.UnSubscribed, GetType().Name, gameObject, $"({typeof(T)}, {typeof(V)})", $"Listener on {name} unsubscribed.");
		gameEvent.UnSubscribe(this);
	}

	public void OnEventRaised(T parameter1, V parameter2)
	{
		EventLogging.Log(LogType.Received, GetType().Name, gameObject, $"({parameter1}, {parameter2})", $"Event received by listener on <b>{name}</b> GameObject. Values passed: <b>{parameter1}</b>, <b>{parameter2}</b>. UnityEvents attached: <b>{response.GetPersistentEventCount()}</b>");
		response.Invoke(parameter1, parameter2);
	}
}

