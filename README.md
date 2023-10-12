# Tween Actions
*Tween Actions is a part of [Mosaic Base](https://github.com/MosaicDreams/Mosaic-Base).*
*A better, more comprehensible documentation is on the way.*

 A simple add-on to DOTween for better ease of use. It uses Scriptable Objects to contain tweening parameters.
You can create a TweenActionObject using "Create" by right-clicking on Project Window or Assets Tab.

Whenever you want to use TweenActions you need to import the namespace:
```
using Mosaic.Base.TweenActions;
```
You would also need a reference to the TweenActionObject which you set up.
Then you can use TweenActor (a static class) to initiate your TweenActionObject on a GameObject (or Transform, etc.):
```
TweenActor.Act(action, object);
```

If you have any ideas that would help improve the project, I'd love to hear them.
