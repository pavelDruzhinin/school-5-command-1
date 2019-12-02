# Backend

## Запуск

`cd src && dotnet run`

## Swagger

Находится на пути

`https://pathtotheapp/swagger`

## Database

Создать докер контейнер для PostgreSql `docker run --name chatbot-postgres -d -v /tmp/chatbot/postgres/data:/var/lib/postgresql/data -p 5432:5432 postgres`

Загрузить архитектуру EntityFramework в базу данных `dotnet ef database update`

## Environments

Разные среды нужны чтобы использовались правильные файлы конфигурации

- Development - Для локального тестирования через консоль
- Staging - Для тестирования в докер контейнере
- Production - Для готового приложения

## Список информации

- [Доки и туториалы](https://docs.google.com/document/d/1L_hx1-rpzOMdtZuEX7e6kqsJZEtRCyv_AQWuK1tI-Dw/edit?usp=sharing)
