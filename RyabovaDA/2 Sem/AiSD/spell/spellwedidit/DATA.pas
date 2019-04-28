unit DATA;

type
  chars = 'A'..'Z';
  CELL = record
    next: array [chars] of ^CELL;
  end;
  SLOVAR = record
    CURRENT, HEAD: ^CELL;
  end;
  
  PSLOVAR = ^SLOVAR;
  PCELL = ^CELL;
  wordtype = array[1..100] of char;

var
  input, output, dictionary: text;

begin
  assign(input, 'input.txt');
  assign(output, 'output.txt');
  assign(dictionary, 'dictionary.txt');
  rewrite(output);
  reset(input);
  reset(dictionary);
end.