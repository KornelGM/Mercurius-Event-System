/**
 * Description: An example script that sends an event.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;

public class ExampleEventSender : MonoBehaviour
{
	public FloatEvent myEvent;

	void Start ()
	{
		myEvent.Broadcast( gameObject, 1.4f );
	}
}
