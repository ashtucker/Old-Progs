unit IO;

interface

uses
  TRIE, DATA;

procedure getword(var x: wordtype; input: text);
procedure Print(x: wordtype; f:text);

implementation

procedure getword(var x: wordtype; input: text);
var
  i: integer;
begin
  i:=1;
  read(input, x[1]);
  while(x[i]<>',') do 
  begin
  if (x[i]<> ' ') then inc(i);
  read(input, x[i]);
  end
end;{getword}

procedure Print(x: wordtype; f:text);
var i: integer;
begin
i:=1;
 while(x[i]<>',') do 
 begin
 write(f,x[i]);
 inc(i);
 end;
 writeln(f,' ');
end; {Print}


end.