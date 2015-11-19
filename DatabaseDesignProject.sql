-- ---
-- Table People
-- 
-- ---

DROP TABLE IF EXISTS People;
		
CREATE TABLE People (
  PeopleId SERIAL NOT NULL ,
  isInstructor bit NULL,
  First_Name VARCHAR(50) NOT NULL ,
  Last_Name VARCHAR(50) NOT NULL ,
  PRIMARY KEY (PeopleId)
);


-- ---
-- Table Assignments
-- 
-- ---

DROP TABLE IF EXISTS Assignments;
		
CREATE TABLE Assignments (
  AssignmentId SERIAL NOT NULL ,
  InstructorId INTEGER NOT NULL REFERENCES People(PeopleId),
  PRIMARY KEY (AssignmentId)
);

-- ---
-- Table Solutions
-- 
-- ---

DROP TABLE IF EXISTS Solutions;
		
CREATE TABLE Solutions (
  SolutionId SERIAL NOT NULL ,
  Max_Percentage INTEGER NOT NULL ,
  JSonString VARCHAR(100000) NOT NULL ,
  AssignmentId INTEGER NOT NULL REFERENCES Assignments(AssignmentId),
  PRIMARY KEY (SolutionId)
);

-- ---
-- Table Submissions
-- 
-- ---

DROP TABLE IF EXISTS Submissions;
		
CREATE TABLE Submissions (
  SubmissionId SERIAL NOT NULL  ,
  AssignmentId INTEGER NOT NULL REFERENCES Assignments(AssignmentId),
  StudentId INTEGER NOT NULL REFERENCES People(PeopleId),
  JSonString VARCHAR(100000) NOT NULL ,
  PRIMARY KEY (SubmissionId)
);


-- ---
-- Table Graded
-- 
-- ---

DROP TABLE IF EXISTS Graded;
		
CREATE TABLE Graded (
  GradeId SERIAL NOT NULL ,
  Graded_Against_SolutionId INTEGER NOT NULL REFERENCES Solutions(SolutionId),
  SubmissionId INTEGER NOT NULL REFERENCES Submissions(SubmissionId),
  Grade INTEGER NOT NULL ,
  GradeComments VARCHAR(100000) NULL,
  PRIMARY KEY (GradeId)
);


-- ---
-- Test Data
-- ---

-- INSERT INTO People (PeopleId,isInstructor,First_Name,Last_Name) VALUES
-- (,,,);
-- INSERT INTO Solutions (SolutionId,Max_Percentage,JSonString,AssignmentId) VALUES
-- (,,,);
-- INSERT INTO Submissions (SubmissionId,AssignmentId,StudentId,JSonString,SubmissionDate) VALUES
-- (,,,,);
-- INSERT INTO Assignments (AssignmentId,InstructorId,DueDate) VALUES
-- (,,);
-- INSERT INTO Graded (GradeId,Graded_Against_SolutionId,SubmissionId,Grade,GradeComments) VALUES
-- (,,,,);