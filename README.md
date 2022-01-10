# CSharpDesignPatterns
Visual Studio solution containing many simple projects that try to show design patterns in the most lightweight way possible. I envision this project being used by a developer running it from their Visual Studio instance and navigating through the patterns via the Console application. They can exerience the features of the pattern or even be guided through the code by referencing locations of code files and explaining their purpose. 

Much of my knowledge of object oriented design patterns comes from three main sources listed below (assume for all projects that these play a big part in my understanding and examples provided) and a lot of google searching. I have listed any recent sites in the code comments of their respective patterns:
- [PluralSight's Design Patterns in C#](https://app.pluralsight.com/paths/skills/design-patterns-in-c)
- [Ardalis's Design Patterns Library on PluralSight](https://app.pluralsight.com/library/courses/patterns-library/table-of-contents)
- [Game Design Patterns by Robert Nystrom](http://gameprogrammingpatterns.com/ "Really entertaining and educational read")
  - I highly recommend buying the physical copy - for one it's easier to read, and for two you get a nice picture on the back

*Note*: I added "Note" to the list of task list tags
  - To do this go to `tools >> options >> Environment >> Task List` and add "Note" to the list

## Some ways to contribute
- Documentation
  - Feel free to update documentation via updates to this readme, updates to code comments, or even adding more Console Writelines to sort of guide users through the code structure involved in the pattern
- Update the HelpingHand Class Library
  - Have an idea for something that could be used by other projects in the solution? Add it to this Class Library
- Add Design Patterns
  - I've supplied an alphabetical categorized list at the bottom of this readme including the design patterns I know exist0
 
## Steps for Adding a Design Pattern
1. Pick a pattern from the list below
2. Create a Class Library matching the name of the design pattern (Reference HelpingHand if necessary)
3. Implement the pattern in the Class Library
4. Figure out a way to educate the user on the pattern
  - Choose your own adventure guide?
  - Operations that benefit from the pattern ran inside the Console
  - etc.  
5. Add a project reference for the new Class Library to the PatternsPicker project
6. Add code to implement Class Library in PatternPicker
7. Update Readme
  - Remove the Pattern from the "Needed Patterns" list 
  - Add Pattern under the other implemented patterns and include a short description of the project and how it works  

## Projects
### Helping Hand
- This is not a design pattern, just a class library I created to put stars across the console for formatting right now

### Patterns Picker
- This is the Console app that has a reference to all of the other Class Libraries and allows you to pick which design pattern you'd like to see the current implementation of in the Console.
- This should be the project chosen for startup

## Design Pattern Projects
-   These are all Class Libraries
### Object Pool
- This allows you to see an object pool which limits the total number of instances of a class to 10 (by default) and starts by loading the pool with 5 instances of this class

### Event Aggregator
- This allows you to see how subscribers react when the class "Events" they've subscribed to have been published
- This is a pub/sub pattern and the aggregator seems to be pretty much the broker if you've used MQTT for IoT devices


## Needed Patterns

### Creational
- Builder
- (Abstract)Factory
- Prototype
- Service Locator

### Structural
- Adapter
- Composite
- Decorator
- Facade
- Flyweight
- Proxy

### Behavioral
- Bridge
- Chain of Responsibility
- Command
- Interpreter
- Iterator
- Lazy Load
- Mediator
- Memento
- Null Object
- Observer
- Repository
- Rules
- Singleton
- Specification
- State
- Strategy
- Template
- Unit Of Work
- Visitor

