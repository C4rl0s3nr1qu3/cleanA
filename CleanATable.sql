INSERT INTO CLEANAONE.USUARIOS(ID, NAME, EMAIL, PASSWORD, IDORGANIZACIONES) 
VALUES ('23','Carlos','cpenapena@hotmai.com','C4rl0s','100');
commit;

INSERT INTO CLEANAONE.ORGANIZACIONES(ID, NAME, SLUG_TENANT) 
VALUES ('100','SAGA SAC', 'SAGA');
commit;
----------===========================
-- dborkku CLEANAONE
----------===========================

--CREATE SCHEMA CLEANAONE;
--commit;

-- Table: CLEANAONE.ORGANIZACIONES
DROP TABLE IF EXISTS CLEANAONE.ORGANIZACIONES CASCADE;

CREATE TABLE CLEANAONE.ORGANIZACIONES (
    ID              VARCHAR (10)  NOT NULL,
    NAME            VARCHAR (200),
    SLUG_TENANT     VARCHAR (200),
    CONSTRAINT PK_ORGANIZACIONES PRIMARY KEY (
        ID
    ),
    CONSTRAINT U_ORGANIZACIONES UNIQUE (
        ID
    )
);
GRANT INSERT, SELECT, TRIGGER, TRUNCATE, UPDATE, DELETE, REFERENCES ON CLEANAONE.ORGANIZACIONES TO orkku_user;
COMMIT;

-- Table: CLEANAONE.USUARIOS
DROP TABLE IF EXISTS CLEANAONE.USUARIOS CASCADE;

CREATE TABLE CLEANAONE.USUARIOS (
    ID          VARCHAR (10)    NOT NULL,
    NAME        VARCHAR (200),
    EMAIL       VARCHAR (200),
    PASSWORD    VARCHAR (200),
    IDORGANIZACIONES    VARCHAR (10)   NOT NULL,  
    CONSTRAINT PK_USUARIOS PRIMARY KEY (
        ID
    ),
    CONSTRAINT U_USUARIOS UNIQUE (
        ID
    ),
    CONSTRAINT FK_USUARIOS_ORGANIZACIONES FOREIGN KEY (
        IDORGANIZACIONES
    )
    REFERENCES CLEANAONE.ORGANIZACIONES (ID) 
);
GRANT INSERT, SELECT, TRIGGER, TRUNCATE, UPDATE, DELETE, REFERENCES ON CLEANAONE.USUARIOS TO orkku_user;
COMMIT;



----------===========================
-- dbose CLEANATWO
----------===========================

--CREATE SCHEMA CLEANATWO;
--commit;

-- Table: CLEANATWO.PRODUCTOS
DROP TABLE IF EXISTS CLEANATWO.PRODUCTOS CASCADE;

CREATE TABLE CLEANATWO.PRODUCTOS (
    ID                  VARCHAR (10)   NOT NULL,    
    NAME         VARCHAR (200),
    IDORGANIZACIONES    VARCHAR (10)   NOT NULL,  
    CONSTRAINT PK_PRODUCTOS PRIMARY KEY (
        ID
    ),
    CONSTRAINT U_PRODUCTOS UNIQUE (
        ID
    )
);
GRANT INSERT, SELECT, TRIGGER, TRUNCATE, UPDATE, DELETE, REFERENCES ON CLEANATWO.PRODUCTOS TO orkku_user;
COMMIT;



