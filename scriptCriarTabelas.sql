CREATE TABLE application (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    creation_datetime DATETIME2 NOT NULL
);

CREATE TABLE container (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    FOREIGN KEY (parent) REFERENCES application(id)
);

CREATE TABLE record (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    content NVARCHAR(1023) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    FOREIGN KEY (parent) REFERENCES container(id)
);

CREATE TABLE notification (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    event NVARCHAR(255) NOT NULL,
    endpoint NVARCHAR(255) NOT NULL,
    enabled BIT NOT NULL,
    FOREIGN KEY (parent) REFERENCES container(id)
);
