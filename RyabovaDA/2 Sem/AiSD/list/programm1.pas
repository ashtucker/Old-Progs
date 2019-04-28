program programm1;

uses ListModule;

var a:TProgramming;
begin
  a:= TProgramming.create('input.txt');
  a.Print();
  a.Destroy;
end.

