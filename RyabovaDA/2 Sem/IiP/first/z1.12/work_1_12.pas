program work_1_12;

uses main_work;
var
  DoThisExercise:TMainProgram;
begin
  DoThisExercise:= TMainProgram.create(3);
  DoThisExercise.DoWork();
  ReadLn();
end.

