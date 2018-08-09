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

Data is re-read on every run of the program, but it would be easy enough to implement a button or command to do it on the fly.

## Templates vs Troops

To model the Flying Monkey paradigm accurately in data, I created a "Template" folder. Templates are similar to an idea in D&D where you can apply templates like "Half-Dragon" or "Celestial" to creatures. On certain key-values you can place a reference instead of a value.

For Flying monkey, we do it like so

```
{
  "Id": 2,
  "Name": "Flying Monkey",
  "Type": "Air",
  "Damage": "*Monkey",
  "Health": "*Monkey",
  "PreferredTarget": "Air",
  "Template": "Subtype"
}
```
The parser would see the reference values, and look at the appropriate Troop to populate that value.

Ostensibly we could even have Templates of Templates, but that would require a little bit of refactoring since order of loading comes into play (Which is why they have Ids, even if that isn't used in this iteration.)

## Unit Tests

Unit tests have been done with the NUnit Framework. To run them in Visual Studio, you'll need the NUnit Test Adapter.

### Tools > Extensions and Updates > NUnit 3 Test Adapter. 

You'll have to restart Visual Studio after you reset.


