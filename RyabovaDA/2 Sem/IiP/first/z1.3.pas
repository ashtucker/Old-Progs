const
  n = 15;

type
  ar = array [0..n] of real;

procedure print(a: ar);
var
  i: integer;
begin
  for i := 1 to n do write(a[i]:3:2, ' ');
  writeln;
end;

procedure sort(a: ar; var b: ar; n: integer);
var
  i, min, j: integer;
  m: real;
begin
  for i := 1 to n - 1 do
  begin
    min := i;
    for j := i + 1 to n do
      if abs(a[min]) > abs(a[j]) then          //сортировка по модулю равна сортировке в квадрате
        min := j;
    if min <> i then begin
      m := a[min];
      a[min] := a[i];
      a[i] := m;
    end;
  end;
  for i := 1 to n do
    b[i] := a[i];
end;

function vichislenie(var x: real): real;
var
  b: real;
begin
  b := 1.2 + abs(x);
  b := b / (1.8 + abs(x - 1));
  b := b * cos(x * x + x + 1);
  vichislenie := b;
end;

var
  x, y: ar;
  i: integer;

begin
  x[0] := -5.1;
  for i := 1 to n do
    x[i] := vichislenie(x[i - 1]);
  sort(x, y, n);
  print(x);
  print(y);
  i := n;
  while (y[i] > 0) or (i = 0) do
    i := i - 1;
  writeln('r=', i);
end.