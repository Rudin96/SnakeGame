Tobias Rudin
A little Snake Game with some pickups.

Patterns:
-Singleton
	Used singleton pattern to make single instance of scoremanager to be accessed from anywhere
-Observer
	Used observer pattern in UI Manager and Character classes to change UI on Player killed and update the points in UI when player "eats" a pickup with points
-Serialization
	Used serialization in Settings class to save/read settings from JSON file stored in local user data

This game was also made using my custom LinkedList.