/**
 * Description: A very simple example script that sends an event.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;

public class ExampleEventSender : MonoBehaviour
{
	public FloatEvent SliderValue;

	private float value = 0;

	public void SetValue(float newValue)
	{
		value = newValue;
	}

	public void SendEvent()
	{
		SliderValue.Broadcast(gameObject, value);
	}
}
