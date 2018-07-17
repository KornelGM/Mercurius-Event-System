/**
 * Description: Log window with all the event that are being broadcast, received, etc..
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EventLogWindow : EditorWindow
{
	private static List<EventLogMessage> logMessages = new List<EventLogMessage>();

	private Vector2 scrollViewPosition = Vector2.zero;
	private bool hideSubUnsub = false;

	private static GUIStyle _foldoutStyle;
	private static GUIStyle foldoutStyle
	{
		get
		{
			if ( _foldoutStyle == null )
			{
				_foldoutStyle = new GUIStyle( EditorStyles.foldout );
				_foldoutStyle.richText = true;
			}

			return _foldoutStyle;
		}
	}

	private static GUIStyle _normalStyle;
	private static GUIStyle normalStyle
	{
		get
		{
			if ( _normalStyle == null )
			{
				_normalStyle = new GUIStyle( EditorStyles.foldout );
				_normalStyle.richText = true;
			}

			return _normalStyle;
		}
	}

	[MenuItem( "Window/Event Log" )]
	private static void OpenWindow( )
	{
		EventLogWindow window = GetWindow<EventLogWindow>( );
		window.titleContent = new GUIContent( "Event Log" );
	}

	private void OnEnable( )
	{
		minSize = new Vector2( 400, 200 );
	}

	private void OnInspectorUpdate( )
	{
		logMessages = EventLogging.Messages;
		Repaint( );
	}

	private void OnGUI( )
	{
		DrawToolbar( );
		DrawMessages( );

		if ( GUI.changed )
			Repaint( );
	}

	private void DrawToolbar( )
	{
		EditorGUILayout.BeginHorizontal( EditorStyles.toolbar );

		if ( GUILayout.Button( "Clear", EditorStyles.toolbarButton, GUILayout.Width( 40 ) ) )
			logMessages.Clear( );

		GUILayout.FlexibleSpace( );

		/*if ( testButton )
			GUI.backgroundColor = Color.Lerp( defaultColor, Color.red, 0.3f );
		if ( GUILayout.Button( "DO NOT PRESS", EditorStyles.toolbarButton, GUILayout.Width( 120 ) ) )
		{
			testButton = !testButton;
			logMessages.Clear( );
			logMessages.Add( new EventMessage( 0, LogType.Warning, null, "", "What did I tell you?!", ":P" ) );
		}
		GUI.backgroundColor = defaultColor;*/

		hideSubUnsub = GUILayout.Toggle( hideSubUnsub, "Hide Sub / UnSub", EditorStyles.toolbarButton, GUILayout.Width( 120 ) );

		EditorGUILayout.EndHorizontal( );
	}

	private void DrawMessages( )
	{
		scrollViewPosition = EditorGUILayout.BeginScrollView( scrollViewPosition );

		foreach ( var message in logMessages )
			DrawMessage( message );

		EditorGUILayout.EndScrollView( );
	}

	private void DrawMessage( EventLogMessage message )
	{
		if ( hideSubUnsub && ( message.Type == LogType.Subscribed || message.Type == LogType.UnSubscribed ) )
			return;

		Rect pos = GUILayoutUtility.GetRect( 40f, 40f, 16f, 16f, foldoutStyle );
		string headerText = "";

		switch ( message.Type )
		{
			case LogType.Subscribed:
			case LogType.UnSubscribed:
			headerText = $"{message.TimeStamp:0.000} - Type: <b>{message.Type}</b>, GameObject: <b>{message.GameObject.name}</b>, Listener: <b>{message.EventName}</b>";
			break;

			case LogType.Broadcast:
			case LogType.Received:
			headerText = $"{message.TimeStamp:0.000} - Type: <b>{message.Type}</b>, GameObject: <b>{message.GameObject.name}</b>, Event: <b>{message.EventName}</b>, Value: <b>{message.Value}</b>";
			break;

			case LogType.Information:
			case LogType.Warning:
			case LogType.Error:
			case LogType.Exception:
			headerText = $"{message.TimeStamp:0.000} - Type: <b>{message.Type}</b>, GameObject: <b>{message.GameObject.name}</b>, Event: <b>{message.EventName}</b>, Message: <b>{message.Message}</b>";
			break;

			default:
			headerText = $"Unknown message type: {message.Type}";
			break;
		}

		message.IsUnfolded = EditorGUI.Foldout( pos, message.IsUnfolded, new GUIContent( headerText ), true, foldoutStyle );

		if ( message.IsUnfolded )
		{
			EditorGUILayout.LabelField( $"      {message.Message}", normalStyle );

			EditorGUILayout.BeginHorizontal( );

			GUILayout.Space( 30 );

			if ( GUILayout.Button( "Ping GameObject", GUILayout.Width( 150 ) ) )
				EditorGUIUtility.PingObject( message.GameObject );

			EditorGUILayout.EndHorizontal( );
		}
	}
}
