# CSharpDesignPatterns
Visual Studio solution containing many simple projects that try to show design patterns in the most lightweight way possible. Feel free to add any details for each pattern that would be helpful in explaining it's purpose, pros, cons, etc.

Much of my knowledge of object oriented design patterns comes from three main sources listed below (assume for all projects that these play a big part in my understanding and examples provided) and a lot of google searching. I have listed any recent sites in the code comments of their respective patterns:
- [PluralSight's Design Patterns in C#](https://app.pluralsight.com/paths/skills/design-patterns-in-c)
- [Ardalis's Design Patterns Library on PluralSight](https://app.pluralsight.com/library/courses/patterns-library/table-of-contents)
- [Game Design Patterns by Robert Nystrom](http://gameprogrammingpatterns.com/ "Really entertaining and educational read")
  - I highly recommend buying the physical copy - for one it's easier to read, and for two you get a nice picture on the back

*Note*: I added "Note" to the list of task list tags
  - To do this go to `tools >> options >> Environment >> Task List` and add "Note" to the list
## Helping Hand
- This is not a design pattern, just a class library I created to put stars across the console for formatting right now

## Patterns Picker
- This is the Console app that has a reference to all of the other Class Libraries and allows you to pick which design pattern you'd like to see the current implementation of in the Console.
- This should be the project chosen for startup

## Object Pool
- This Class Library allows you to see an object pool which limits the total number of instances of a class to 10 (by default) and starts by loading the pool with 5 instances of this class

## Event Aggregator
- This Class Library allows you to see how subscribers react when the class "Events" they've subscribed to have been published
- This is a pub/sub pattern and the aggregator seems to be pretty much the broker if you've used MQTT for IoT devices
