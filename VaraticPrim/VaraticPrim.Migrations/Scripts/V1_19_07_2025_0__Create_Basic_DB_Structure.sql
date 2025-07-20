CREATE TABLE ${schema}.user
(
    id           SERIAL PRIMARY KEY,
    email        VARCHAR(255) NOT NULL UNIQUE,
    password     VARCHAR(255) NOT NULL,
    createdOnUtc TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updatedOnUtc TIMESTAMPTZ  NOT NULL DEFAULT now()
);