# RiseOfOz
BHG Take home test for Alexander Lau

## Notes

Main file is **Program.cs**

For ease of grading's sake, the output hews closely to the sample output provided in the test.

## Data Driven Design

Instead of hard coding troop and army values, they have been defined in JSON documents. The files are

- Resources/Templates (for flying monkey)
- Resources/Armies
- Resources/Troops

Appropriate Parsers/Readers have been built for them.

This is so we can do a 'composition over inheritance' approach and allow values to be changed at design time.

You can even add new units to the armies by changing the files! However right now the main program is hardcoded to battle only the "Good Army" and "Bad Army".

## Unit Tests

Unit tests have been done with the NUnit Framework. To run them in Visual Studio, you'll need the NUnit Test Adapter.

### Tools > Extensions and Updates > NUnit 3 Test Adapter. 

You'll have to restart Visual Studio after you reset.


