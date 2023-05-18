# _Pokemon Crawl_

#### By _**Michael Sol**_

#### _An incremental game fusing Pokemon Mystery Dungeon with the combat system of Final Fantasy 12_

## Technologies Used

* _C#_
* _Unity_
* _Git_

## Description

_An incremental game using the theme and assets of Pokemon with the Gambit combat system of Final Fantasy 12._
_The gambit system allows the player to 'program' a unique fighting style for each party member_
_Each member has a innate list of 'commands' with each one taking the structure of:_

 > IF [_some condition_] IS TRUE, THEN [ _do something_]

_This allows the player to essentially automate combat, with much of the game playing itself once combat is properly steup_

_The MVP for this project will be:_

* Create and animate 1 Pokemon
* Create a command for that Pokemon
* Have that Pokemon automatically execute that command when it's condition is met
* Have that Pokemon do some other default action when the condition is _not_ met

## Setup/Installation Requirements

* _Install Unity_
* _Navigate to the GitHub_
* _Clone the Repo_
* _Import the project to Unity_
* _Press Play_

## Known Bugs

* _Pokemon currently move before updating which direction they are facing_
* _Occasionally have to quit and restart Unity, due to 

 >SerializedObjectNotCreateableException: Object at index 0 is null._

* _Unable to reproduce bug, and it's only occasional, error points to Unity engine code, not my code, not sure what to do_

## TODO

* _Properly calculate damage_
* _Implement Health_
* _Implement Fainting_
* _Fix walk cycles (Currently using Idle animation)_

* _Add more Pokemon_
* _Add more Moves_
* _Add more Commands_


## License

_Contact Michael with any problems_

Copyright (c) _5/18/23_ _Michael Sol_

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.