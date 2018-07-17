/**
 * Description: Base Scriptable Object that serves simultaneously the role of the Message and Message Center.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using System.Collections.Generic;
using UnityEngine;

public class EventBase<T> : ScriptableObject, IEvent<T>
{
	private List<IEventListener<T>> listeners = new List<IEventListener<T>>();

	public void Broadcast( GameObject gameObject, T parameter )
	{
		EventLogging.Log
		(
			LogType.Broadcast,
			parameter.ToString( ),
			gameObject,
			name,
			$"<b>{name}</b> is being broadcast to all subscribing Listeners. Value passed: <b>{parameter}</b>"
		);

		for ( int i = listeners.Count - 1; i >= 0; i-- )
		{
			listeners[i].OnEventRaised( parameter );
		}
	}

	public void Subscribe( IEventListener<T> listener )
	{
		listeners.Add( listener );
	}

	public void UnSubscribe( IEventListener<T> listener )
	{
		listeners.Remove( listener );
	}
}
