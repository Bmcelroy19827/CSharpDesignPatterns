# CSharpDesignPatterns
Visual Studio solution containing many simple projects that try to show design patterns in the most lightweight way possible.

Much of my knowledge of object oriented design patterns comes from three main sources listed below (assume for all projects that these play a big part in my understanding and examples provided) and a lot of google searching. I have listed any recent sites in the code comments of their respective patterns:
- [PluralSight's Design Patterns in C#](https://app.pluralsight.com/paths/skills/design-patterns-in-c)
- [Ardalis's Design Patterns Library on PluralSight](https://app.pluralsight.com/library/courses/patterns-library/table-of-contents)
- [Game Design Patterns by Robert Nystrom](http://gameprogrammingpatterns.com/ "Really entertaining and educational read")
  - I highly recommend buying the physical copy - for one it's easier to read, and for two you get a nice picture on the back

*Note*: I added "Note" to the list of task list tags
  - To do this go to `tools >> options >> Environment >> Task List` and add "Note" to the list

## Object Pool
- This console app allows you to see an object pool which limits the total number of instances of a class to 10 (by default) and starts by loading the pool with 5 instances of this class
