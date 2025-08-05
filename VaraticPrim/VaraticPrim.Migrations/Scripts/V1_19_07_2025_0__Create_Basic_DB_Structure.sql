CREATE TABLE ${schema}.user
(
    id             SERIAL PRIMARY KEY,
    email          VARCHAR(255) NOT NULL UNIQUE,
    password_hash  VARCHAR(255) NOT NULL,
    password_salt  VARCHAR(255) NOT NULL,
    created_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.refresh_token
(
    id              SERIAL PRIMARY KEY,
    refresh_token   VARCHAR(255) NOT NULL UNIQUE,
    user_id         INTEGER      NOT NULL
        REFERENCES ${schema}.user (id)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    expiration_time timestamp,
    created_on_utc  TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updated_on_utc  TIMESTAMPTZ  NOT NULL DEFAULT now()
);