/**
 * Description: Helper class for event logging. Used by editor extension.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using System.Collections.Generic;
using UnityEngine;

public enum LogType
{
	Subscribed,
	UnSubscribed,
	Broadcast,
	Received,
	Information, // currently unused
	Warning,     // currently unused
	Error,       // currently unused
	Exception,   // currently unused
}

public class EventLogMessage
{
	public EventLogMessage( float timeStamp, LogType type, string eventName, GameObject gameObject, string value, string message = "" )
	{
		TimeStamp = timeStamp;
		Type = type;
		EventName = eventName;
		GameObject = gameObject;
		Value = value;
		Message = message;
	}

	public float TimeStamp;
	public LogType Type;
	public GameObject GameObject;
	public string Value;
	public string EventName;
	public string Message;

	public bool IsUnfolded = false;
}

public class EventLogging
{
	readonly public static List<EventLogMessage> Messages = new List<EventLogMessage> ();

	/// <summary>
	/// Log a message to the Event Log window.
	/// </summary>
	/// <param name="type">Type of the log entry (what occurred).</param>
	/// <param name="eventName">Name of the event.</param>
	/// <param name="gameObject">GameObject sending the event.</param>
	/// <param name="value">Value passed.</param>
	/// <param name="message">Optional message.</param>
	public static void Log( LogType type, string eventName, GameObject gameObject, string value, string message = "" )
	{
#if UNITY_EDITOR
		EventLogMessage msg = new EventLogMessage( Time.realtimeSinceStartup, type, eventName, gameObject, value, message );
		Messages.Add( msg );
#else
		Debug.Log( $"{Time.realtimeSinceStartup:0.000} - Type: {type}, Event: {eventName}, GameObject: {gameObject.name}, Value: {value}, Message: {message}" );
#endif
	}
}
