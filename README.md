# clever-dog

המשחק עצמו הוא משחק מחשב המתקיים בבית של הבעלים. השחקן משחק ככלב אשר נמצא בבית עם בעליו.
מטרת השחקן היא להבריח גנבים שמגיעים לבית, לעשות צרכים בבית ומבלי להתפס על ידי הבעלים, ולגנוב אוכל מהשולחן - לעשות כמה שיותר פעולות מבלי שישמו לב תחת הזמן המוקצב.

[קישור לדף הרכיבים](https://github.com/Game-Developmento/clever-dog/blob/main/formal-elements.md)

## 2D core proccess demonstration of the game
Food Stealing Dog is a 2D game that demonstrates the core process of the real game. In this game, the player takes on the role of a dog and must steal food without being caught by the owner. If the player manages to steal all the food without being seen, they win.  
*It is important to note that the real game will be a 3D game and will have more missions than this core process.*  
[Click here to play the game!](https://orihoward.itch.io/)

## How to Play
The objective of the game is to steal all the food without being caught by the owner. The player controls the dog and moves around the house to find and steal the food using the WASD keys. Pressing the spacebar will allow the player to steal food when they are close enough to it. If the owner sees the player, the game is over.

## Scripts
### FoodStealing
This component checks the distance between the player and the food. If the player is close enough, they can steal the food. It also checks if all the food has been stolen to determine if the player has won the game.

### InputMover
This script handles the player movement in the game and collision with objects.

### SeenByLandlord
This script sets a threshold distance that the player must keep from the owner to avoid being caught.
