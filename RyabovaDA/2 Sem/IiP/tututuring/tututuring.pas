unit tututuring;

interface

uses
  list1;

const
  lambda = ' ';
  n = 3;
  m = 10;

type
  alph = array [0..m] of char;
  state = record
    q_curr: integer;
    a_curr: char;
    q_next: integer;
    move: char;
    a_new: char;
  end;
  s = array [0..n, 0..m] of state;

procedure inputABC(var abc: alph);
procedure subtr(var tutu: s; abc: alph);
procedure inputuring(var tutu: s; abc: alph);
function number_ch(ch: char): integer;
procedure moving(var l: list; m: char);
procedure q(var l: list; var i, j: integer; tutu: s; abc: alph);
procedure check(var l: list);

implementation

procedure check(var l: list);
var
  y: u;
begin
  y := l.curr;
  if l.curr^.next^.data = 'n' then in_end(l, lambda);
  if l.curr^.past^.data = 'n' then in_begin(l, lambda);
  l.curr := y;
end;

procedure inputABC(var abc: alph);
var
  i: integer;
  st: string;
begin
  for i := 0 to m - 1 do
  begin
    st := intToStr(i);
    abc[i] := st[1];
  end;
  abc[10] := lambda;
end;

procedure subtr(var tutu: s; abc: alph);
var
  i, j: integer;
begin
  for i := 1 to n do
    for j := 0 to m do
    begin
      tutu[i, j].q_curr := i;
      tutu[i, j].a_curr := abc[j];
    end;
  tutu[1, 0].a_new := '9';
  tutu[1, 0].move := 'l';
  tutu[1, 0].q_next := 1;
  tutu[1, 1].a_new := '0';
  tutu[1, 1].move := 'l';
  tutu[1, 1].q_next := 2;
  tutu[1, 2].a_new := '1';
  tutu[1, 2].move := 's';
  tutu[1, 2].q_next := 0;
  tutu[1, 3].a_new := '2';
  tutu[1, 3].move := 's';
  tutu[1, 3].q_next := 0;
  tutu[1, 4].a_new := '3';
  tutu[1, 4].move := 's';
  tutu[1, 4].q_next := 0;
  tutu[1, 5].a_new := '4';
  tutu[1, 5].move := 's';
  tutu[1, 5].q_next := 0;
  tutu[1, 6].a_new := '5';
  tutu[1, 6].move := 's';
  tutu[1, 6].q_next := 0;
  tutu[1, 7].a_new := '6';
  tutu[1, 7].move := 's';
  tutu[1, 7].q_next := 0;
  tutu[1, 8].a_new := '7';
  tutu[1, 8].move := 's';
  tutu[1, 8].q_next := 0;
  tutu[1, 9].a_new := '8';
  tutu[1, 9].move := 's';
  tutu[1, 9].q_next := 0;
  tutu[1, 10].a_new := lambda;
  tutu[1, 10].move := 's';
  tutu[1, 10].q_next := 0;
  tutu[2, 0].a_new := '0';
  tutu[2, 0].move := 's';
  tutu[2, 0].q_next := 0;
  tutu[2, 1].a_new := '1';
  tutu[2, 1].move := 's';
  tutu[2, 1].q_next := 0;
  tutu[2, 2].a_new := '2';
  tutu[2, 2].move := 's';
  tutu[2, 2].q_next := 0;
  tutu[2, 3].a_new := '3';
  tutu[2, 3].move := 's';
  tutu[2, 3].q_next := 0;
  tutu[2, 4].a_new := '4';
  tutu[2, 4].move := 's';
  tutu[2, 4].q_next := 0;
  tutu[2, 5].a_new := '5';
  tutu[2, 5].move := 's';
  tutu[2, 5].q_next := 0;
  tutu[2, 6].a_new := '6';
  tutu[2, 6].move := 's';
  tutu[2, 6].q_next := 0;
  tutu[2, 7].a_new := '7';
  tutu[2, 7].move := 's';
  tutu[2, 7].q_next := 0;
  tutu[2, 8].a_new := '8';
  tutu[2, 8].move := 's';
  tutu[2, 8].q_next := 0;
  tutu[2, 9].a_new := '9';
  tutu[2, 9].move := 's';
  tutu[2, 9].q_next := 0;
  tutu[2, 10].a_new := lambda;
  tutu[2, 10].move := 'r';
  tutu[2, 10].q_next := 3;
  tutu[3, 0].a_new := '0';
  tutu[3, 0].move := 'r';
  tutu[3, 0].q_next := 3;
  tutu[3, 9].a_new := '9';
  tutu[3, 9].move := 's';
  tutu[3, 9].q_next := 0;
end;


procedure inputuring(var tutu: s; abc: alph);
var
  i, j: integer;
begin
  for i := 0 to n do
  begin
    for j := 0 to m do
    begin
      tutu[i, j].q_curr := i;
      writeln('q[next]=');
      readln(tutu[i, j].q_next);
      writeln('move = ');
      readln(tutu[i, j].move);
      tutu[i, j].a_curr := abc[j];
      writeln(tutu[i, j].a_curr);
      writeln('tutu[i,j].a_new =');
      readln(tutu[i, j].a_new);
      end;
  end;
end;

function number_ch(ch: char): integer;
begin
  if ch = lambda then result := 10 else
    result := ord(ch) - 48;
end;

procedure moving(var l: list; m: char);
begin
  if (m = 'l') then past(l);
  if (m = 'r') then next(l);
end;

procedure q(var l: list; var i, j: integer; tutu: s; abc: alph);
var
  k: integer;
begin
  check(l);
  l.curr^.data := tutu[i, j].a_new;
  moving(l, tutu[i, j].move);
  k := number_ch(l.curr^.data);
  i := tutu[i, j].q_next;
  j := k;
  if (i > 0) then
    q(l, i, j, tutu, abc) else writeln('FFFFinal');
end;

begin
end.