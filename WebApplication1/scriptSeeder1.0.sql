-- Inserting sample applications
INSERT INTO applications (name, creation_datetime)
VALUES
    ('Application1', GETDATE()),
    ('Application2', GETDATE()),
    ('Application3', GETDATE()),
    ('Application4', GETDATE()),
    ('Application5', GETDATE()),
    ('Application6', GETDATE());

-- Inserting sample containers
INSERT INTO containers (name, creation_datetime, parent) 
VALUES
    ('Container1', GETDATE(), 1),  
    ('Container2', GETDATE(), 1),  
    ('Container3', GETDATE(), 2),  
    ('Container4', GETDATE(), 2), 
    ('Container5', GETDATE(), 3), 
    ('Container6', GETDATE(), 4), 
    ('Container7', GETDATE(), 5),  
    ('Container8', GETDATE(), 6); 

-- Inserting sample records
INSERT INTO records (name, content, creation_datetime, parent) 
VALUES
    ('Record1', 'Content of Record1', GETDATE(), 1), 
    ('Record2', 'Content of Record2', GETDATE(), 1), 
    ('Record3', 'Content of Record3', GETDATE(), 2), 
    ('Record4', 'Content of Record4', GETDATE(), 3),  
    ('Record5', 'Content of Record5', GETDATE(), 4),  
    ('Record6', 'Content of Record6', GETDATE(), 5),  
    ('Record7', 'Content of Record7', GETDATE(), 6), 
    ('Record8', 'Content of Record8', GETDATE(), 7),  
    ('Record9', 'Content of Record9', GETDATE(), 8); 

-- Inserting sample notifications
INSERT INTO notifications (name, event, endpoint, creation_datetime, parent, enabled)
VALUES
    ('Notification1', '1', 'http://endpoint1.com', GETDATE(), 1, 1),  
    ('Notification2', '1', 'http://endpoint2.com', GETDATE(), 1, 1),  
    ('Notification3', '1', 'http://endpoint3.com', GETDATE(), 2, 1),  
    ('Notification4', '2', 'http://endpoint4.com', GETDATE(), 3, 0),  
    ('Notification5', '2', 'http://endpoint5.com', GETDATE(), 4, 1),  
    ('Notification6', '1', 'http://endpoint6.com', GETDATE(), 5, 1), 
    ('Notification7', '2', 'http://endpoint7.com', GETDATE(), 6, 0),  
    ('Notification8', '1', 'http://endpoint8.com', GETDATE(), 7, 1), 
    ('Notification9', '2', 'http://endpoint9.com', GETDATE(), 8, 1), 
    ('Notification10', '1', 'http://endpoint10.com', GETDATE(), 1, 1); 
