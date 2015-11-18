
CREATE FUNCTION addSubmission(submission varchar, AssignmentId int, StudentId, int) returns void as $$
declare sub varchar;
begin

sub = sanitize //make this;

insert into submissions values (AssignmentId, StudentId, sub)

end
$$
language'plpgsql'

create trigger insert_grade
after insert on submissions
for each row
execute procedure grade_trigger();

create function grade_trigger() returns trigger as $$
begin
perform grade(new.JsonString, new.submissionID, new.assignmentId)
return new;
end;
$$
language'plpgsql'

create function grade(JsonString, submissionID, assignmentId) returns void as $$
declare sub int;
begin
select * from solutions s where assignmentID = s.assignmentID;
foreach solution
    grade = call C function.
insert into graded(submissionID, assignmentId, grade)

CREATE OR REPLACE FUNCTION addSolution(percentage int, jsonString varchar, AssnId int) 
returns void as $$
begin
insert into solutions(Max_Percentage,JSonString,AssignmentId) values(percentage,jsonString,AssignmentId);
end
$$
language'plpgsql'


CREATE FUNCTION addGrade(Graded_Against_SolutionId int, SubmissionId int, Grade int, GradeComments varchar(Max)) returns void as $$
begin
insert into Graded values (Graded_Against_SolutionId, SubmissionId , Grade, GradeComments  )

end
$$
language'plpgsql'


CREATE FUNCTION addAssignment( InstructorId int, DueDate DateTime) returns void as $$
begin
insert into Assignments values (InstructorId, DueDate)
end
$$
language'plpgsql'


CREATE FUNCTION addSubmissions( AssignmentId int, StudentId int, JSonString varchar(max), SubmissionDate DATETIME) returns void as $$
begin
insert into Submissions values (AssignmentId , StudentId,  JSonString,  SubmissionDate )
end
$$
language'plpgsql'


CREATE FUNCTION addSolutions( Max_Percentage int, JSonString varchar, SubmissionDate DATETIME) returns void as $$
begin
insert into Solutions values (Max_Percentage  , JSonString ,  SubmissionDate )
end
$$
language'plpgsql'

CREATE FUNCTION addPeople( isIntructor bit, First_Name varchar(50), Last_Name varchar(50)) returns void as $$
begin
insert into People values (isIntructor   , First_Name ,  Last_Name )
end
$$
language'plpgsql'

