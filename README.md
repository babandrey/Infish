# Infish
 Insaquarium Deluxe inspired game. Aimed to be a rougelike.
 
# TODO List: (Specific)

Make movement script use either random movement OR if the fish is hungry and theres food on the screen make it move towards the food.

Food object pooler.

# TODO List: (Non specific)

Generic food implemntation - right now not correct.

Generic level implementation:
 - For every level have amount of 8 Button slots you can put in a Level Manager.
 - These prefabs need to be generic in order to be generated as 8 buttons for each level of the game. For example - Food type, Food amount, Guns, Fish, End level etc. these are not the same every level and should be interchangeable.

Generic game design:
 - Every time you win a level, you have a choice of 3 friendly sea creatures(FSC) to help you in your journey.
 - The 3 friendly creatures are picked randomly from a pool of a couple of FSC.
 On the development side:
   -  https://docs.google.com/document/d/14p4LDhOOpjdGn4ELydy_AfMFuqySqQBVawtJ-y_5feE/edit?usp=sharing
   -  An example can be shown here - every 4 FSC can be picked each level. There are overlapping FSC pools that can be picked for different levels.
   -  For example, FSC 3 can be picked after Level 1-1, or Level 1-2, as long as you didnt pick it in Level 1-1. 
   -  Definitly need to play with the numbers, but this is the base concept.
 
 - The FSC will have sinergies with eachother. 
 - The game is souposed to be harder than Insaquarium Deluxe, other than multitasking need to figure out how to make the game harder, harder enemies or enviornment, or some difficulty levels.
