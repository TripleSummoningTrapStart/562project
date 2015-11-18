-- ---
-- Table 'People'
-- 
-- ---

DROP TABLE IF EXISTS `People`;
		
CREATE TABLE `People` (
  `PeopleId` INTEGER NOT NULL SERIAL,
  `isInstructor` bit NULL,
  `First_Name` VARCHAR(50) NOT NULL ,
  `Last_Name` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`PeopleId`)
);

-- ---
-- Table 'Solutions'
-- 
-- ---

DROP TABLE IF EXISTS `Solutions`;
		
CREATE TABLE `Solutions` (
  `SolutionId` INTEGER NOT NULL SERIAL ,
  `Max_Percentage` INTEGER NOT NULL ,
  `JSonString` VARCHAR(MAX) NOT NULL ,
  `AssignmentId` INTEGER NOT NULL REFERENCES Assignments(AssignmentId),
  PRIMARY KEY (`SolutionId`)
);

-- ---
-- Table 'Submissions'
-- 
-- ---

DROP TABLE IF EXISTS `Submissions`;
		
CREATE TABLE `Submissions` (
  `SubmissionId` INTEGER NOT NULL SERIAL DEFAULT NULL,
  `AssignmentId` INTEGER NOT NULL REFERENCES Assignments(AssignmentId),
  `StudentId` INTEGER NOT NULL REFERENCES People(PeopleId),
  `JSonString` VARCHAR(MAX) NOT NULL ,
  `SubmissionDate` DATETIME NOT NULL ,
  PRIMARY KEY (`SubmissionId`)
);

-- ---
-- Table 'Assignments'
-- 
-- ---

DROP TABLE IF EXISTS `Assignments`;
		
CREATE TABLE `Assignments` (
  `AssignmentId` INTEGER NOT NULL SERIAL ,
  `InstructorId` INTEGER NOT NULL REFERENCES People(PeopleId),
  `DueDate` DATETIME NULL ,
  PRIMARY KEY (`AssignmentId`)
);

-- ---
-- Table 'Graded'
-- 
-- ---

DROP TABLE IF EXISTS `Graded`;
		
CREATE TABLE `Graded` (
  `GradeId` INTEGER NULL SERIAL,
  `Graded_Against_SolutionId` INTEGER NOT NULL REFERENCES Solutions(SolutionId),
  `SubmissionId` INTEGER NOT NULL REFERENCES Submissions(SubmissionId),
    `AssignmentId` INTEGER NOT NULL REFERENCES Assignments(AssignmentId),
  `Grade` INTEGER NOT NULL ,
  `GradeComments` VARCHAR(MAX) NULL,
  PRIMARY KEY (`GradeId`)
);


-- ---
-- Test Data
-- ---

-- INSERT INTO `People` (`PeopleId`,`isInstructor`,`First_Name`,`Last_Name`) VALUES
-- ('','','','');
-- INSERT INTO `Solutions` (`SolutionId`,`Max_Percentage`,`JSonString`,`AssignmentId`) VALUES
-- ('','','','');
-- INSERT INTO `Submissions` (`SubmissionId`,`AssignmentId`,`StudentId`,`JSonString`,`SubmissionDate`) VALUES
-- ('','','','','');
-- INSERT INTO `Assignments` (`AssignmentId`,`InstructorId`,`DueDate`) VALUES
-- ('','','');
-- INSERT INTO `Graded` (`GradeId`,`Graded_Against_SolutionId`,`SubmissionId`,`Grade`,`GradeComments`) VALUES
-- ('','','','','');