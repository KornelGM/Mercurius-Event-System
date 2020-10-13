/**
 * Description: A very simple example script that receives a shared variable.
 * Copyright: © 2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine;
using UnityEngine.UI;

public class ExampleSharedVariableReciver: MonoBehaviour
{
	public SharedFloatVariable SharedFloatVariable;
	public Text Label;

	private void Update()
	{
		Label.text = $"Shared variablee: {SharedFloatVariable.Value}";
	}
}
