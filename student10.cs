using System.Collections.Generic;

CREATE DATABASE CollegeDB;

USE CollegeDB;

CREATE TABLE Student
(
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Course VARCHAR(50)
);

INSERT INTO Student VALUES
(1, 'Hemant', 'MCA'),
(2, 'Rahul', 'BCA'),
(3, 'Amit', 'B.Tech');