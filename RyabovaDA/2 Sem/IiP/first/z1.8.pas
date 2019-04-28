const
  cn = 8;

type
  ar = array[1..cn,1..cn] of boolean;

var
  n, i, j: integer;
  a, b: ar;

function pred(a: ar; n: integer): boolean;
var
  i, j: integer;
  strue, sfalse: integer;
begin
  strue := 0;
  sfalse := 0;
  result := false;
  for i := 1 to n do
    for j := 1 to n do
    begin
      if i > j then
        if a[i, j] = true then strue := strue + 1
      else
      if i < j then
        if a[i, j] = false then sfalse := sfalse + 1;
    end;
  if strue > sfalse then
    result := true;
end;

procedure transp(a: arr; var b: arr; n: integer);
var
  i, j: integer;
begin
  for i := 1 to n do
    for j := 1 to n do
      b[j, i] := a[i, j];
end;

procedure print(matr: arr; n: integer);
var
  i, j: integer;
begin
  for i := 1 to n do
  begin
    for j := 1 to n do
      write(matr[i ,j], ' ');
    writeln;
  end;
end;

begin

  readln(n);
  for i := 1 to n do
    for j := 1 to n do
      read(a[i, j]);
  writeln;

  if pred(a, n) then
  begin
    transp(a, b, n);
    print(b, n);
  end
  else
    write('P(A) = false');

END.