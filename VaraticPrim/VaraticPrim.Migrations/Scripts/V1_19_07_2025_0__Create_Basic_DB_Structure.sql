CREATE TABLE ${schema}.user
(
    id             SERIAL PRIMARY KEY,
    email          VARCHAR(255) NOT NULL UNIQUE,
    password_hash  VARCHAR(255) NOT NULL,
    password_salt  VARCHAR(255) NOT NULL,
    created_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now()
);