uses
  list1, tututuring;

var
  l: list;
  tutu: s;
  st: string;
  i, j: integer;
  abc: alph;

procedure st_in_list(var l: list; st: string);
var
  i, len: integer;
begin
  len := length(st);
  first(l, st[1]);
  for i := 2 to len do in_end(l, st[i])
end;

begin
  inputABC(abc);
  readln(st);
  st_in_list(l, st);
  print(l);
  subtr(tutu, abc);
  l.curr := l.last^.past;
  j := number_ch(l.curr^.data);
  i := 1;
  q(l, i, j, tutu, abc);
  print(l);
end.