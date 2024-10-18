# Описание:
[Technical specification](https://docs.google.com/document/d/1sWQNosqufxOFCX7qO_Xsu9sIC7f6SH-UtT08NGZRkUo/edit?usp=sharing)

a simple project in the genre of "Find the differences" with architecture built on Singleton(🤢)

Duration: 3 days

# Technical issues:
The application will not be built without Admob App Id, even if you make a "stub" instead of advertising, because in any case, if the Appodeal SDK is integrated into the application, the project will not come together.


# For the future:

- it is quite simple to implement saving via PlayerPrefs

- You can also use the factory pattern to create a level based on ScriptbleObject, which will speed up further level creation and simplify the implementation of additional mechanics, for example, difficulty levels, on which the number of necessary differences will depend (easy - 5, medium - 7, hard - 10), etc.
- To improve the architecture of the project, you can use Zenject to remove dependencies, thereby making the project easier to scale. 
- Zenject will get rid of "harmful Singletons"
- With Zenject it will be easier to integrate Adressables into the project
