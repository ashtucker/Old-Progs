unit list1;

interface

type
  u = ^element;
  element = record
    data: char;
    next, past: u;
  end;
  list = record
    head, curr, last: u;
    size: integer;
  end;

procedure first(var l: list; a: char);
procedure in_end(var l: list; a: char);
procedure in_begin(var l: list; a: char);
procedure print(l: list);
procedure next(var l: list);
procedure past(var l: list);

implementation

procedure next(var l: list);
begin
  if l.curr^.next <> nil then l.curr := l.curr^.next
  else writeln('last');
end;

procedure past(var l: list);
begin
  if l.curr^.past <> nil then l.curr := l.curr^.past
  else writeln('first');
end;

procedure print(l: list);
begin
  l.curr := l.head^.next;
  while l.curr <> l.last do
  begin
    write(l.curr^.data, ' ');
    next(l);
  end;
  writeln();
end;

procedure first(var l: list; a: char);
begin
  new(l.curr);
  new(l.last);
  new(l.head);
  l.last^.data := 'n';
  l.head^.data := 'n';
  l.curr^.data := a;
  l.curr^.next := l.last;
  l.curr^.past := l.head;
  l.head^.next := l.curr;
  l.last^.past := l.curr;
  l.size := 1;
end;

procedure in_end(var l: list; a: char);
begin
  l.curr := l.last^.past;
  new(l.curr^.next);
  l.curr^.next^.data := a;
  l.curr^.next^.past := l.curr;
  l.curr^.next^.next := l.last;
  l.last^.past := l.curr^.next;
  l.size := l.size + 1;
end;

procedure in_begin(var l: list; a: char);
begin
  l.curr := l.head^.next;
  new(l.curr^.past);
  l.curr^.past^.data := a;
  l.curr^.past^.next := l.curr;
  l.curr^.past^.past := l.head;
  l.head^.next := l.curr^.past;
  l.size := l.size + 1;
end;

begin
end.