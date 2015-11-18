
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




CREATE FUNCTION addSolution(percentage int, jsonString varchar, AssnId int) 
returns void as $$
begin
insert into solutions(Max_Percentage,JSonString,AssignmentId) values(percentage,jsonString,AssignmentId)
end
$$
language'plpgsql'