CREATE DATABASE CompanyDB;
GO
USE CompanyDB;
GO


CREATE TABLE Department(
Dnumber INT NOT NULL PRIMARY KEY ,
Dname VARCHAR(15) NOT NULL UNIQUE ,
NumberOfEmployees INT DEFAULT 0, 
Mgr_ssn CHAR(9) NOT NULL,
Mgr_start_date DATE
);


CREATE TABLE Employee (
Ssn CHAR(9) PRIMARY KEY ,
Fname VARCHAR(15) NOT NULL ,
Minit CHAR(1) NULL ,
Lname VARCHAR(15) NOT NULL , 
Address VARCHAR(50),
Sex CHAR(1) CHECK (Sex IN ('M','F')) ,--make sure the entery is correct 
Bdate DATE ,
Salary DECIMAL(10,2) CHECK(Salary>0),--no neg numbers or 0
Super_ssn CHAR(9),
Dno INT NOT NULL , 
CONSTRAINT FK_Employee_SuperSSN FOREIGN KEY(Super_ssn) REFERENCES Employee(Ssn) ,
CONSTRAINT FK_Employee_Department  FOREIGN KEY(Dno) REFERENCES Department(Dnumber)
);
-- we do this because we cant refrence Employee table before its created
ALTER TABLE Department
ADD CONSTRAINT FK_manager_SuperSSN 
FOREIGN KEY (Mgr_ssn) REFERENCES Employee(Ssn);

CREATE TABLE Dept_locations(
Dnumber INT NOT NULL ,
CONSTRAINT FK_locations_Department  FOREIGN KEY(Dnumber) REFERENCES Department(Dnumber),
Dlocation VARCHAR(15) NOT NULL ,
PRIMARY KEY (Dnumber, Dlocation)
);

CREATE TABLE Project (
Pname VARCHAR(15) NOT NULL UNIQUE , 
Pnumber INT NOT NULL PRIMARY KEY  ,
Plocation VARCHAR(15) , 
Dnum INT NOT NULL , 
CONSTRAINT FK_project_Department  FOREIGN KEY(Dnum) REFERENCES Department(Dnumber)
);

CREATE TABLE Works_on(
Essn CHAR(9) NOT NULL , 
CONSTRAINT FK_Employee_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Pno INT NOT NULL ,
CONSTRAINT FK_project_no FOREIGN KEY(Pno) REFERENCES Project(Pnumber),
PRIMARY KEY (Essn , Pno),
Hours	DECIMAL(3,1) CHECK (Hours > 0)
);

CREATE TABLE Dependent(
Dependent_name 	VARCHAR(15) NOT NULL,
Essn CHAR(9) NOT NULL , 
PRIMARY KEY (Dependent_name,Essn ),
CONSTRAINT FK_Employee_Dep_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Sex CHAR(1) CHECK (Sex IN ('M','F')) ,
Bdate DATE ,
Relationship VARCHAR(15)
);

ALTER TABLE Department NOCHECK CONSTRAINT FK_manager_SuperSSN;

INSERT INTO Department(Dnumber, Dname, NumberOfEmployees, Mgr_ssn, Mgr_start_date) VALUES 
(1, 'Research', 5, '111111111', '2020-01-15'),
(2, 'Administration', 4, '444', '2019-06-01');

INSERT INTO Employee (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Super_ssn, Dno) VALUES
('111111111', 'John', 'B', 'Smith', '731 Fondren, Houston TX', 'M', '1965-01-09', 55000.00, NULL, 1),
('222222222', 'Franklin', 'T', 'Wong', '638 Voss, Houston TX', 'M', '1970-12-08', 45000.00, '111', 1),
('333333333', 'Alicia', 'J', 'Zelaya', '3321 Castle, Spring TX', 'F', '1978-07-19', 37000.00, '222', 1),
('444444444', 'Jennifer', 'S', 'Wallace', '291 Berry, Bellaire TX', 'F', '1971-06-20', 52000.00, NULL, 2),
('555555555', 'Ramesh', 'K', 'Narayan', '975 Fire Oak, Humble TX', 'M', '1982-09-15', 41000.00, '444', 2);

ALTER TABLE Department WITH CHECK CHECK CONSTRAINT FK_manager_SuperSSN;

INSERT INTO Project (Pnumber, Pname, Plocation, Dnum) VALUES
(1, 'ProductX', 'Bellaire', 1),
(2, 'ProductY', 'Sugarland', 1),
(3, 'ProductZ', 'Houston', 2);

INSERT INTO Works_on (Essn, Pno, Hours) VALUES
('111111111', 1, 10.0),
('222222222', 1, 20.0),
('222222222', 2, 15.5),
('333333333', 3, 30.0);

INSERT INTO Dependent (Essn, Dependent_name, Sex, Bdate, Relationship) VALUES
('111111111', 'Alice', 'F', '1988-04-05', 'Daughter'),
('111111111', 'Michael', 'M', '1990-10-25', 'Son'),
('222222222', 'Joy', 'F', '1972-05-03', 'Spouse');
 

UPDATE Employee
SET Salary = Salary * 1.10
WHERE Ssn = '333333333';

UPDATE Employee
SET Dno = 2
WHERE Ssn = '333333333';
 
UPDATE Project
SET Plocation = 'Stafford'
WHERE Pnumber = 2;
 
UPDATE Works_on
SET Hours = 25.0
WHERE Essn = '222222222' AND Pno = 2;
 
UPDATE Dependent
SET Relationship = 'Stepdaughter'
WHERE Essn = '111111111' AND Dependent_name = 'Alice';

UPDATE Employee SET Super_ssn = NULL WHERE Super_ssn = '222222222';
DELETE FROM Works_on WHERE Essn = '222222222';
DELETE FROM Dependent WHERE Essn = '222222222';
DELETE FROM Employee WHERE Ssn = '222222222';

DELETE FROM Works_on WHERE Essn = '555555555';
DELETE FROM Employee WHERE Ssn = '555555555';