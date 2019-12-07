require('dotenv/config');

const { DB_PORT, DB_USERNAME, DB_PASSWORD, DB_DATABASE } = process.env;

module.exports = [{
    name: 'default',
    type: 'mysql',
    host: 'localhost',
    port: DB_PORT,
    username: DB_USERNAME,
    password: DB_PASSWORD,
    database: DB_DATABASE,
    synchronize: true,
    entities: [
        "src/models/*.ts"
    ],
    subscribers: [
        "src/subscribers/*.ts"
    ],
    migrations: [
        "src/migrations/*.ts"
    ],
    cli: {
        entitiesDir: "src/models",
        migrationsDir: "src/migrations",
        subscribersDir: "src/subscribers"
    }
}];