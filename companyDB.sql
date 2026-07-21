CREATE DATABASE CompanyDB; GO; USE CompanyDB;

CREATE TABLE Department(
Dnumber INT NOT NULL PRIMARY KEY ,
Dname VARCHAR(15) NOT NULL UNIQUE ,
NumberOfEmployees INT , 
Mgr_ssn CHAR(9) NOT NULL,
Mgr_start_date DATE ,
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
PRIMARY KEY (Dnumber, Dlocation),
);

CREATE TABLE Project (
Pname VARCHAR(15) NOT NULL UNIQUE , 
Pnumber INT NOT NULL PRIMARY KEY  ,
Plocation VARCHAR(15) , 
Dnum INT NOT NULL , 
CONSTRAINT FK_project_Department  FOREIGN KEY(Dnum) REFERENCES Department(Dnumber),
);

CREATE TABLE Works_on(
Essn CHAR(9) NOT NULL , 
CONSTRAINT FK_Employee_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Pno INT NOT NULL ,
CONSTRAINT FK_project_no FOREIGN KEY(Pno) REFERENCES Project(Pnumber),
PRIMARY KEY (Essn , Pno),
Hours	DECIMAL(3,1) CHECK (Hours > 0),

);

CREATE TABLE Dependent(
Dependent_name 	VARCHAR(15) NOT NULL,
Essn CHAR(9) NOT NULL , 
PRIMARY KEY (Dependent_name,Essn ),
CONSTRAINT FK_Employee_Dep_SSN FOREIGN KEY(Essn) REFERENCES Employee(Ssn),
Sex CHAR(1) CHECK (Sex IN ('M','F')) ,
Bdate DATE ,
Relationship VARCHAR(15),
);
