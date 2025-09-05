CREATE TABLE ${schema}.customer
(
    id             SERIAL PRIMARY KEY,

    account_nr     INTEGER     NOT NULL UNIQUE,

    created_on_utc TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.contact_info
(
    id             SERIAL PRIMARY KEY,

    first_name     VARCHAR(100) NOT NULL,
    last_name      VARCHAR(100) NOT NULL,
    phone          VARCHAR(50) NULL,
    mobile         VARCHAR(50) NULL,

    customer_id    INTEGER      NOT NULL
        REFERENCES ${schema}.customer (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,

    created_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ  NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.user
(
    id             SERIAL PRIMARY KEY,

    email          VARCHAR(100) NOT NULL UNIQUE,
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
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    expiration_time timestamp,

    created_on_utc  TIMESTAMPTZ  NOT NULL DEFAULT now(),
    updated_on_utc  TIMESTAMPTZ  NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.location
(
    id             SERIAL PRIMARY KEY,

    customer_id    INTEGER     NOT NULL
        REFERENCES ${schema}.customer (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,

    created_on_utc TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ NOT NULL DEFAULT now()
);


CREATE TABLE ${schema}.address
(
    id             SERIAL PRIMARY KEY,

    street         VARCHAR(255) NULL,
    house_nr       VARCHAR(50) NULL,
    block          VARCHAR(50) NULL,
    entrance       VARCHAR(50) NULL,
    apartment_nr   VARCHAR(50) NULL,
    locality       VARCHAR(50) NULL,
    district       VARCHAR(50) NULL,
    postal_code    VARCHAR(50) NULL,
    country        VARCHAR(50) NULL,

    location_id    INTEGER     NOT NULL
        REFERENCES ${schema}.location (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,

    created_on_utc TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.counter
(
    id             SERIAL PRIMARY KEY,

    reading_value  INTEGER     NOT NULL DEFAULT 0,
    barcode        VARCHAR     NOT NULL DEFAULT '',
    usage_type     INTEGER     NOT NULL DEFAULT 0,
    location_id    INTEGER     NOT NULL
        REFERENCES ${schema}.location (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,

    created_on_utc TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_on_utc TIMESTAMPTZ NOT NULL DEFAULT now()
);

CREATE TABLE ${schema}.role
(
    id          SERIAL PRIMARY KEY,

    name        VARCHAR(100) NOT NULL,
    customer_id INTEGER      NOT NULL UNIQUE
        REFERENCES ${schema}.customer (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)

CREATE TABLE ${schema}.customer_role_mapping
(
    id        SERIAL PRIMARY KEY,

    policy_id INTEGER NOT NULL,
    role_id   INTEGER NOT NULL
        REFERENCES ${schema}.role (id)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)