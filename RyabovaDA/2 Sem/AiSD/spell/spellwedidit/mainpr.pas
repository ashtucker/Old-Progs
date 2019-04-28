program spell (input, output, dictionary);

uses
  IO, TRIE, DATA;

var
  A: SLOVAR;
  nextword: wordtype;

begin
  MAKENULL(A);
  while not eof(dictionary) do 
  begin
    getword(nextword, dictionary);
    INSERT(nextword, A);
  end;
  while not eof(input) do 
  begin
    getword(nextword, input);
    if (not (search(nextword, A))) then 
    begin
      print(nextword, output);
    end;
  end;
  
  close(output);
end.