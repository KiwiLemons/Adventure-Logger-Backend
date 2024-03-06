use adventure_logger;

/*
Seed User values
*/
INSERT INTO user (username, password) VALUES ('austen', '12345');
INSERT INTO user (username, password) VALUES ('jaden', '12345');
INSERT INTO user (username, password) VALUES ('kaiden', '12345');
INSERT INTO user (username, password) VALUES ('tester', '12345');
/*
Seed Route values
*/
INSERT INTO route (data, user_id, name) VALUES (NULL, 1, 'empty route');

/*
Seed Friend values
*/

INSERT INTO friend VALUES (3, 1);
INSERT INTO friend VALUES (1, 3);
INSERT INTO friend VALUES (1, 2);
INSERT INTO friend VALUES (2, 3);