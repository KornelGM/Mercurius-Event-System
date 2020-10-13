/**
 * Description: A very simple example script that receives an event.
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.UI;

public class ExampleEventReceiverUsingListener: MonoBehaviour
{
	public Text Label;

	public void OnEventReceived(float value)
	{
		Label.text = $"Listener received: {value}";
	}
}
