# ThreeSidedCoin

This is a project designed to test and try to find a fair 3 sided coin.
Watch this video by Matt Parker for context : https://www.youtube.com/watch?v=-qqPKKOU-yY

## Instructions

#### Panel Controls
* **Generate** - Generates the coins above the ground in a random orientation.
* **Clear** - Removes all of the coins
* **Count** Slider - A slider to select the number of coins to generate at a time
* **Ratio** - The ratio between the diameter of the coin to its width. For example the video uses the value 2√2, so use 2.828 for the value here.
* **Collisions Toggle** - If true all **new** coins will collide with one another
* **Colour Toggle** - If true the coins will change colour based on their orientation. Heads(red), Tails(blue), Sides(magenta), ⋅⋅* Invalid(yellow)
* **Velocity Slider** - The range for the random starting velocity of each coin
* **Angular Velocity Slider** - The range for the random starting angular velocity of each coin

#### Camera Controls
To move around the camera, click and hold anywhere on the screen. While holding move the mouse to move the direction and use the arrows (or WASD) to move the position of the camera.

## Notes
The velocity makes a large difference to the "fairness" of the coin. For example 2.7 as the ratio will have very close to even odds if the velocity is set low. This would simulate simply flipping the coin. But once you add in a bit of velocity the odds of landing on its side dramatically increase (to roughly 60% of the coins).

The other factor that can skew the results is the collisions. If a coin becomes stationary on its side then if it gets hit by a second coin then it will likely fall over (depending on the ratio) but a coin on its face is unlikely to be knocked to its side.
