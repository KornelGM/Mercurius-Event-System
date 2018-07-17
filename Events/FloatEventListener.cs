/**
 * Description: An example implementation of a Listener with a float parameter.
 * Copyright: © 2017-2018 Kornel, MIT License. Please see 'README.md' and 'LICENSE' files for more information.
 **/

using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }
public class FloatEventListener : EventListenerBase<UnityEventFloat, FloatEvent, float> { }
