CREATE TABLE ${schema}.customers
(
    id         SERIAL PRIMARY KEY,
    full_name  VARCHAR(150) NOT NULL,
    email      VARCHAR(120),
    phone      VARCHAR(30),
    address    VARCHAR(255),
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE ${schema}.utilities
(
    id           SERIAL PRIMARY KEY,
    utility_name VARCHAR(100) NOT NULL,
    unit_type    VARCHAR(30)  NOT NULL
);

CREATE TABLE ${schema}.service_connections
(
    id                 SERIAL PRIMARY KEY,
    customer_id        INT  NOT NULL REFERENCES ${schema}.customers (id),
    utility_id         INT  NOT NULL REFERENCES ${schema}.utilities (id),
    connection_address VARCHAR(255),
    start_date         DATE NOT NULL,
    status             VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE ${schema}.service_meters
(
    id                SERIAL PRIMARY KEY,
    connection_id     INT                 NOT NULL REFERENCES ${schema}.service_connections (id),
    serial_number     VARCHAR(100) UNIQUE NOT NULL,
    installation_date DATE,
    status            VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE ${schema}.consumption_records
(
    id          SERIAL PRIMARY KEY,
    meter_id    INT            NOT NULL REFERENCES ${schema}.service_meters (id),
    record_date DATE           NOT NULL,
    amount_used NUMERIC(10, 2) NOT NULL,
    UNIQUE (meter_id, record_date)
);

CREATE TABLE ${schema}.tariff_rates
(
    id             SERIAL PRIMARY KEY,
    utility_id     INT            NOT NULL REFERENCES ${schema}.utilities (id),
    price_per_unit NUMERIC(10, 4) NOT NULL,
    effective_from DATE           NOT NULL,
    effective_to   DATE,
    is_active      BOOLEAN DEFAULT TRUE
);

CREATE TABLE ${schema}.bills
(
    id                   SERIAL PRIMARY KEY,
    connection_id        INT            NOT NULL REFERENCES ${schema}.service_connections (id),
    billing_period_start DATE           NOT NULL,
    billing_period_end   DATE           NOT NULL,
    total_consumption    NUMERIC(10, 2) NOT NULL,
    total_cost           NUMERIC(12, 2) NOT NULL,
    generated_at         TIMESTAMP   DEFAULT NOW(),
    status               VARCHAR(20) DEFAULT
);

CREATE TABLE ${schema}.payments
(
    id           SERIAL PRIMARY KEY,
    bill_id      INT            NOT NULL REFERENCES ${schema}.bills (id),
    payment_date TIMESTAMP DEFAULT NOW(),
    amount_paid  NUMERIC(12, 2) NOT NULL,
    method       VARCHAR(50)
);