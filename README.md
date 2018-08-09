# RiseOfOz
BHG Take home test for Alexander Lau

Design Notes

Instead of hard coding troop and army values, they have been defined in JSON documents. The files are

Resources/Templates (for flying monkey)

Resources/Armies

Resources/Troops

This is so we can do a 'composition over inheritance' approach and allow values to be changed at design time.

Unit Tests

Unit tests have been done with the NUnit Framework. To run them in Visual Studio, you'll need the NUnit Test Adapter.

Goto

Tools > Extensions and Updates > NUnit 3 Test Adapter. You'll have to restart Visual Studio after you reset.


