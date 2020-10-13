/**
 * Description: Shared variable using Scriptable Object.
 * Inspired by: https://unity.com/how-to/architect-game-code-scriptable-objects
 * Copyright: © 2017-2020 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using System;
using UnityEngine;

public class SharedVariableBase<T>: ScriptableObject, ISerializationCallbackReceiver
{
	public T StartValue { get => _startValue; }

	[NonSerialized] public T Value;

	[SerializeField] private T _startValue = default;

	public void OnAfterDeserialize()
	{
		Value = _startValue;
	}

	public void OnBeforeSerialize() { }
}
