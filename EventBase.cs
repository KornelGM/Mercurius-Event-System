/**
 * Description: Base Scriptable Object that serves simultaneously the role of the Message and Message Center.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBase: ScriptableObject, IEvent
{
	private List<IEventListener> listeners = new List<IEventListener>();
	private List<Action> listenersA = new List<Action>();

	public void Broadcast(GameObject gameObject)
	{
		EventLogging.Log
		(
			LogType.Broadcast,
			ToString(),
			gameObject != null ? gameObject.name : "N/A",
			"N/A",
			$"<b>{name}</b> is being broadcast to all subscribing Listeners.</b>",
			gameObject
		);

		for(int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised();
		}

		for(int i = listenersA.Count - 1; i >= 0; i--)
		{
			EventLogging.Log(LogType.Received, ToString(), listenersA[i].Method.Name, "N/A", $"Event received by <b>{listenersA[i].Method.Name}</b>.", null);
			listenersA[i].Invoke();
		}
	}

	public void Subscribe(IEventListener listener)
	{
		listeners.Add(listener);
	}

	public void Subscribe(Action listener)
	{
		listenersA.Add(listener);
	}

	public void UnSubscribe(IEventListener listener)
	{
		listeners.Remove(listener);
	}

	public void UnSubscribe(Action listener)
	{
		listenersA.Remove(listener);
	}
}

public class EventBase<T>: ScriptableObject, IEvent<T>
{
	private List<IEventListener<T>> listeners = new List<IEventListener<T>>();
	private List<Action<T>> listenersA = new List<Action<T>>();

	public void Broadcast(GameObject gameObject, T parameter)
	{
		EventLogging.Log
		(
			LogType.Broadcast,
			ToString(),
			gameObject != null ? gameObject.name : "N/A",
			parameter.ToString(),
			$"<b>{name}</b> is being broadcast to all subscribing Listeners. Value passed: <b>{parameter}</b>",
			gameObject
		);

		for(int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised(parameter);
		}

		for(int i = listenersA.Count - 1; i >= 0; i--)
		{
			EventLogging.Log(LogType.Received, ToString(), listenersA[i].Method.Name, parameter.ToString(), $"Event received by <b>{listenersA[i].Method.Name}</b>.", null);
			listenersA[i].Invoke(parameter);
		}
	}

	public void Subscribe(IEventListener<T> listener)
	{
		listeners.Add(listener);
	}

	public void Subscribe(Action<T> listener)
	{
		EventLogging.Log(LogType.Subscribed, name, "N/A", GetType().Name, $"{listener} subscribed directly to {name}.", null);
		listenersA.Add(listener);
	}

	public void UnSubscribe(IEventListener<T> listener)
	{
		listeners.Remove(listener);
	}

	public void UnSubscribe(Action<T> listener)
	{
		EventLogging.Log(LogType.UnSubscribed, name, "N/A", GetType().Name, $"{listener} unsubscribed directly to {name}.", null);
		listenersA.Remove(listener);
	}
}

public class EventBase<T, U>: ScriptableObject, IEvent<T, U>
{
	private List<IEventListener<T, U>> listeners = new List<IEventListener<T, U>>();
	private List<Action<T, U>> listenersA = new List<Action<T, U>>();

	public void Broadcast(GameObject gameObject, T parameter1, U parameter2)
	{
		EventLogging.Log
		(
			LogType.Broadcast,
			ToString(),
			gameObject != null ? gameObject.name : "N/A",
			$"({parameter1}, {parameter2})",
			$"<b>{name}</b> is being broadcast to all subscribing Listeners. Values passed: <b>{parameter1}</b>, <b>{parameter2}</b>",
			gameObject
		);

		for(int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised(parameter1, parameter2);
		}

		for(int i = listenersA.Count - 1; i >= 0; i--)
		{
			EventLogging.Log(LogType.Received, ToString(), listenersA[i].Method.Name, $"({parameter1}, {parameter2})", $"Event received by <b>{listenersA[i].Method.Name}</b>.", null);
			listenersA[i].Invoke(parameter1, parameter2);
		}
	}

	public void Subscribe(IEventListener<T, U> listener)
	{
		listeners.Add(listener);
	}

	public void Subscribe(Action<T, U> listener)
	{
		EventLogging.Log(LogType.Subscribed, name, "N/A", GetType().Name, $"{listener} subscribed directly to {name}.", null);
		listenersA.Add(listener);
	}

	public void UnSubscribe(IEventListener<T, U> listener)
	{
		listeners.Remove(listener);
	}

	public void UnSubscribe(Action<T, U> listener)
	{
		EventLogging.Log(LogType.UnSubscribed, name, "N/A", GetType().Name, $"{listener} unsubscribed directly to {name}.", null);
		listenersA.Remove(listener);
	}
}
