DROP SCHEMA IF EXISTS viabnb CASCADE;
CREATE SCHEMA viabnb;
SET SCHEMA 'viabnb';

CREATE TABLE IF NOT EXISTS TestMessage
(
    id INT GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    msg VARCHAR
);