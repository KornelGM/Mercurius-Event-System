/**
 * Description: An example script that receives an event.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;

public class ExampleEventReceiver : MonoBehaviour
{
	public FloatEvent myEvent;

	public void OnEvent( float value )
	{
		Debug.Log( $"Received: {value}" );
	}
}
