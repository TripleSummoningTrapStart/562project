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
insert into solutions(Max_Percentage,JSonString,AssignmentId) values(percentage,jsonString,AssnId);
end
$$
language'plpgsql'


CREATE OR REPLACE FUNCTION addGrade(Graded_Against_SolutionId int, SubmissionId int, Grade int, GradeComments varchar)) 
returns void as $$
begin
insert into Graded(Graded_Against_SolutionId,SubmissionId,Grade,GradeComments) values (Graded_Against_SolutionId, SubmissionId , Grade, GradeComments);
end
$$
language'plpgsql'


CREATE OR REPLACE FUNCTION addAssignment( InstructorId int) returns void as $$
begin
insert into Assignments(InstructorId) values (InstructorId);
end
$$
language'plpgsql'



CREATE OR REPLACE FUNCTION addSubmissions( AssignmentId int, StudentId int, JSonString varchar) returns void as $$
begin
insert into Submissions(AssignmentId,StudentId,JsonString) values (AssignmentId , StudentId,  JSonString);
end
$$
language'plpgsql'


CREATE OR REPLACE FUNCTION addPeople( isIntructor bit, First_Name varchar(50), Last_Name varchar(50)) returns void as $$
begin
insert into People(isInstructor, First_name, Last_Name) values (isIntructor   , First_Name ,  Last_Name );
end
$$
language'plpgsql'

