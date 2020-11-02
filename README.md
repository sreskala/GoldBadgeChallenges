# Gold Badge Challenges

These are challenges that were a part of ElevenFifty's Gold Badge. We were required to complete at least 3 of them.
These challenges were all coded using **C#** and **.NET Framework 4.7.2.** 
They follow a repository pattern, with each challenge having a Class library consisting of the repository and other 
items such as classes, interfaces, etc... along with a User Interface Console App, and Unit Tests for the repository.

----------

## Challenge 1: Komodo Cafe
Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, 
(eventually) update menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.


KomodoMenu Class
| Property/Method | Description |
| :---------------: | ----------- |
| MealNumber | integer number |
| MealName | string of name |
| Description | string of description |
| Ingredients | List of strings |
| Price | float for price |

Menu Class also comes with a constructor in which Meal number and meal name are required.

KomodoMenu Repository

The repository is initialized at the top of the class:
```C#
private List<KomodoMenu> _repo = new List<KomodoMenu>();
```
CRUD Methods for the repository
| Method Name| Description|
| ------ | ------|
| AddMenuItem(KomodoMenu km)| Takes in a KomodoMenu object and returns true if added, or false if it did not add |
| GetMenuItems() | Returns the entire repository list |
| GetMenuItemByMealNumber(int mnum) | Iterates through the list and returns the specified KomodoMenu object |
| UpdateMenuItem(int mnum, KomodoMenu km) | Updates the menu item with properties from a new one |
| DeleteMenuItem(int mnum) | Deletes a menu item based on the meal number |

Example:
```C#
KomodoMenu menu = new KomodoMenu(3, "Komodo Burger");
bool wasAdded = _repo.AddMenuItem(menu); //Should return true
```
---------

## Challenge 2: Komodo Claims
