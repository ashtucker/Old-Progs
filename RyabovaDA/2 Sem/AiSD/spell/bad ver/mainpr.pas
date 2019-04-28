program spell (input, output, dictionary);

Uses  UFU, IO, TRIE

var A: SET;

begin
		MAKENULL(A);
		while not eof(input) do begin
			getword(nextword, input);
			INSERT(nextword, A);
		end;
		while not eof(dictionary) do begin
			getword(nextword, dictionary);
			DELETE(nextword, A)
		end;
		PRINT(A)
	end;
end.