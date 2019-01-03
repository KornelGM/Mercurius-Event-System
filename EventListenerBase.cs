/**
 * Description: Base Listens for Messages and routes them via UnityEvents.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

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
