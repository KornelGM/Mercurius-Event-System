/**
 * Description: A very simple example script that sets a shared variable.
 * Copyright: © 2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.UI;

public class ExampleSharedVariableSetter: MonoBehaviour
{
	public SharedFloatVariable SharedFloatVariable;
	public Slider Slider;

	private void Start()
	{
		Slider.value = SharedFloatVariable.StartValue;
	}

	public void OnSliderChange(float value)
	{
		SharedFloatVariable.Value = value;
	}
}
