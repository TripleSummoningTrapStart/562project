
CREATE FUNCTION addSubmission(submission varchar, AssignmentId int, StudentId int) returns void as $$
declare sub varchar;
begin

sub = sanitize //make this;

insert into submissions(JSonString, AssignmentId, StudentId) values (submission, AssignmentId, StudentId)

end
$$
language'plpgsql'

CREATE FUNCTION getSubmission(SubmissionId int) 
returns void as $$
begin
select * from submissions s where s.SubmissionId = SubmissionId
end
$$
language'plpgsql'
/*
create trigger insert_grade
after insert on submissions
for each row
execute procedure grade_trigger();
/*
create function grade_trigger() returns trigger as $$
begin
perform grade(new.JsonString, new.submissionID, new.assignmentId)
return new;
end;
$$
language'plpgsql'
*/
CREATE FUNCTION addGrade(grade int, submissionId int, assignmentId int, solutionId int) returns void as $$
declare sub int;
begin

insert into graded(Grade, SubmissionId, AssignmentId, Graded_Against_SolutionId) values(grade, submissionID, assignmentId, solutionId)
end
$$
language'plpgsql'

CREATE FUNCTION addPerson(firstname varchar, lastname varchar,isinstructor bit)
returns void as $$
declare sub bit;
begin
insert into people(First_Name, Last_Name,isInstructor) values(firstname,lastname,isinstructor)
end
$$
language'plpgsql'


CREATE FUNCTION addSolution(percentage int, jsonString varchar, AssnId int) 
returns void as $$
begin
insert into solutions(Max_Percentage,JSonString,AssignmentId) values(percentage,jsonString,AssignmentId)
end
$$
language'plpgsql'

CREATE FUNCTION getSolution(AssnId int) 
returns void as $$
begin
select * from solutions s where s.AssignmentId = AssnId
end
$$
language'plpgsql'