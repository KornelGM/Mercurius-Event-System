# Mercurius Event System

Mercurius is an event system designed for Unity game engine. It's lightweight and expendable by design. Easy to use by non-programmers. Includes a journaling (a log) extension window.

As an added bonus also includes a Shared Variable system.

Please see Description below for more details.


## How to use the Event System

1. Copy or clone everything here to your Unity project's Assets folder (for example [Project Name]\Assets\Mercurius Event System).
2. Use `FloatEvent.cs` and `FloatEventListener.cs` (example events with a single float parameter) or create your own based on them.
3. Create a new event asset (just like you create a new material or folder): `Create->Events->Float Event`.
4. In the class that will send an event please add `public FloatEvent myEvent;` **and** drag the created asset in to the inspector field.
5. In the same script you can call the event like so `myEvent.Broadcast( gameObject, 1.4f );` _The 1.4f is an example and gameObject is used in the Log Window._
6. Subscribing
	- Either attach `FloatEventListener.cs` (or your own event listener) to a GameObject that you want to listen to your event and like in point 3. drag the event asset to `Game Event` field in the inspector. Every listener (like `FloatEventListener.cs`) has a standard Unity Event slots (like Unity's new UI Buttons or Sliders) that can be used to call methods in respons to the event being broadcast.
	- Or add `public FloatEvent myEvent;` in your script and subscribe directly the the event `myEvent.Subscribe(OnMyEventHandler);`. _Please remember to drag the event asset file in the inspector window. Also please remember to unsubscribe (for example in `OnDisable`)._


### Optional
You can open the companion Event Log windows from Windows->Event Log to track the events being broadcast and recived.


## How to use Shared Veriables

1. Copy or clone everything here to your Unity project's Assets folder (for example [Project Name]\Assets\Mercurius Event System).
2. Use `SharedFloatVariable.cs` (example events with a single float parameter) or create your own based on it.
3. Create a new shared variable asset (just like you create a new material or folder): `Create->Shared Events->Float Variable`.
4. In classes that will need access to that variable please add `public ShaderFloatVariable hp;` **and** drag the created asset in to the inspector field.
5. In any of the scripts you can read or write to the shared variable like so `hp.Value = 10f;`
6. Shared Variables also have read-only (and settable via the inspector) `StartValue`.


## Description

Mercurius is an event system designed for Unity game engine. It's lightweight and expendable by design. Easy to use by non-programmers.

It also features a journaling (a log) extension window for easy tracking of events.

It's designed to work with no external dependencies - so it can be extremely easily added to production code and prototypes alike.

The main purpose of this library is to make the code more maintainable by decoupling one piece of the code (one that wants to send information or notification) from another piece of code (one that would like to be notified).

For example, in a game, an enemy getting killed can lead to: emitting a sound, player getting points, visual effects and even winning the game. Thanks to an event system like this one non of the different scripts have to know anything about each other. They only need to know the event they are interested in.


## Acknowledgments

This messaging system is based on Ryan Hipple's presentation [Game Architecture with Scriptable Objects (Unite Austin 2017)](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

Shared Variables are inspired by [Three ways to architect your game with ScriptableObjects](https://unity.com/how-to/architect-game-code-scriptable-objects).

I would also like to thank *mko*, who rekindled my interest in event systems during Ludum Dare 39. And [Christian Richards](https://www.youtube.com/user/cjrgaming) for inspiring me to create the 2nd version of this library (the one you are seeing here).

A special thanks goes to all the great folks who contributed to the many great Unity forum threads, Unity Answers and made Unity tutorials that helped me to learn Unity over the years. And, of course, all the lovely people who make Unity.

You guys rock!


## License

MIT License, please see LICENSE file for the full license.
