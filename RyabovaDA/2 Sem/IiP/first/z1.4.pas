const
  n = 140;
  r = 9;

type
  ar = array[-2..n] of real;
  arint = array [0..r - 1] of integer;

function dvoichnoe(a: real): real;
//перевод числа в двоичное
var
  st, b, z: real;
begin
  st := 1;
  if a < 0 then begin
    a := -a;
    z := -1;
  end;
  if a < 1 then
    while a > 0 do
    begin
      a := a * 2;
      b := int(a);
      a := a - b;
      st := st / 10;
      res := res + b * st;
    end else res := 1;
  if z = -1 then res := -res;
end;

function vichX(x, y, z, a: real): real;
var
  t, b, c, f: real;
  i: integer;
begin
  f := (1+a*x)/(1+a*x+2*y+3*z);
  f := dvoichnoe(f);
  t := 1 / 2;
  c := 0;
  for i := 1 to 10 do //преобразование числа
  begin
    f := f * 10;
    b := int(f);
    f := f - b;
    if i = 10 then b := b / 2 else begin
      t := t / 2;
      b := b * t;
    end;
    c := c + b;
  end;
  res := c;
end;

procedure polyinterval(r: integer; x: ar; var e: arint);
//определяет принадлежность Х интервалу
var
  a1, a2: real;
  i, k: integer;
begin
  for k := 0 to r - 1 do
  begin
    a1 := k / r;
    a2 := (k + 1) / r;
    for i := 1 to n do
      if (x[i] >= a1) and (x[i] < a2) then e[k] := e[k] + 1;
  end;
end;

var
  x: ar;
  e: arint;
  i, a: integer;
  D, M: real;

begin
  x[0] := 0.052;
  x[-1] := 0.568;
  x[-2] := 0.687;
  for a := 0 to 1 do
  begin
    for i := 1 to n do
      x[i] := vichX(x[i - 1], x[i - 2], x[i - 3], a);
    polyinterval(R, x, e);
    for i := 0 to r - 1 do writeln(e[i]);
    for i := 0 to r - 1 do
      M := M + ((2 * i + 1) * e[i]) / (2 * r * n);
    for i := 0 to r - 1 do
      D := D + sqr((2 * i + 1) / 2 * r - M) * e[i] / n;
    writeln('M=', M, ' D=', D);
  end;
end.