DROP TABLE applications;
DROP TABLE containers;
DROP TABLE records;
DROP TABLE notifications;


CREATE TABLE applications (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) UNIQUE NOT NULL,
    creation_datetime DATETIME2 NOT NULL
);

CREATE TABLE containers (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    FOREIGN KEY (parent) REFERENCES applications(id) ON DELETE CASCADE,
    CONSTRAINT UQ_Containers_Name_Parent UNIQUE (name, parent)
);

CREATE TABLE records (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    content NVARCHAR(1023) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    FOREIGN KEY (parent) REFERENCES containers(id) ON DELETE CASCADE,
    CONSTRAINT UQ_Containers_Name_Parent UNIQUE (name, parent)
);

CREATE TABLE notifications (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    creation_datetime DATETIME2 NOT NULL,
    parent INT NOT NULL,
    event NVARCHAR(255) NOT NULL,
    endpoint NVARCHAR(255) NOT NULL,
    enabled BIT NOT NULL,
    FOREIGN KEY (parent) REFERENCES containers(id) ON DELETE CASCADE,
    CONSTRAINT CHK_Event CHECK (event IN ('1','2')),
    CONSTRAINT UQ_Containers_Name_Parent UNIQUE (name, parent)
);
