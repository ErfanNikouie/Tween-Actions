# Tween-Actions
 A simple add-on to DOTween for better ease of use. It uses Scriptable Objects to contain tweening parameters.
You can create a TweenActionObject using "Create" by right-clicking on Project Window or Assets Tab.

Whenever you want to use TweenActions you need to import the namespace:
```
using TweenActions;
```
You would also need a reference to the TweenActionObject which you set up.
Then you can use TweenActor (a static class) to initiate your TweenActionObject on a GameObject (or Transform and etc.):
```
TweenActor.Act(action, object);
```
Done:
- Refactor some pieces of code on TweenActor.

To Do:
- Write a more comprehensive and complete documentation here.
- Complete ActionSequences, making initialization of multiple TweenActionObjects simultaneously/in order on an object possible.
- ...

If you have any ideas that you think would help make the project better, I'd be happy to hear them.
