unit TRIE;

interface

uses
  DATA;

procedure MAKENULL(var node: SLOVAR);
procedure INSERT(x: wordtype; var A: SLOVAR );
function search(x: wordtype; A: SLOVAR): boolean;
implementation

procedure MAKENULL(var node: SLOVAR);
{ делает node листом, т.е. пустым отображением }
var
  c: char;
begin
  new(node.head);
  for c := 'A' to 'Z' do
    node.HEAD^.next[c] := nil
end;

function VALUEOF(var node: SLOVAR; c: char): PCELL;
begin
  Result := node.current^.next[c];
end;

procedure GETNEW(var node: CELL; c: char );
begin
  new(node.next[c])
end;

procedure INSERT(x: wordtype; var A: SLOVAR );
var
  i: integer;{ считает позиции в слове x }
begin
  i := 1;
  A.current := A.head;
  while x[i] <> ',' do 
  begin
    if VALUEOF(A, x[i]) = nil then { если текущий узел не имеет сына для символа x[i], то он создается }
      GETNEW(A.CURRENT^, x[i]);
    A.current := VALUEOF(A, x[i]); { продвижение к сыну узла t для символа x[i] }
    inc(i); {перемещение далее по слову x}
  end;
end;

function search(x: wordtype; A: SLOVAR): boolean;
var
  i: integer;
begin
  i := 1;
  A.current := A.head;
  while ((x[i] <> ',') and (A.current^.next[x[i]] <> nil)) do
  begin
    A.current := A.current^.next[x[i]];
    inc(i);
  end;
  if (x[i] = ',') then Result := true
  else Result := false;
end; {search}

end.