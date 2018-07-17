# Mercurius Event System

Mercurius is an event system designed for Unity game engine. It's lightweight and expendable by design. Easy to use by non-programmers and includes a journaling (a log) extension window.

Please see Description below for more details.


## How to use

0. Copy or clone everything here to your Unity project's Assets folder (for example [Project]\Assets\Mercurius Event System).
1. Use `FloatEvent.cs` and `FloatEventListener.cs` (example events with a single float parameter) or create your own based on them.
2. Create a new event asset (just like you create a new material or folder). _The Float Event from above adds 'Float Event' entry to the context menu._
3. In the class that will send an event please add `public FloatEvent myEvent;` **and** drag the created asset in to the inspector field.
4. In the same script you can call the event like so `myEvent.Broadcast( gameObject, 1.4f );` _The 1.4f is an example and gameObject is used in the Log Window._
5. Attach `FloatEventListener.cs` (or your own event listener) to a GameObject that you want to listen to your event and like in point 3. drag the event asset to `Game Even` field in the inspector.
6. Every listener (like `FloatEventListener.cs`) has a standard Unity Event slots (like Unity's new UI Buttons or Sliders) that can be used to call methods in respons to the event being broadcast.

### Optional
You can open the companion Event Log windows from Windows->Event Log to track the events being broadcast and recived.


## Description

This is the 2nd major version of a simple Event / Messaging System for Unity based on Scriptable Objects and Ryan Hipple's presentation [Game Architecture with Scriptable Objects (Unite Austin 2017)](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

It also features a journaling (a log) extension window for easy tracking of events.

It's designed to work with no external dependencies - so it can be extremely easily added to production code and prototypes alike.

The main purpose of this library is to make the code more maintainable by decoupling one piece of the code (one that wants to send information or notification) from another piece of code (one that would like to be notified).

For example, in a game, an enemy getting killed can lead to: emitting a sound, player getting points, visual effects and even winning the game. Thanks to an event system like this one non of the different scripts have to know anything about each other. They only need to know the event they are interested in - and even that is only true for the sender.


## Acknowledgments

This messaging system is based on Ryan Hipple's presentation [Game Architecture with Scriptable Objects (Unite Austin 2017)](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

I would also like to thank *mko*, who rekindled my interest in event systems during Ludum Dare 39. And [Christian Richards](https://www.youtube.com/user/cjrgaming) for inspiring me to create the 2nd version of this library.

A special thanks goes to all the great folks who contributed to the many great Unity forum threads, Unity Answers and made Unity tutorials that helped me to learn Unity over the years. And, of course, all the lovely people who make Unity.

You guys rock!


## License

MIT License, please see LICENSE file for the full license.
