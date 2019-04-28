unit TRIE;

interface

type SLOVAR=^pSLOVAR;
 pSLOVAR=record
 prefix: char;{указатель на первую ячейку списка узла сына}
 next1:^SLOVAR; {указатель на следующую ячейку списка}
 next2:^SLOVAR;
 end;
 
 const
  chars = ('A', 'B', ..., 'Z', '$');
  TRIENODE = array[chars] of ^SLOVAR;
  TRIE = ^SLOVAR;
  
 
implementation
procedure MAKENULL ( var node: SLOVAR );
procedure ASSIGN ( var node: SLOVAR; c:chars; p: ^SLOVAR );
procedure ASSIGN ( var node: SLOVAR; c:chars; p: ^SLOVAR );
procedure INSERT ( x: chars; var words: TRIE );

procedure MAKENULL ( var node: SLOVAR );
{ делает node листом, т.е. пустым отображением }
var
    c:chars;
begin
    for c:= 'A' to '$' do
        node[c]:= nil
end;

procedure ASSIGN ( var node: SLOVAR; c:chars; p: ^SLOVAR );
begin
    node[c]:= p;
end;

function VALUEOF ( var node: SLOVAR; c:chars ): ^SLOVAR;
begin
    return(node[c])
end;

procedure GETNEW ( var node: SLOVAR; c:chars );
begin
    new(node[c]);
    MAKENULL(node[c]);
end;

procedure INSERT ( x: chars; var words: TRIE );
var
    i: integer; { считает позиции в слове x }
    t: TRIE; { используется для указания на узлы дерева соответствующие префиксу слова X }
begin
    i:= 1;
    t:= words;
    while x[i] <> '$' do begin
        if VALUEOF(t^, x[i]) = nil then { если текущий узел не имеет сына для символа x[i], то он создается }
        GETNEW(t^, x[i]);
    t:= VALUEOF(t^, x[i]); { продвижение к сыну узла t для символа x[i] }
    i:= i + 1 {перемещение далее по слову x}
end;
;

begin
end.