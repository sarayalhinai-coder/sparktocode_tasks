CREATE DATABASE CompanyDB; GO; USE CompanyDB;

CREATE TABLE Department(
Dnumber INT NOT NULL PRIMARY KEY ,
Dname VARCHAR NOT NULL UNIQUE ,
NumberOfEmployees INT , 
Mgr_ssn CHAR ,
Mgr_start_date DATE ,
);


CREATE TABLE Employee (
Ssn CHAR PRIMARY KEY ,
Fname VARCHAR NOT NULL ,
Minit CHAR NULL ,
Lname VARCHAR NOT NULL , 
Address VARCHAR ,
Sex CHAR CHECK (Sex IN ('M','F')) ,--make sure the entery is correct 
Bdate DATE ,
Salary DECIMAL CHECK(Salary>0),--no neg numbers or 0
Super_ssn CHAR ,
Dno INT , 
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
Dlocation VARCHAR NOT NULL ,
PRIMARY KEY (Dnumber, Dlocation),
);

CREATE TABLE Project (
Pname VARCHAR NOT NULL UNIQUE , 
Pnumber INT NOT NULL UNIQUE,
PRIMARY KEY (Pname, Pnumber),
Plocation VARCHAR , 
Dnum INT NOT NULL , 
CONSTRAINT FK_project_Department  FOREIGN KEY(Dnum) REFERENCES Department(Dnumber),
);

CREATE TABLE Works_on(
Essn CHAR NOT NULL , 
CONSTRAINT FK_Employee_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Pno INT NOT NULL ,
CONSTRAINT FK_project_no FOREIGN KEY(Pno) REFERENCES Project(Pnumber),
Hours	DECIMAL CHECK (Hours > 0),
);

CREATE TABLE Dependent(
Dependent_name 	VARCHAR NOT NULL,
Essn CHAR NOT NULL , 
PRIMARY KEY (Dependent_name,Essn ),
CONSTRAINT FK_Employee_Dep_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Sex CHAR CHECK (Sex IN ('M','F')) ,
Bdate DATE ,
Relationship VARCHAR,
);
