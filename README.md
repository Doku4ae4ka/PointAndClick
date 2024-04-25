# Описание:
[Тетствовое задание] (https://docs.google.com/document/d/1sWQNosqufxOFCX7qO_Xsu9sIC7f6SH-UtT08NGZRkUo/edit?usp=sharing)
простой проект в жанре "Find the differences@ с архитектурой построенной на Singletonах(🤢)

# Технические вопросы:
Приложение не будет билдиться без Admob App Id, даже если сделать "заглушку" вместо рекламы, т.к. в любом случае если в приложение интегрирован SDK Appodeal, проект не собереться.


# На будущее:

- довольно просто можно реализовать сохранения через PlayerPrefs

- Так же можно воспользоваться паттерном фабрика для создания уровня на основе ScriptbleObject, что ускорит дальнейшее создание уровней и упростит реализацию дополнительных механик, например, уровней сложности, от которых будет зависеть количество необходимых отличий (easy - 5, medium - 7, hard - 10) и тд.
- Для улучшения архитектуры проекта, можно воспользоваться Zenject, чтобы убрать зависимости, тем самым сделать проект более простым в масштабируемости. 
- Zenject позволит избавиться от «пагубных Singletonов»
- С Zenjectом будет проще интегрировать Adressables в проект

