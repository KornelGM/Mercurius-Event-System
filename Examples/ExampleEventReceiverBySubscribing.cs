/**
 * Description: A very example script that receives an event.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.UI;

public class ExampleEventReceiverBySubscribing: MonoBehaviour
{
	public FloatEvent SliderEvent;
	public Text Label;

	private void OnEnable()
	{
		SliderEvent.Subscribe(OnEventReceived);
	}

	private void OnDisable()
	{
		SliderEvent.UnSubscribe(OnEventReceived);
	}

	private void OnEventReceived(float value)
	{
		Label.text = $"Direct subscription received: {value}";
	}
}
